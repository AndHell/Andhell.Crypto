using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    public interface IKeyPair
    {
        IPrivateSecretKey Secret { get;  }

        IPublicKey Public { get; }

        void Clear();
    }

    public interface IPublicKey : IKey
    { }

    public interface IPrivateSecretKey : IKey
    { }
}
