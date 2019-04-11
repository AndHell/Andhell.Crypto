using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Andhell.Crypto.Salty
{
    // ToDo: Detached Mode
    // - Do NOT inlcude the plaintext message in the returned signatur

    /// <summary>
    /// Sign a Message with an Asymmetric Key
    /// 
    /// Primitive: Ed25519 (libsodium crypto_sign)
    /// </summary>
    public class Signer : ISigner
    {
        private IPrivateSecretKey PrivKey;


        /// <summary>
        /// Create Signer
        /// 
        /// Primitive: Ed25519 (libsodium crypto_sign)
        /// </summary>
        /// <param name="privKey">Private Key used for Signing</param>
        /// <example>
        /// <code>
        /// // Create KeyPair
        /// var AliceKeys = new SigningKeyPair();
        ///
        /// // Create Sigend with the Private Key
        /// var pen = new Signer(AliceKeys.Secret);
        ///
        /// // create signature
        /// var signature = pen.Sign(MESSAGE);
        ///
        /// // Validate with the Public Key
        /// if(signature.Verify(MESSAGE, AliceKeys.Public))
        /// //    Singature is Valid!
        /// 
        /// pen.Clear();
        /// </code>
        /// </example>
        public Signer(IPrivateSecretKey privKey)
        {
            PrivKey = privKey ?? throw new ArgumentNullException(nameof(privKey));
        }

        /// <summary>
        /// Sign Data
        /// 
        /// Primitive: Ed25519 (libsodium crypto_sign)
        /// </summary>
        /// <param name="data">The Data to Sign</param>
        /// <returns>The Signature (result contains the signature + the data)</returns>
        public ISignature Sign(byte[] data)
        {
            if (data == null || data.Length == 0) throw new ArgumentNullException(nameof(data));

            var sig = Sodium.PublicKeyAuth.Sign(data, PrivKey.Bytes);
            return new Signature(sig);
        }


        /// <summary>
        /// Sign String
        /// 
        /// Primitive: Ed25519 (libsodium crypto_sign)
        /// </summary>
        /// <param name="data">The String to Sign</param>
        /// <returns>The Signature (result contains the signature + the String)</returns>
        public ISignature Sign(string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));

            return Sign(Utils.Secure.Encode(str));
        }

        ~Signer() => Clear();

        public void Clear()
        {
            PrivKey.Clear();
        }
    }

    /// <summary>
    /// Represends a Signature created by the Signer class
    /// </summary>
    public class Signature : ISignature
    {
        /// <summary>
        /// The Signature
        /// 
        /// [Signature || Message]
        /// see libsodiums crypto_sign (combined mode)
        /// </summary>
        public byte[] Bytes { get; private set; }
        
        /// <summary>
        /// Load a Signature for bytes
        /// </summary>
        /// <param name="signature">The Signatures Bytes</param>
        public Signature(byte[] signature)
        {
            if (signature == null || signature.Length == 0) throw new ArgumentNullException(nameof(signature));

            Bytes = signature;
        }

        /// <summary>
        /// Verify a Signature
        /// </summary>
        /// <param name="data">Data that shoud be in the Signature</param>
        /// <param name="key">Public key of the KeyPair used for the Signature</param>
        /// <returns>True: If the signature is valid and the singed data are equal</returns>
        public bool Verify(byte[] data, IPublicKey key)
        {
            if (data == null || data.Length == 0) throw new ArgumentNullException(nameof(data));
            if (key == null) throw new ArgumentNullException(nameof(key));

            try
            {
                var res = Sodium.PublicKeyAuth.Verify(Bytes, key.Bytes);
                return Utils.Secure.Compare(data, res);
            }
            catch (CryptographicException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify a Signature
        /// </summary>
        /// <param name="data">String that shoud be in the Signature</param>
        /// <param name="key">Public key of the KeyPair used for the Signature</param>
        /// <returns>True: If the signature is valid and the singed string equals str</returns>
        public bool Verify(string str, IPublicKey key)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            if (key == null) throw new ArgumentNullException(nameof(key));

            return Verify(Utils.Secure.Encode(str), key);
        }
    }
}
