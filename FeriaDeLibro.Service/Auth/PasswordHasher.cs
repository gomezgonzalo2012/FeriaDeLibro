using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] GenerateHashPassword(string password, byte[] salt)
        {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password); // pasa contraseña a []bytes
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length]; // []bytes del tamaño de salt+PasswordBytes

            // Concatenar password y salt
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            //Hashear la concatenacion de password y salt
            byte[] hashedBytes = SHA256.HashData(saltedPassword);

            return hashedBytes;

        }
        

        public byte[] GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}
