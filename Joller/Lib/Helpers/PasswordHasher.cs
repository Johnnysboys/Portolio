using System;
using System.Security.Cryptography;

namespace Joller.Lib.Helpers
{
    public class PasswordHasher : IPasswordHasher
    {
        private string Encrypt(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            var hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }
        public string[] Encrypt(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var saltString = Convert.ToBase64String(salt);
            var hashedPassword = this.Encrypt(password, salt);
            return new string[] { hashedPassword, saltString };
        }

        public bool ValidatePassword(string password, string encryptedPassword, string saltString)
        {
            var salt = Convert.FromBase64String(saltString);

            var encrypted = this.Encrypt(password, salt);

            return encrypted.Equals(encryptedPassword);
        }
    }
}