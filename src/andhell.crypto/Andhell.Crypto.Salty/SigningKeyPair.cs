using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty
{

    /// <summary>
    /// Represents a Asymmetric KeyPair to be used with Signer
    /// </summary>
    public class SigningKeyPair : IKeyPair
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
        public SigningKeyPair()
        {
            var sodiumKeyPair = Sodium.PublicKeyAuth.GenerateKeyPair();
            Secret = new PrivateSecretKey(sodiumKeyPair.PrivateKey);
            Public = new PublicKey(sodiumKeyPair.PublicKey);
        }

        /// <summary>
        /// Generate a KeyPair from a given Private Key
        /// </summary>
        /// <param name="privKey">Secret Private Key</param>
        public SigningKeyPair(IPrivateSecretKey privKey)
        {
            if(privKey == null) throw new ArgumentNullException(nameof(privKey));

            var pubKey = Sodium.PublicKeyAuth.ExtractEd25519PublicKeyFromEd25519SecretKey(privKey.Bytes);
            Secret = privKey;
            Public = new PublicKey(pubKey);
        }

        /// <summary>
        /// Load a KeyPair
        /// </summary>
        /// <param name="privKey">Secret Private Key</param>
        /// <param name="pubKey">Public Key</param>
        public SigningKeyPair(IPrivateSecretKey privKey, IPublicKey pubKey)
        {
            Secret = privKey ?? throw new ArgumentNullException(nameof(privKey));
            Public = pubKey ?? throw new ArgumentNullException(nameof(pubKey));
        }

        ~SigningKeyPair() => Clear();

        /// <summary>
        /// Override the Keys
        /// </summary>
        public void Clear()
        {
            Secret.Clear();
            Public.Clear();
        }
    }
}
