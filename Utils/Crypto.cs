using System;

namespace Assets.Scripts.Saving_System.Utils
{
    internal class Crypto
    {
        public static string CryptoXOR(string text, int key = 42)
        {
            var result = String.Empty;

            foreach (var simbol in text)
            {
                result += (char)(simbol ^ key);
            }

            return result;
        }
    }
}
