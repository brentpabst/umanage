namespace THS.UMS.UI.Utilities
{
    using System;
    using System.Text;

    using THS.UMS.AO.Enums;

    using Random = THS.UMS.AO.Random;

    public static class Encoder
    {
        /// <summary>
        /// Encodes the string.
        /// </summary>
        /// <param name="toEncode">The string to encode.</param>
        /// <returns></returns>
        public static string EncodeString(string toEncode)
        {
            var toEncodeAsBytes = Encoding.UTF8.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Decodes the string.
        /// </summary>
        /// <param name="toDecode">The string to decode.</param>
        /// <returns></returns>
        public static string DecodeString(string toDecode)
        {
            var encodedDataAsBytes = Convert.FromBase64String(toDecode.Replace(" ", "+"));
            return Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        /// <summary>
        /// Generates the temporary password.
        /// </summary>
        /// <returns></returns>
        public static string GenerateTemporaryPassword()
        {
            // Get random phonetic
            var p = Random.RandomEnumValue<PhoneticAlphabet>().ToString();

            // Uppercase first letter
            p = char.ToUpper(p[0]) + p.Substring(1);

            // Get random number sequence
            p += Random.RandomNumber(1111, 9999);

            return p;
        }
    }
}
