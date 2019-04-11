using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto
{
     /// <summary>
     /// Represents a unsecured password in plaintext
     /// </summary>
    public interface IPassword
    {
        /// <summary>
        /// Password in plaintext
        /// </summary>
        string Plaintext { get; }

        /// <summary>
        /// Converts the Password to a format that can be stored and verified
        /// </summary>
        /// <returns>SecuredPassword representation of the Plaintext Passwords</returns>
        ISecuredPassword Storable();

        //ToDo: Where should key derivation for passwords happen?
        // IKey DeriveKey();
    }

    /// <summary>
    /// Represents a secured password hash that can be stored and verified
    /// </summary>
    public interface ISecuredPassword
    {
        /// <summary>
        /// Secure Hash represenation of a Password
        /// </summary>
        string Hash { get; }

        /// <summary>
        /// Compare a Password to the Secured Hash
        /// </summary>
        /// <param name="password">Password that should be compared to the Hash</param>
        /// <returns>True if the Password matches to the Hash, false otherwise</returns>
        bool Verify(IPassword password);
    }
}
