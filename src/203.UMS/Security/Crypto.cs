using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _203.UMS.Security
{
    public class Crypto
    {
        private const string Pass = "AesIsBetterThanRijndael";
        private static readonly byte[] Vector = Encoding.UTF8.GetBytes("@1B2c3D4e5F6g7H8");
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("uManage!sTh3Gre@t3st");
        private const int KeySize = 256;

        public static string Ecrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");

            var password = new Rfc2898DeriveBytes(Pass, Salt, 2);
            var keyBytes = password.GetBytes(KeySize / 8);

            using (var aes = new AesManaged())
            {
                var encryptor = aes.CreateEncryptor(keyBytes, Vector);
                using (var ms = new MemoryStream())
                {
                    using (var cStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        var bText = Encoding.UTF8.GetBytes(text);
                        cStream.Write(bText, 0, bText.Length);
                        cStream.FlushFinalBlock();
                        var cipher = ms.ToArray();
                        return Convert.ToBase64String(cipher);
                    }
                }
            }
        }

        public static string Decrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");

            var cipher = Convert.FromBase64String(text);

            var password = new Rfc2898DeriveBytes(Pass, Salt, 2);
            var keyBytes = password.GetBytes(KeySize / 8);

            using (var aes = new AesManaged())
            {
                var decryptor = aes.CreateDecryptor(keyBytes, Vector);
                using (var ms = new MemoryStream(cipher))
                {
                    using (var cStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        var bText = new byte[cipher.Length];
                        var dByteCount = cStream.Read(bText, 0, bText.Length);

                        return Encoding.UTF8.GetString(bText, 0, dByteCount);
                    }
                }
            }
        }
    }
}
