using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    public interface IMessage
    {
        string Text { get;   }
        
        IHashed Authenticate(IKey key);
        
        bool Verify(IKey key, IHashed messageHash);
        
        IHashed Fingerprint();
        
        bool Verify(IHashed messageHash);
        
        ILocked Lock(IKey key);

        void Unlock(IKey key, ILocked locked);
        
        ISignature Sign(IPrivateSecretKey key);
    }
}
