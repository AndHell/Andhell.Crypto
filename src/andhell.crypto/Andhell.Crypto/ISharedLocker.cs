using Andhell.Crypto.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    /// <summary>
    /// Locks (Encrypt) Data using a Asymmetric / Public-Key Algorithm
    /// </summary>
    public interface ISharedLocker
    {
        ISharedLocked Lock(string str);
        ISharedLocked Lock(byte[] data);
    }

    /// <summary>
    /// Repesents Locked Data, that are encrypted with the ISharedLocker
    /// </summary>
    public interface ISharedLocked
    {
        byte[] Cipher { get;  }
        Nonce Nonce { get; }

        string UnlockString(IPublicKey senderPubKey, IPrivateSecretKey recieverPrivKey);
        byte[] UnlockBytes(IPublicKey senderPubKey, IPrivateSecretKey recieverPrivKey);
    }
}
