using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class PasswordTest
    {
        private const string PASSWORD = "Correct Horse Battery Staple";
        private const string PASSWORD_WRONG = "correcthorsebatterystapleshit";

        [TestMethod]
        public void VerifyPassword()
        {
            var pw = new Password(PASSWORD);

            Assert.AreEqual(PASSWORD, pw.Plaintext);

            var hashed = pw.Storable();

            Assert.IsTrue(hashed.Verify(pw));
        }

        [TestMethod]
        public void VerifyWrongPassword()
        {
            var pw = new Password(PASSWORD);

            Assert.AreEqual(PASSWORD, pw.Plaintext);

            var hashed = pw.Storable();

            Assert.IsFalse(hashed.Verify(new Password(PASSWORD_WRONG)));
        }

        [TestMethod]
        public void NullParmater()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Password(null));
            Assert.ThrowsException<ArgumentNullException>(() => new Password(""));

            Assert.ThrowsException<ArgumentNullException>(() => new SecuredPassword(null));
            Assert.ThrowsException<ArgumentNullException>(() => new SecuredPassword(""));

            var sp = new SecuredPassword(PASSWORD);
            Assert.ThrowsException<ArgumentNullException>(() => sp.Verify(null));

        }
    }
}
