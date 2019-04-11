using Andhell.Crypto.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    /// <summary>
    /// Locks (Encrypt) and Unlocks (Decrypt) Data using a Symmetric / Secret-Key Algorithm
    /// </summary>
    public interface ISecretLocker
    {
        /// <summary>
        /// Encrypts the Data
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        ILocked Lock(byte[] data);

        /// <summary>
        /// Encrypts the Data
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        ILocked Lock(string data);


        /// <summary>
        /// Decrypts the Data into a string
        /// </summary>
        /// <param name="locked">locked Data to be decrypted</param>
        string UnlockString(ILocked locked);

        /// <summary>
        /// Decrypts the Data into a byte[]
        /// </summary>
        /// <param name="locked">locked Data to be decrypted</param>
        byte[] UnlockBytes(ILocked locked);
    }

    /// <summary>
    /// Repesents Locked Data, that are encrypted with the SecretLocker
    /// </summary>
    public interface ILocked
    {
        /// <summary>
        /// encrypted cipher text
        /// </summary>
        byte[] Ciphertext { get; }

        /// <summary>
        /// Nonce/IV used for encryption
        /// </summary>
        Nonce Nonce { get; }

        /// <summary>
        /// Combines Nonce and Cipher into a singel byte[]
        /// 
        /// [NonceSize][Nonce][Cipher]
        /// [4 bytes][N - bytes][X - bytes]
        /// </summary>
        byte[] Combined { get; }
    }
}
