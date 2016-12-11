using System;

namespace Infrastructure.Encryption
{
    public sealed class MD5
    {
        public static string Hash(string value)
        {
            return BitConverter.ToString(System.Security.Cryptography.MD5.Create().ComputeHash(System.Text.Encoding.Default.GetBytes(value))).Replace("-", string.Empty).ToLower();
        }
    }
}
