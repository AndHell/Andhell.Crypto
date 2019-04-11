using Andhell.Crypto.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Sodium;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Locks (Encrypt) and Unlocks (Decrypt) Data with a Symmetric/Secret Key
    /// 
    /// Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)
    /// </summary>
    public class SecretLocker : ISecretLocker
    {
        private readonly IKey key;
             
        /// <summary>
        /// Create a Locker for this Key
        /// </summary>
        /// <param name="key"></param>
        public SecretLocker(IKey key)
        {
            this.key = key ?? throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        /// Encrypts the Data (with Authentication)
        /// 
        /// Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        /// <example>
        /// <code>
        /// var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
        /// // Create a new Symmertic Key
        /// var key = new Key();
        /// // Create a locker with this key
        /// var locker = new SecretLocker(key);
        /// var bytes = Utils.Secure.Encode(TEST_STRING);
        /// // Encrypt the bytes
        /// var ciphertext = locker.Lock(bytes);
        /// // Decrypt the Text
        /// var plaintext = locker.UnlockBytes(ciphertext);
        /// // Clear Keys
        /// locker.Clear();
        /// </code>
        /// </example>
        public ILocked Lock(byte[] data)
        {
            if (data == null || data?.Length == 0) throw new ArgumentNullException(nameof(data));

            var nonce = SecretBox.GenerateNonce();
            var locked = SecretBox.Create(data, nonce, key.Bytes);
            return new Locked(locked, new Nonce(nonce));
        }

        /// <summary>
        /// Encrypts the Data (with Authentication)
        /// 
        /// Primitive: XSalsa20 wiht Poly1305 MAC (libsodium crypto_secretbox)
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        /// <example>
        /// <code>
        /// var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
        /// // Create a new Symmertic Key
        /// var key = new Key();
        /// // Create a locker with this key
        /// var locker = new SecretLocker(key);
        /// // Encrypt the Text
        /// var ciphertext = locker.Lock(TEST_STRING);
        /// // Decrypt the Text
        /// var plaintext = locker.UnlockString(ciphertext);
        /// // Clear Keys
        /// locker.Clear();
        /// </code>
        /// </example>
        public ILocked Lock(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException(nameof(data));

            return Lock(Secure.Encode(data));
        }

        /// <summary>
        /// Decrypts the Data into a byte[]
        /// </summary>
        /// <param name="locked">locked Data to be decrypted</param>
        public byte[] UnlockBytes(ILocked locked)
        {
            if (locked == null) throw new ArgumentNullException(nameof(locked));

            return SecretBox.Open(locked.Ciphertext, locked.Nonce.Bytes, key.Bytes);
        }

        /// <summary>
        /// Decrypts the Data into a string
        /// </summary>
        /// <param name="locked">locked Data to be decrypted</param>
        public string UnlockString(ILocked locked)
        {
            var tmp = UnlockBytes(locked);
            return Secure.Encode(tmp);
        }

        ~SecretLocker() => Clear();

        public void Clear()
        {
            key.Clear();
        }
    }

    /// <summary>
    /// Repesents Locked Data, that are encrypted with the SecretLocker
    /// </summary>
    public class Locked : ILocked
    {
        /// <summary>
        /// Nonce used for encryption
        /// </summary>
        public Nonce Nonce { get; private set; }

        /// <summary>
        /// Combined Nonce and Cipher into a single byte[]
        /// 
        /// [NonceSize][Nonce][Cipher]
        /// [4 bytes][N - bytes][X - bytes]
        /// </summary>
        public byte[] Combined
        {
            get
            {
                byte[] tmp = new byte[sizeof(int) + Nonce.Bytes.Length + Ciphertext.Length];
                BitConverter.GetBytes(Nonce.Bytes.Length).CopyTo(tmp, 0);
                Nonce.Bytes.CopyTo(tmp, sizeof(int));
                Ciphertext.CopyTo(tmp, sizeof(int) + Nonce.Bytes.Length);
                return tmp;
            }
        }

        /// <summary>
        /// encrypted cipher text
        /// </summary>
        public byte[] Ciphertext { get; private set; }

        public Locked(byte[] locked, Nonce nonce)
        {
            if (locked == null) throw new ArgumentNullException(nameof(locked));
            else if (nonce == null) throw new ArgumentNullException(nameof(nonce));

            Ciphertext = locked;
            Nonce = nonce;
        }

        public Locked(byte[] combined)
        {
            if (combined == null) throw new ArgumentNullException(nameof(combined));

            int nonceSize = BitConverter.ToInt32(combined, 0);
            var nonce = new byte[nonceSize];
            Array.Copy(combined, sizeof(int), nonce, 0, nonceSize);
            Nonce = new Nonce(nonce);

            int bytes = combined.Length - (sizeof(int) + nonceSize);
            Ciphertext = new byte[bytes];
            Array.Copy(combined, sizeof(int) + nonceSize, Ciphertext, 0, bytes);
        }
    }
}
