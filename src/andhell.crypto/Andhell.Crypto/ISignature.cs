using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    public interface ISigner
    {
        ISignature Sign(byte[] data);
        ISignature Sign(string str);
    }

    public interface ISignature
    {
        byte[] Bytes { get; }
        
        bool Verify(byte[] data, IPublicKey key);
        bool Verify(string str, IPublicKey key);
    }
}
