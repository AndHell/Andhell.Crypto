using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Represents a Asymmetric KeyPair to be used with SharedLocker
    /// </summary>
    public class KeyPair : IKeyPair
    {
        /// <summary>
        /// Secret Key
        /// 
        /// KEEP PRIVATE and NEVER SHARE this key
        /// </summary>
        public IPrivateSecretKey Secret { get; private set; }

        /// <summary>
        /// Public Key
        /// 
        /// Can be shared
        /// </summary>
        public IPublicKey Public { get; private set; }


        /// <summary>
        /// Generate a new KeyPair
        /// </summary>
        public KeyPair()
        {
            var sodiumKeyPair = Sodium.PublicKeyBox.GenerateKeyPair();
            Secret = new PrivateSecretKey(sodiumKeyPair.PrivateKey);
            Public = new PublicKey(sodiumKeyPair.PublicKey);
        }

        /// <summary>
        /// Generate a KeyPair from a given Private Key
        /// </summary>
        /// <param name="privKey">Secret Private Key</param>
        public KeyPair(IPrivateSecretKey privKey)
        {
            if(privKey == null) throw new ArgumentNullException(nameof(privKey));

            var sodiumKeyPair = Sodium.PublicKeyBox.GenerateKeyPair(privKey.Bytes);
            Secret = new PrivateSecretKey(sodiumKeyPair.PrivateKey);
            Public = new PublicKey(sodiumKeyPair.PublicKey);
        }

        /// <summary>
        /// Load a KeyPair
        /// </summary>
        /// <param name="privKey">Secret Private Key</param>
        /// <param name="pubKey">Public Key</param>
        public KeyPair(IPrivateSecretKey privKey, IPublicKey pubKey)
        {
            Secret = privKey ?? throw new ArgumentNullException(nameof(privKey));
            Public = pubKey ?? throw new ArgumentNullException(nameof(pubKey));
        }

        public void Clear()
        {
            Secret.Clear();
            Public.Clear();
        }
    }

    /// <summary>
    /// Represents a Public Key
    /// 
    /// Can be shared
    /// </summary>
    public class PublicKey : Key, IPublicKey
    {
        public PublicKey(byte[] sharedPubKey) : base(sharedPubKey)
        { }

        public PublicKey(IProtectedKey protectedSharedPubKey) : base(protectedSharedPubKey)
        { }
    }

    /// <summary>
    /// Represents a Private Key
    /// 
    /// KEEP PRIVATE and NEVER SHARE this key
    /// </summary>
    public class PrivateSecretKey : Key, IPrivateSecretKey
    {
        public PrivateSecretKey(byte[] privateKey) : base(privateKey)
        { }

        public PrivateSecretKey(IProtectedKey protectedPrivateKey) : base(protectedPrivateKey)
        { }
    }
}
