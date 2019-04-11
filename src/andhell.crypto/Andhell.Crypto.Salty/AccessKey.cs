using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Represents a Database or API Access key
    /// 
    /// Encrypts Keys with the Windows DPAPI.
    /// 
    /// Plaintext Keys should be droped after first use. Only the ProtectedKey from Storeable() should be stored.
    /// </summary>   
    /// /// </summary>
    /// <example>
    /// <code>
    /// var accessKey = new AccessKey("API SECRET");
    /// // encrypt
    /// var storeable = accessKey.Storable();
    ///
    /// // Store string to Config
    /// Store(storeable.ProtectedString);
    ///
    /// // Load string
    /// string stored_s = Load();
    /// ProtectedKey stored = new ProtectedKey(stored_s);
    ///
    /// // Decrypt Key
    /// var loadedKey = new AccessKey(stored);
    /// </code>
    /// </example>
    public class AccessKey : Key, IAccessKey
    {
        public AccessKey(byte[] key) : base(key) { }

        public AccessKey(string key) : base(Utils.Secure.Encode(key)) { }

        public AccessKey(ProtectedKey protectedKey) : base(protectedKey) { }

        public string KeyString => Utils.Secure.Encode(Bytes);
    }
}
