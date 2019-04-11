using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Andhell.Crypto.Salty.Hash
{
    /// <summary>
    /// Represents a General Hashing function.
    /// </summary>
    /// <example>
    /// <code>
    /// IHashBox hashBox = new HashBox();
    ///
    /// var result = hashBox.Compute(TEST_STRING);
    ///
    /// if(result.Verify(TEST_STRING));
    ///     // Hash matched!
    /// </code>
    /// </example>
    public class HashBox : IHashBox
    {
        private const int OUT_BYTES = 258 / 8;

        /// <summary>
        /// The optional Key used for Keyed Hashing
        /// </summary>
        public IKey Key { get; private set; }

        /// <summary>
        /// HashBox for General Hashing
        /// 
        /// Primitive: BLAKE2b (libsodium crypto_generichash)
        /// </summary>
        /// <param name="generateKey">(Optional) Create a new random Key that is used for Keyed Hashing</param>
        public HashBox(bool generateKey = false)
        {
            if (generateKey)
                Key = new Key(Sodium.GenericHash.GenerateKey());
        }

        /// <summary>
        /// HashBox for keyed Hashing
        /// 
        /// Primitive: BLAKE2b (libsodium crypto_generichash)
        /// </summary>
        /// <param name="key">The Key for Keyed Hashing</param>
        public HashBox(IKey key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }


        /// <summary>
        /// Hashes a Message
        /// 
        /// Primitive: BLAKE2b (libsodium crypto_generichash)
        /// </summary>
        /// <param name="message">The Message</param>
        /// <returns>Returns the Hash in an IHashed container</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IHashed Compute(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            return Compute(Utils.Secure.Encode(message));
        }

        /// <summary>
        /// Hashes data
        /// 
        /// Primitive: BLAKE2b (libsodium crypto_generichash)
        /// </summary>
        /// <param name="data">The Data.</param>
        /// <returns>Returns the Hash in an IHashed container</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public virtual IHashed Compute(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            else if (data.Length == 0) throw new ArgumentException($"{nameof(data)} can't be empty");
            

            return Compute(data, Key); 
        }


        private GenericHash Compute(byte[] data, IKey key)
        {
            var hash = Sodium.GenericHash.Hash(data, key?.Bytes ?? null, OUT_BYTES);
            return new GenericHash(hash);
        }

        public void Clear()
        {
            Key?.Clear();
        }

        ~HashBox() => Clear();
    }

    /// <summary>
    /// Represents a Generic Hash
    /// </summary>
    public class GenericHash : IHashed
    {

        /// <summary>
        /// Hash as Byte[]
        /// </summary>
        public byte[] HashBytes{ get; private set; }

        /// <summary>
        /// Hash as String
        /// 
        /// Uses the default string encoding from Utils.Secure.KeyEncode
        /// </summary>
        public string Hash { get { return Utils.Secure.KeyEncode(HashBytes); } }

        /// <summary>
        /// Represents a Generic Hash
        /// </summary>
        /// <param name="hash">The hashed bytes</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public GenericHash(byte[] hash)
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            else if (hash.Length == 0) throw new ArgumentException($"{nameof(hash)} can't be empty");

            HashBytes = hash;
        }

        /// <summary>
        /// Represents a Generic Hash
        /// </summary>
        /// <param name="hash">Hash as String. Uses the default string encoding from Utils.Secure.KeyEncode</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GenericHash(string hash)
        {
            HashBytes = string.IsNullOrEmpty(hash) ? throw new ArgumentNullException(nameof(hash)) : Utils.Secure.KeyEncode(hash);
        }

        /// <summary>
        /// Checks is the Hashes are equal
        /// </summary>
        /// <param name="hash">Hash to compare with</param>
        /// <returns>True, if the Hash are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Verify(IHashed hash)
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            return Utils.Secure.Compare(HashBytes, hash?.HashBytes);
        }

        /// <summary>
        /// Checks if the Hash of the plaintext equals the Hash
        /// </summary>
        /// <param name="plaintext">String to compare</param>
        /// <returns>True, if the Hash are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Verify(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                throw new ArgumentNullException(nameof(plaintext));

            var hash = new HashBox().Compute(plaintext);
            return Verify(hash);
        }

        /// <summary>
        /// Checks if the Hash of the data equals the Hash
        /// </summary>
        /// <param name="plaindata">Bytes to compare</param>
        /// <returns>True, if the Hash are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Verify(byte[] plaindata)
        {
            if (plaindata == null) throw new ArgumentNullException(nameof(plaindata));
            else if (plaindata.Length == 0) throw new ArgumentException($"{nameof(plaindata)} can't be empty");

            var hash = new HashBox().Compute(plaindata);
            return Verify(hash);
        }

        /// <summary>
        /// Checks if the Keyed Hash of the plaintext equals the hash
        /// </summary>
        /// <param name="plaintext">string to compare</param>
        /// <param name="key">Key used for hashing</param>
        /// <returns>true, is the hashed string matches the hash</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Verify(string plaintext, IKey key)
        {
            var hash = new HashBox(key).Compute(plaintext);
            return Verify(hash);
        }



        /// <summary>
        /// Checks if the Keyed Hash of the data equals the Hash
        /// </summary>
        /// <param name="plaindata">Bytes to compare</param>
        /// <param name="key">Key used for hashing</param>
        /// <returns>True, if the Hash are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Verify(byte[] plaindata, IKey key)
        {
            var hash = new HashBox(key).Compute(plaindata);
            return Verify(hash);
        }
    }
}
