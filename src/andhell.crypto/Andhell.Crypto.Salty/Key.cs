using System;
using System.Linq;
using System.Security.Cryptography;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Represents a Symmetric Key
    /// </summary>
    public class Key : IKey
    {
        /// <summary>
        /// The Key Bytes
        /// </summary>
        public byte[] Bytes { get; private set; }

        /// <summary>
        /// Load a Key from existing bytes.
        /// </summary>
        /// <param name="key"></param>
        public Key(byte[] key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            else if (key.Length == 0) throw new ArgumentException($"{nameof(key)} can't be empty");
            else if (key.All(x => x == 0)) throw new ArgumentException($"{nameof(key)} can't be empty");
            else if (key.Length < Utils.Secure.KEY_LENGTH_MIN) throw new ArgumentException($"{nameof(key)} to short. Min leghts: {Utils.Secure.KEY_LENGTH_MIN} bit");

            Bytes = key;
        }

        /// <summary>
        /// Load a Windows DPAPI Protected Key
        /// </summary>
        /// <param name="key"></param>
        public Key(IProtectedKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                Bytes = ProtectedData.Unprotect(key.ProtectedBytes, null, DataProtectionScope.CurrentUser);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new random Key
        /// </summary>
        public Key() => Bytes = Utils.Random.Bytes(Utils.Secure.KEY_LENGTH);

        /// <summary>
        /// Uses the Windows Data Protection API to encrypt the key
        /// 
        /// ONLY WORKS ON WINDOWS
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Thrown if called on Platforms != Windows</exception>
        public IProtectedKey Storable()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return new ProtectedKey(ProtectedData.Protect(Bytes, null, DataProtectionScope.CurrentUser));
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Override the Key
        /// </summary>
        public void Clear() => Utils.Secure.ClearBytes(Bytes);


        ~Key() => Clear();
    }

    /// <summary>
    /// Represents a Windows DPAPI Protected Key
    /// </summary>
    public class ProtectedKey : IProtectedKey
    {
        public byte[] ProtectedBytes { get; private set; }


        public string ProtectedString { get { return Utils.Secure.KeyEncode(ProtectedBytes); } }

        public ProtectedKey(byte[] protectedKey)
        {
            if (protectedKey == null) throw new ArgumentNullException(nameof(protectedKey));
            else if (protectedKey.Length == 0) throw new ArgumentException($"{nameof(protectedKey)} can't be empty");

            ProtectedBytes = protectedKey;
        }

        public ProtectedKey(string protectedKey)
        {
            if (string.IsNullOrEmpty(protectedKey)) throw new ArgumentNullException(nameof(protectedKey));

            ProtectedBytes = Utils.Secure.KeyEncode(protectedKey);
        }


        public void Clear() => Utils.Secure.ClearBytes(ProtectedBytes);


        ~ProtectedKey() => Clear();
    }
}
