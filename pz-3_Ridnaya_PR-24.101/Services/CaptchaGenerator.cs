
using System;
using System.Text;

namespace pz_3_Ridnaya_PR_24._101.Services
{
    public static class CaptchaGenerator
    {
        private static readonly Random random = new Random();

        private const string Characters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateCaptchaText(int length)
        {
            if (length <= 0)
                throw new ArgumentException(
                    "Длина капчи должна быть больше нуля.");

            StringBuilder captcha = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(Characters.Length);
                captcha.Append(Characters[index]);
            }

            return captcha.ToString();
        }
    }
}
