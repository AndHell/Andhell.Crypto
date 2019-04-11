using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
    public interface IAccessKey : IKey
    {
        string KeyString { get; }
    }
}
