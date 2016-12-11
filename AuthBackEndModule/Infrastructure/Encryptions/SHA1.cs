﻿using System;

namespace Infrastructure.Encryption
{
    public sealed class SHA1
    {
        public static string Hash(string value)
        {
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(System.Text.Encoding.Default.GetBytes(value))).Replace("-", string.Empty).ToLower();
        }
    }
}
