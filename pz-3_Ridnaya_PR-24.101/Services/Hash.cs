
using System;
using System.Security.Cryptography;
using System.Text;

namespace pz_3_Ridnaya_PR_24._101.Services
{
    public static class Hash
    {
        public static string GetSha256Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder result = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    result.Append(b.ToString("X2"));
                }

                return result.ToString();
            }
        }
    }
}
