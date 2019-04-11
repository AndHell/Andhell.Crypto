using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Represents a Text Message
    /// </summary>
    public class Message : IMessage
    {
        /// <summary>
        /// The Message Plaintext
        /// </summary>
        public string Text { get; private set; }


        public Message(string text) => Text = string.IsNullOrEmpty(text) ? throw new ArgumentNullException(nameof(text)) : text;

        /// <summary>
        /// Authenticate the Message
        /// 
        /// Creates a HMAC
        /// </summary>
        /// <param name="key">Symmetric Key used for the Authentication</param>
        /// <returns>Authenticated HMAC</returns>
        public IHashed Authenticate(IKey key) => new Hash.HMACHashBox(key).Compute(Text);

        /// <summary>
        /// Verify a Authenticated Message Hash
        /// </summary>
        /// <param name="key">Symmetric Key used for Authentication</param>
        /// <param name="messageHash">Hashed Message</param>
        /// <returns>True, is the MessageHash was created with the given symmetric Key</returns>
        public bool Verify(IKey key, IHashed messageHash) => Authenticate(key).Verify(messageHash);

        /// <summary>
        /// Fingerprints the Message with a Hash
        /// </summary>
        /// <returns>The hash of the message</returns>
        public IHashed Fingerprint() => new Hash.HashBox().Compute(Text);

        /// <summary>
        /// Verify the Fingerprint of a Message
        /// </summary>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        public bool Verify(IHashed fingerprint) => Fingerprint().Verify(fingerprint);


        /// <summary>
        /// Lock the Message with a Symmetric Key
        /// </summary>
        /// <param name="key">The Symmetric  Key</param>
        /// <returns>The Locked Message</returns>
        public ILocked Lock(IKey key) => new SecretLocker(key).Lock(Text);


        /// <summary>
        /// Unlock the Message with a Symmetric Key
        /// </summary>
        /// <param name="key">The Symmetric Key</param>
        /// <param name="locked">The Locked Message</param>
        public void Unlock(IKey key, ILocked locked)
        {
            var locker = new SecretLocker(key);
            Text = locker.UnlockString(locked);
        }

        /// <summary>
        /// Sign the Message with an Asymmertic Key
        /// </summary>
        /// <param name="key">The Private Key to sign the Message</param>
        /// <returns>The Message Signature (contains the Signatrue together with the Message)</returns>
        public ISignature Sign(IPrivateSecretKey key) => new Signer(key).Sign(Text);

    }
}
