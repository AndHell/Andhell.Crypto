using Andhell.Crypto.Salty.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class HashTests
    {
        public const string TEST_STRING = "eine kuh macht muh, viele kühe machen mühe";
        public const string TEST_STRING_CHANGED = "eine kuh macht muh, viele kühe machen muehe";


        public readonly byte[] TEST_KEY = new byte[] { 37, 79, 157, 172, 121, 14, 250, 209, 12, 38, 43, 26, 195, 179, 53, 32, 180, 219, 46, 240, 174, 90, 255, 47, 148, 161, 35, 184, 157, 241, 106, 146 };
        public readonly byte[] TEST_HASHED_KEY = new byte[] { 17, 75, 176, 45, 173, 125, 147, 77, 110, 166, 147, 194, 34, 223, 31, 86, 22, 154, 87, 235, 202, 139, 168, 2, 203, 136, 153, 65, 105, 217, 45, 3};

        [TestMethod]
        public void VerifyString()
        {
            IHashBox hashBox = new HashBox();

            var result = hashBox.Compute(TEST_STRING);

            Assert.IsTrue(result.Verify(TEST_STRING));
        }

        [TestMethod]
        public void VerifyString_CHANGED()
        {
            IHashBox hashBox = new HashBox();

            var result = hashBox.Compute(TEST_STRING);

            Assert.IsFalse(result.Verify(TEST_STRING_CHANGED));
        }

        [TestMethod]
        public void VerifyString_Keyed()
        {
            IHashBox hashBox = new HashBox(new Key(TEST_KEY));

            var result = hashBox.Compute(TEST_STRING);
            var hashed = string.Join(", ", result.HashBytes);

            var tmp = new HashedTag(TEST_HASHED_KEY);

            Assert.IsTrue(result.Verify(tmp));
        }

        [TestMethod]
        public void VerifyString_CHANGED_Keyed()
        {
            IHashBox hashBox = new HashBox(new Key(TEST_KEY));

            var result = hashBox.Compute(TEST_STRING_CHANGED);
            var tmp = new HashedTag(TEST_HASHED_KEY);

            Assert.IsFalse(result.Verify(tmp));
        }

        [TestMethod]
        public void VerifyBytes()
        {
            IHashBox hashBox = new HashBox();

            var bytes = Encoding.Default.GetBytes(TEST_STRING);
            var result = hashBox.Compute(bytes);

            Assert.IsTrue(result.Verify(bytes));
        }

        [TestMethod]
        public void VerifyBytes_Keyed()
        {
            IHashBox hashBox = new HashBox(new Key(TEST_KEY));

            var bytes = Encoding.Default.GetBytes(TEST_STRING);
            var result = hashBox.Compute(bytes);
            var tmp = new HashedTag(TEST_HASHED_KEY);

            Assert.IsTrue(result.Verify(tmp));
        }

        [TestMethod]
        public void VerifyBytes_CHANGED()
        {
            IHashBox hashBox = new HashBox();

            var bytes = Encoding.Default.GetBytes(TEST_STRING);
            var result = hashBox.Compute(bytes);

            bytes = Encoding.Default.GetBytes(TEST_STRING_CHANGED);
            Assert.IsFalse(result.Verify(bytes));
        }

        [TestMethod]
        public void VerifyBytes_CHANGED_Keyed()
        {
            IHashBox hashBox = new HashBox(new Key(TEST_KEY));

            var bytes = Encoding.Default.GetBytes(TEST_STRING_CHANGED);
            var result = hashBox.Compute(bytes);
            var tmp = new HashedTag(TEST_HASHED_KEY);

            Assert.IsFalse(result.Verify(tmp));
        }

        [TestMethod]
        public void VerifyNullParamters()
        {
            HashBox hashBox = new HashBox();

            string strNull = null;
            Assert.ThrowsException<ArgumentNullException>(() => hashBox.Compute(strNull));
            strNull = "";
            Assert.ThrowsException<ArgumentNullException>(() => hashBox.Compute(strNull));

            byte[] bNull = null;
            Assert.ThrowsException<ArgumentNullException>(() => hashBox.Compute(bNull));
            bNull = new byte[0];
            Assert.ThrowsException<ArgumentException>(() => hashBox.Compute(bNull));
            

            Key kNull = null;
            Assert.ThrowsException<ArgumentNullException>(() => new HashBox(kNull));

        }

        [TestMethod]
        public void VerifyNullParamters_GenericHash()
        {
            var hash = new GenericHash("abcd");

            string strNull = null;
            Assert.ThrowsException<ArgumentNullException>(() => new GenericHash(strNull));
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(strNull));
            strNull = "";
            Assert.ThrowsException<ArgumentNullException>(() => new GenericHash(strNull));
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(strNull));

            byte[] bNull = null;
            Assert.ThrowsException<ArgumentNullException>(() => new GenericHash(bNull));
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(bNull));
            bNull = new byte[0];
            Assert.ThrowsException<ArgumentException>(() => new GenericHash(bNull));
            Assert.ThrowsException<ArgumentException>(() => hash.Verify(bNull));

            GenericHash gh = null;
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(gh));

            //Keyed
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(TEST_STRING, null));
            Assert.ThrowsException<ArgumentNullException>(() => hash.Verify(Encoding.UTF8.GetBytes(TEST_STRING), null));

        }
    }
}
