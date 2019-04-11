using System;
using System.Security.Cryptography;

namespace Andhell.Crypto.Utils
{
    /// <summary>
    /// Create Cryptographic Secure Randomness
    /// </summary>
    public static class Random
    {
        /// <summary>
        /// Create Random Bytes
        /// </summary>
        /// <param name="length">Amount of bytes to create</param>
        /// <returns>Random bytes</returns>
        public static byte[] Bytes(int length)
        {
            if (length <= 0)
                throw new ArgumentException($"{nameof(length)} is negativ or null", nameof(length));

            return randomBytes(length);
        }

        /// <summary>
        /// Create a Random Integer
        /// </summary>
        /// <returns>Random Integer</returns>
        public static int Int() => BitConverter.ToInt32(Bytes(sizeof(int)), 0);

        /// <summary>
        /// Create a Random unsigned Integer
        /// </summary>
        /// <returns>Random unsigned Integer</returns>
        public static uint UInt() => BitConverter.ToUInt32(Bytes(sizeof(uint)), 0);

        /// <summary>
        /// Create a Random Double
        /// </summary>/ 
        /// <returns>Random Double</returns>
        public static double Double => BitConverter.ToDouble(Bytes(sizeof(double)), 0);

        private static byte[] randomBytes(int length)
        {
            // Returns a RNGCryptoServiceProvider which is based on RNGCryptoServiceProvider for Windows
            // and OpenSSL RAND_bytes otherwise
            using (var rng = RandomNumberGenerator.Create())
            {
                var rNumber = new byte[length];
                rng.GetBytes(rNumber);
                return rNumber;
            }
        }
    }
}
