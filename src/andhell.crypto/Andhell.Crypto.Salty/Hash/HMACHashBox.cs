using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty.Hash
{
    /// <summary>
    /// HashBox for Keyed Hashing
    /// 
    /// Primitive: HMAC-SHA512-256 (libsodium crypt_auth)
    /// </summary>   
    /// <example>
    /// <code>
    /// string Text = "Hallo Welt!";
    /// Key key = new Key();
    /// HMACHashBox hmac = new Hash.HMACHashBox(key);
    /// Hashed hash = hmac.Compute(Text);
    ///
    /// var signed = hash.Hash;
    ///
    /// //Verify
    /// Hashed hash = new Hashed(signed);
    ///
    /// if (hash.Verify(Text, key))
    ///     // Authentication OK!
    /// locker.Clear();
    /// </code>
    /// </example>
    public class HMACHashBox : HashBox
    {

        /// <summary>
        /// HashBox for Keyed Hashing
        /// 
        /// Creates a new Key
        /// </summary>
        public HMACHashBox() : base(generateKey: true)
        {
        }

        /// <summary>
        /// HashBox for Keyed Hashing
        /// </summary>
        /// <param name="key">The Key</param>
        public HMACHashBox(IKey key) : base(key)
        {
        }

        /// <summary>
        /// Hashes a Message
        /// 
        /// Primitive : HMAC-SHA512-256 (libsodium crypt_auth)
        /// </summary>
        /// <param name="message">The message to be hashed.</param>
        /// <returns>Returns the Hash in an IHashed container</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override IHashed Compute(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException(nameof(data));

            return Compute(Utils.Secure.Encode(data));
        }

        /// <summary>
        /// Hashes data
        /// 
        /// uses libsodiums crypt_auth (HMAC-SHA512-256)
        /// </summary>
        /// <param name="data">The data to be hashed.</param>
        /// <returns>Returns the Hash in an IHashed container</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public override IHashed Compute(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            else if (data.Length == 0) throw new ArgumentException($"{nameof(data)} can't be empty");


            return Compute(data, Key);
        }

        private HashedTag Compute(byte[] data, IKey key) => new HashedTag(Sodium.SecretKeyAuth.Sign(data, key?.Bytes));

    }

    /// <summary>
    /// Representes a HMAC Tag
    /// </summary>
    public class HashedTag : GenericHash
    {
        public HashedTag(byte[] hash) : base(hash) { }

        public HashedTag(string hash) : base(hash) { }

        /// <summary>
        /// Checks is the Hashes are equal
        /// 
        /// Compares in constant time
        /// </summary>
        /// <param name="hash">Hash used for comparing</param>
        /// <returns>true, is the hashes are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override bool Verify(IHashed hash)
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));

            return Utils.Secure.Compare(HashBytes, hash?.HashBytes);
        }

        /// <summary>
        /// NOT DEFINED
        /// To compare a HashTag you always need a key
        /// </summary>
        public override bool Verify(string plaintext) => throw new NotImplementedException();

        /// <summary>
        /// NOT DEFINED
        /// To compare a HashTag you always need a key
        /// </summary>
        public override bool Verify(byte[] plaindata) => throw new NotImplementedException();

        /// <summary>
        /// Checks if the Keyed Hash of the plaintext equals the hash
        /// </summary>
        /// <param name="plaintext">string to compare</param>
        /// <param name="key">Key used for hashing</param>
        /// <returns>true, is the hashed string matches the hash</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override bool Verify(string plaintext, IKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return Sodium.SecretKeyAuth.Verify(plaintext, key?.Bytes, HashBytes);
        }

        /// <summary>
        /// Checks if the Keyed Hash of the data equals the Hash
        /// </summary>
        /// <param name="plaindata">Bytes to compare</param>
        /// <param name="key">Key used for hashing</param>
        /// <returns>True, if the Hash are equal</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override bool Verify(byte[] plaindata, IKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return Sodium.SecretKeyAuth.Verify(plaindata, key?.Bytes, HashBytes);
        }
    }
}
