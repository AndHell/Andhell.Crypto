using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class SymmKeyTest
    {
        private readonly byte[] testKey = new byte[] {
            100, 3, 232, 186, 143, 244, 221, 197,
            50, 4, 196, 143, 34, 144, 127, 137,
            54, 35, 74, 209, 113, 154, 162, 70,
            14, 119, 63, 100, 70, 68, 106, 7 };
        private readonly byte[] combined = new byte[] {24, 0, 0, 0, 93, 180, 41, 26, 82, 20, 208, 242, 64, 24, 115, 174, 114, 242, 92, 19, 239, 174, 208, 188, 179, 176, 244, 127, 28, 212, 118, 226, 62, 128, 75, 110, 108, 88, 5, 140, 156, 8, 11, 10, 157, 113, 227, 195, 188, 10, 90, 161, 123, 214, 157, 203, 120, 98, 159, 164, 223, 240, 147, 202, 119, 20, 249, 170, 226, 36, 57, 118, 216, 121, 8, 88, 56, 182, 228, 52, 223, 3, 158, 135, 166, 186, 210, 35
 };
        private readonly byte[] testNonce = new byte[] { 93, 180, 41, 26, 82, 20, 208, 242, 64, 24, 115, 174, 114, 242, 92, 19, 239, 174, 208, 188, 179, 176, 244, 127 };
        private readonly byte[] testCipher = new byte[] { 28, 212, 118, 226, 62, 128, 75, 110, 108, 88, 5, 140, 156, 8, 11, 10, 157, 113, 227, 195, 188, 10, 90, 161, 123, 214, 157, 203, 120, 98, 159, 164, 223, 240, 147, 202, 119, 20, 249, 170, 226, 36, 57, 118, 216, 121, 8, 88, 56, 182, 228, 52, 223, 3, 158, 135, 166, 186, 210, 35 };

        public const string TEST_STRING = "eine kuh macht muh, viele kühe machen mühe";
        public const string TEST_STRING_CHANGED = "eine kuh macht muh, viele kühe machen muehe";

        [TestMethod]
        public void LockString()
        {
            var key = new Key();

            var sl = new SecretLocker(key);

            var en = sl.Lock(TEST_STRING);

            var keyS = string.Join(", ", key.Bytes);
            
            var combinded = string.Join(", ", en.Combined);

            var n = string.Join(", ", en.Nonce.Bytes);
            var c = string.Join(", ", en.Ciphertext);

            var de = sl.UnlockString(en);
            Assert.AreEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_combined()
        {
            var key = new Key(testKey);

            var sl = new SecretLocker(key);

            var en = new Locked(combined);
            
            var de = sl.UnlockString(en);
            Assert.AreEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_CipherWithNonce()
        {
            var key = new Key(testKey);

            var sl = new SecretLocker(key);

            var en = new Locked(testCipher, new Utils.Nonce(testNonce));

            var de = sl.UnlockString(en);
            Assert.AreEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_CipherWithWrongNonce()
        {
            var key = new Key(testKey);

            var sl = new SecretLocker(key);
            var en = new Locked(testCipher, new Utils.Nonce(24));

            var de = "";
            Assert.ThrowsException<CryptographicException>(() => de = sl.UnlockString(en));
            Assert.AreNotEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_CipherWithWrongNonce_ToShort()
        {
            var key = new Key(testKey);

            var sl = new SecretLocker(key);
            var en = new Locked(testCipher, new Utils.Nonce());

            var de = "";
            Assert.ThrowsException<Sodium.Exceptions.NonceOutOfRangeException>(() => de = sl.UnlockString(en));
            Assert.AreNotEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_TamperdChipherText()
        {
            var key = new Key(testKey);

            var sl = new SecretLocker(key);
            var en = new Locked(testCipher, new Utils.Nonce(testNonce));
            
            //tamper ciphertext
            for (int i = 0; i < 5; i++)
                en.Ciphertext[i] = 0;

            var de = "";
            Assert.ThrowsException<CryptographicException>(() => de = sl.UnlockString(en));
            Assert.AreNotEqual(TEST_STRING, de);
        }

        [TestMethod]
        public void UnlockString_WrongKey()
        {
            var sl = new SecretLocker(new Key());
            var en = new Locked(testCipher, new Utils.Nonce(testNonce));
            
            var de = "";
            Assert.ThrowsException<CryptographicException>(() => de = sl.UnlockString(en));
            Assert.AreNotEqual(TEST_STRING, de);
        }


        [TestMethod]
        public void NullParameter()
        {
            byte[] nullBytes = null;
            string nullString = null;

            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(null));
            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(new Key(testKey)).Lock(nullBytes));
            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(new Key(testKey)).Lock(nullString));
            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(new Key(testKey)).Lock(""));

            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(new Key(testKey)).UnlockBytes(null));
            Assert.ThrowsException<ArgumentNullException>(() => new SecretLocker(new Key(testKey)).UnlockString(null));


            Assert.ThrowsException<ArgumentNullException>(() => new Locked(null));
            Assert.ThrowsException<ArgumentNullException>(() => new Locked(null, new Utils.Nonce(testNonce)));
            Assert.ThrowsException<ArgumentNullException>(() => new Locked(testCipher, null));
            Assert.ThrowsException<ArgumentNullException>(() => new Locked(null, null));

        }
    }
}
