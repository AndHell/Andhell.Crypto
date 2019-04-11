using System;
using System.Text;

namespace Andhell.Crypto.Salty
{
    /// <summary>
    /// Represents a unsecured Password in plaintext
    /// </summary>
    /// <example>
    /// <code>
    /// var password = new Password("Correct Horse Battery Staple");
    /// //use this to store in your Database
    /// ISecuredPassword storeablePassword = password.Storable();
    ///        
    /// //To Verify
    /// if (storeablePassword.Verify(password))
    ///     Console.WriteLine("Password matched");
    /// </code>
    /// </example>
    public class Password : IPassword
    {
        /// <summary>
        /// Password in plaintext
        /// </summary>
        public string Plaintext { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="password"></param>
        public Password(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            
            Plaintext = password;
        }

        /// <summary>
        /// Converts the Password to a format that can be stored and verified.
        /// 
        /// Primitve: Argon2 (libsodium crypto_pwhash)
        /// </summary>
        /// <returns>SecuredPassword representation of the Password</returns>
        public ISecuredPassword Storable() => new SecuredPassword(Hash());


        private string Hash() => Sodium.PasswordHash.ArgonHashString(Plaintext);


        /// <summary>
        /// NotImplemented
        /// </summary>
        /// <returns></returns>
        public IKey DeriveKey()// => new Key(Sodium.PasswordHash.ArgonHashBinary(Encoding.UTF8.GetBytes(Plaintext), Sodium.PasswordHash.ArgonGenerateSalt()));
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents a secured password hash that can be stored and verified
    /// </summary>
    public class SecuredPassword : ISecuredPassword
    {
        /// <summary>
        /// </summary>
        /// <param name="hash">String represenation of an Argon2 Hash</param>
        public SecuredPassword(string hash)
        {
            if (string.IsNullOrEmpty(hash)) throw new ArgumentNullException(nameof(hash));

            Hash = hash;
        }

        /// <summary>
        /// Secure Hash represenation of a Password
        /// 
        /// Uses the Argon2 Hashing algorithm of libsodium
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// Compare a Password to the Secured Hash
        /// 
        /// Uses the Argon2 Hashing algorithm of libsodium
        /// </summary>
        /// <param name="password">Password that should be compared to the Hash</param>
        /// <returns>True if the Password matches the Hash, false otherwise</returns>
        /// <example>
        /// <code>
        /// var password = new Password("Correct Horse Battery Staple");
        /// // Read the Password from the Database
        /// string passwordHash = LoadFromDatabase();
        /// var storedPassword = new SecuredPassword(passwordHash);
        ///
        /// if (storedPassword.Verify(password))
        ///    Console.WriteLine("Password matched");
        /// </code>
        /// </example>
        public bool Verify(IPassword password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            return Sodium.PasswordHash.ArgonHashStringVerify(Hash, password?.Plaintext);
        }
    }
}
