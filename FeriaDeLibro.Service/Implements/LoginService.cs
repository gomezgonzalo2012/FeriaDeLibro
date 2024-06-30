using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
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
        public bool Register(string username, string password)
        {
            var userDb = _userRepository.GetUserByName(username);
            if (userDb == null)
            {
                return false; // no existe usuario
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
                    return false;
                }

                return true;
            }catch (Exception ex)  // capturar excepcion de hashing
            {
                return false;
            }
        }

        public bool Verify(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
