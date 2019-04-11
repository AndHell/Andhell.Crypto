using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Andhell.Crypto.Utils
{
    /// <summary>
    /// Collection of Helper Methodess
    /// </summary>
    public class Secure
    {
        //Constants

        /// <summary>
        /// Default Key Length 
        /// </summary>
        public const int KEY_LENGTH     = 32;

        /// <summary>
        /// Minimum Key Length
        /// </summary>
        public const int KEY_LENGTH_MIN = 32;

        /// <summary>
        /// Default Salt Length
        /// </summary>
        public const int SALT_LENGTH    = 32;

        
        /// <summary>
        /// Compare to byte[] in constant Time
        /// </summary>
        /// <returns>True if both inputs are the same</returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool Compare(byte[] data1, byte[] data2)
        {
            if (data1 == null || data2 == null)
                return false;

            // compare the length with a XOR
            // result is 0 if the length are equal
            int result = data1.Length ^ data2.Length;

            
            var min_len = Math.Min(data1.Length, data2.Length);

            // XOR each bytes and OR it with result
            for (int i = 0; i < min_len; i++)
                result |= data1[i] ^ data2[i];

            // If result is still 0, the byte arrays are equal
            return result == 0;
        }


        //ToDo:
        // allow to set the default encoding 

        /// <summary>
        /// Get UTF8 Bytes from a String
        /// </summary>
        public static byte[] Encode(string str) => Encoding.UTF8.GetBytes(str);

        /// <summary>
        /// Get the String from UTF8 bytes
        /// </summary>
        public static string Encode(byte[] str) => Encoding.UTF8.GetString(str);

        /// <summary>
        /// Get Base64 String from a byte[]. Should be used to encode random looking data like Keys and Hashed.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string KeyEncode(byte[] bytes) => Convert.ToBase64String(bytes);

        /// <summary>
        /// Get byte[] from a Base64 String. Should be used to encode random looking data like Keys and Hashed.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] KeyEncode(string str) => Convert.FromBase64String(str);


        /// <summary>
        /// Overrides a byte[] with zeros
        /// </summary>
        /// <param name="bytes">Bytes to Override</param>
        public static void ClearBytes(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = 0;
        }
    }
}
