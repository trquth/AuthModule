using System;
using Infrastructure.Extensions;

namespace Infrastructure.Encryption
{
    public enum EncryptionMode
    {
        MD5 = 0,
        SHA1 = 1
    }

    public sealed class Encryption
    {
        public const EncryptionMode DefaultMode = EncryptionMode.SHA1;

        public static string Encode(string value)
        {
            return Encode(value, DefaultMode);
        }

        public static string Encode(string value, EncryptionMode mode)
        {
            return mode == EncryptionMode.MD5 ? MD5.Hash(value) : SHA1.Hash(value);
        }

        public static string Encrypt(string value)
        {
            return value.StringIsNullEmptyWhiteSpace() ? null : Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(value));
        }

        public static string Decrypt(string value)
        {
            return value.StringIsNullEmptyWhiteSpace() ? null : System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(value));
        }
    }
}
