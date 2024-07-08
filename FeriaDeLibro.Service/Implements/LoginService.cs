using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Errors;
using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Entities.MyExceptions;
using FeriaDeLibro.Service.Auth;
using FeriaDeLibro.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Implements
{
    public class LoginService : ILoginService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        public LoginService( IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public Result<bool> Register(string username, string password)
        {
            var userDb = _userRepository.GetUserByName(username);
            if (userDb == null)
            {
                return Result<bool>.Failed("El usuario no existe"); // no existe usuario
            }
            try
            {
                // operacion de hashing
                var salt = _passwordHasher.GenerateSalt();
                var hashedPassword = _passwordHasher.GenerateHashPassword(password, salt);

                // guardado de usuario
                var user = new User
                {
                    Name = username,
                    Password = Convert.ToBase64String(hashedPassword),
                    Salt = Convert.ToBase64String(salt)
                };

                if (!_userRepository.AddUser(user))
                {
                    return Result<bool>.Failed("Falla al registrar el usuario. Inténtelo más tarde.");
                }

                return Result<bool>.Success(true);
            }
            catch (HashProcedureException ex)  // capturar excepcion de hashing
            {
                throw new HashProcedureException("Error al crear la contraseña");
                //return Result<bool>.Failed()false;
            }
            catch (Exception ex)  
            {
                
                throw ex;
            }
        }

        public Result<int> Verify(string username, string actualpassword)
        {
            var userDb = _userRepository.GetUserByName(username);
            if (userDb != null)
            {
                var passwordDb = userDb.Password;
                var saltDb = userDb.Salt;

                var byteSalt= Convert.FromBase64String(saltDb);
                try
                {
                    // hasheo de contraseña ingresada + salt de la bd
                    var resultPassword = _passwordHasher.GenerateHashPassword(actualpassword, byteSalt);
                    // lo pasamos a string
                    var stringResultPassword = Convert.ToBase64String(resultPassword);
                    // compara strigns de ambas contraseñas
                    if (stringResultPassword == passwordDb)
                    {
                        return Result<int>.Success(0); // camino correcto
                    }
                    else
                    {
                        return Result<int>.Failed(1,"Contraseña incorrecta"); // contraseña incorrecta
                    }
                }
                catch (HashProcedureException ex){
                    throw new HashProcedureException($"Falla al verificar tu contraseña {username} ");
                } 
                
            }
            else
            {
                return Result<int>.Failed(2,"Nombre de usuario incorrecto"); // username incorrect
            }
        }
    }
}
