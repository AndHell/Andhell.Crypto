using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Andhell.Crypto
{
    public interface IHashBox
    {
        IKey Key { get; }
        
        IHashed Compute(string data);
        
        IHashed Compute(byte[] data);
    }

    public interface IHashed
    {
        byte[] HashBytes { get; }
        string Hash { get; }
        bool Verify(IHashed hash);

        bool Verify(string plaintext);

        bool Verify(byte[] plaindata);


        bool Verify(string plaintext, IKey key);

        bool Verify(byte[] plaindata, IKey key);
    }
}