using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andhell.Crypto.Utils
{
    /// <summary>
    /// Number used once
    /// </summary>
    public class Nonce
    {
        /// <summary>
        /// Default Nonce Size
        /// </summary>
        public const int DEFAULT_NONCE_SIZE = 128/8;

        /// <summary>
        /// Nonce Bytes
        /// </summary>
        public byte[] Bytes { get; private set; }

        
        /// <summary>
        /// Creates a new random Nonce
        /// </summary>
        /// <param name="size">[Optional] Size number of Bytes</param>
        public Nonce(int size = DEFAULT_NONCE_SIZE) =>
            Bytes = Random.Bytes(size);

        /// <summary>
        /// Loads some Bytes into a Nonce
        /// 
        /// Should ONLY be used, to convert a received Nonce Byte[].
        /// 
        /// To create a new one, use the contructor with the size parameter.
        /// </summary>
        /// <param name="nonce">Bytes for the Nonce</param>
        public Nonce(byte[] nonce)
        {
            if (nonce == null)              throw new ArgumentNullException(nameof(nonce));
            else if (nonce.Length == 0)     throw new ArgumentException($"{ nameof(nonce) } can't be empty");
            else if (nonce.All(x => x == 0))throw new ArgumentException($"{ nameof(nonce) } can't be empty");

            Bytes = nonce;
        }
    }
}
