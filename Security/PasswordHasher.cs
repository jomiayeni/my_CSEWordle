using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Security
{
    public class PasswordHasher
    {

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashed = HashPassword(enteredPassword);
            return hashed.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }

    }
}