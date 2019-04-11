using Andhell.Crypto.Utils;
using Sodium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Locks Data with a Asymmertic Key
    /// 
    /// Uses libsodiums crypto_box_*
    /// </summary>
    public class SharedLocker : ISharedLocker
    {
        private readonly IPublicKey publickKey;
        private readonly IPrivateSecretKey privateKey;

        /// <summary>
        /// Creates a Locker with Asymmertic/Public Keys
        /// 
        /// Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)
        /// </summary>
        /// <param name="recieverPubKey">The Public Key of the Reciever the Data are locked for</param>
        /// <param name="senderPrivKey">The Private Key of the Sender</param>
        public SharedLocker(IPublicKey recieverPubKey, IPrivateSecretKey senderPrivKey)
        {
            publickKey = recieverPubKey ?? throw new ArgumentNullException(nameof(recieverPubKey));
            privateKey = senderPrivKey ?? throw new ArgumentNullException(nameof(senderPrivKey));
        }

        /// <summary>
        /// Locks a String
        /// 
        /// Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)
        /// </summary>
        /// <param name="str">The String to lock</param>
        /// <returns>The locked String</returns>
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
        /// // Decrypt the String
        /// var plaintext = locker.UnlockString(ciphertext);
        /// // Clear Keys
        /// locker.Clear();
        /// </code>
        /// </example>
        public ISharedLocked Lock(string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));

            return Lock(Secure.Encode(str));
        }

        /// <summary>
        /// Locks Data
        /// 
        /// Primitive: X25519 + XSalsa20 + Poly1305 MAC  (libsodium crypto_box)
        /// </summary>
        /// <param name="str">The Data to lock</param>
        /// <returns>The locked Data</returns>   
        /// /// <example>
        /// <code>
        /// var TEST_STRING = "eine kuh macht muh, viele kühe machen mühe"
        /// // Create a new Symmertic Key
        /// var key = new Key();
        /// // Create a locker with this key
        /// var locker = new SecretLocker(key);
        /// // Encrypt the bytes
        /// var ciphertext = locker.Lock(TEST_STRING);
        /// // Decrypt the bytes
        /// var plaintext = locker.UnlockBytes(ciphertext);
        /// // Clear Keys
        /// locker.Clear();
        /// </code>
        /// </example>
        public ISharedLocked Lock(byte[] data)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentNullException(nameof(data));

            var nonce = new Nonce(PublicKeyBox.GenerateNonce());
            var encrypted = PublicKeyBox.Create(data, nonce.Bytes, secretKey: privateKey.Bytes, publicKey: publickKey.Bytes);
            return new SharedLocked(encrypted, nonce);
        }

        ~SharedLocker() => Clear();

        public void Clear()
        {
            privateKey.Clear();
            publickKey.Clear();
        }
    }


    /// <summary>
    /// Represents Data locked with the SharedLocker
    /// </summary>
    public class SharedLocked : ISharedLocked
    {
        /// <summary>
        /// encrypted cipher text
        /// </summary>
        public byte[] Cipher { get; private set; }

        /// <summary>
        /// Nonce used for encryption
        /// </summary>
        public Nonce Nonce { get; private set; }

        /// <summary>
        /// Combines Nonce and Cipher into a singel byte[]
        /// 
        /// [NonceSize][Nonce][Cipher]
        /// [4 bytes][N - bytes][X - bytes]
        /// </summary>
        public byte[] Combined
        {
            get
            {
                byte[] tmp = new byte[sizeof(int) + Nonce.Bytes.Length + Cipher.Length];
                BitConverter.GetBytes(Nonce.Bytes.Length).CopyTo(tmp, 0);
                Nonce.Bytes.CopyTo(tmp, sizeof(int));
                Cipher.CopyTo(tmp, sizeof(int) + Nonce.Bytes.Length);
                return tmp;
            }
        }

        public SharedLocked(byte[] cipher, Nonce nonce)
        {
            Cipher = cipher ?? throw new ArgumentNullException(nameof(cipher));
            Nonce = nonce ?? throw new ArgumentNullException(nameof(nonce));

            if (cipher.Length == 0) throw new ArgumentNullException(nameof(cipher));
        }

        public SharedLocked(byte[] combined)
        {
            if (combined == null) throw new ArgumentNullException(nameof(combined));

            int nonceSize = BitConverter.ToInt32(combined, 0);
            var nonce = new byte[nonceSize];
            Array.Copy(combined, sizeof(int), nonce, 0, nonceSize);
            Nonce = new Nonce(nonce);

            int bytes = combined.Length - (sizeof(int) + nonceSize);
            Cipher = new byte[bytes];
            Array.Copy(combined, sizeof(int) + nonceSize, Cipher, 0, bytes);
        }

        /// <summary>
        /// Unlock the Data
        /// </summary>
        /// <param name="senderPubKey">The Public Key of the Sender</param>
        /// <param name="recieverPrivKey">The Private Key of the Reciever</param>
        /// <returns>The unlocked Data</returns>
        public byte[] UnlockBytes(IPublicKey senderPubKey, IPrivateSecretKey recieverPrivKey)
        {
            if (senderPubKey == null) throw new ArgumentNullException(nameof(senderPubKey));
            if (recieverPrivKey == null) throw new ArgumentNullException(nameof(recieverPrivKey));

            return PublicKeyBox.Open(Cipher, Nonce.Bytes, secretKey: recieverPrivKey.Bytes, publicKey: senderPubKey.Bytes);
        }


        /// <summary>
        /// Unlock the String
        /// </summary>
        /// <param name="senderPubKey">The Public Key of the Sender</param>
        /// <param name="recieverPrivKey">The Private Key of the Reciever</param>
        /// <returns>The unlocked String</returns>
        public string UnlockString(IPublicKey senderPubKey, IPrivateSecretKey recieverPrivKey) => Secure.Encode(UnlockBytes(senderPubKey, recieverPrivKey));

    }
}
