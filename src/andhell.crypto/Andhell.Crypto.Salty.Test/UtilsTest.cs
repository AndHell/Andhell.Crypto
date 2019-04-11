using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void ComapreTest()
        {
            var bytes1 = new byte[] { 0, 1, 2, 3, 4, 5 };
            var bytes2 = new byte[] { 0, 1, 2, 3, 4, 5 ,6};
            var bytes3 = new byte[] { 0, 1, 2, 3, 4, 6 };

            Assert.IsTrue(Utils.Secure.Compare(bytes1, bytes1));
            Assert.IsFalse(Utils.Secure.Compare(bytes1, bytes2));
            Assert.IsFalse(Utils.Secure.Compare(bytes1, bytes3));
            Assert.IsFalse(Utils.Secure.Compare(bytes1, new byte[0]));
            Assert.IsFalse(Utils.Secure.Compare(new byte[0], bytes1));
            Assert.IsFalse(Utils.Secure.Compare(bytes1, null));
            Assert.IsFalse(Utils.Secure.Compare(null, bytes1));
            Assert.IsFalse(Utils.Secure.Compare(null, null));

        }

        [TestMethod]
        public void ClearBytesTest()
        {
            var bytes1 = new byte[] { 0, 1, 2, 3, 4, 5 };
            Utils.Secure.ClearBytes(bytes1);
            CollectionAssert.AreEqual(new byte[] { 0,0,0,0,0,0}, bytes1);
        }

        [TestMethod]
        public void EncodeTest()
        {
            var str = "Correct Horse Battery Staple";
            var encoded = Utils.Secure.Encode(str);
            Assert.AreEqual(str, Utils.Secure.Encode(encoded));


            var bytes = new byte[] { 217, 2, 11, 94, 13, 184, 231, 147, 249, 85, 212, 42, 87, 32, 237, 152, 78, 54, 146, 104, 91, 198, 45, 41, 240, 29, 245, 242, 74, 6, 207, 29 };
            var encodedStr = Utils.Secure.KeyEncode(bytes);
            CollectionAssert.AreEqual(bytes, Utils.Secure.KeyEncode(encodedStr));

        }
    }
}
