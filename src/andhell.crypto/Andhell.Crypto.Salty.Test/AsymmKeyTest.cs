using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class AsymmKeyTest
    {
        readonly byte[] K_PUB_ALICE = new byte[] { 98, 117, 114, 191, 252, 126, 12, 192, 115, 104, 34, 19, 171, 214, 218, 63, 120, 245, 214, 202, 212, 81, 176, 184, 229, 169, 105, 198, 213, 105, 192, 85 };
        readonly byte[] K_PRI_ALICE = new byte[] { 90, 64, 27, 52, 67, 189, 240, 139, 191, 131, 188, 177, 33, 142, 73, 164, 121, 214, 81, 140, 58, 161, 36, 207, 186, 9, 114, 156, 245, 55, 208, 111 };

        readonly byte[] K_PUB_BOB = new byte[] { 222, 155, 75, 152, 137, 204, 15, 178, 120, 154, 127, 175, 56, 97, 142, 60, 62, 116, 217, 231, 30, 253, 241, 237, 120, 60, 85, 139, 212, 119, 173, 68 };
        readonly byte[] K_PRI_BOB = new byte[] { 84, 231, 150, 21, 22, 93, 238, 135, 47, 229, 133, 172, 217, 193, 59, 122, 166, 48, 13, 167, 243, 125, 247, 253, 71, 138, 158, 54, 49, 182, 152, 70 };

        const string MESSAGE = "eine kuh macht muh, viele kühe machen mühe";

        [TestMethod]
        public void RoundTripTest()
        {
            var AliceKeys = new KeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));
            var BobKeys = new KeyPair(new PrivateSecretKey(K_PRI_BOB), new PublicKey(K_PUB_BOB));

            var locker = new SharedLocker(BobKeys.Public, AliceKeys.Secret);
            var locked = locker.Lock(MESSAGE);

            var unlocked = locked.UnlockString(AliceKeys.Public, BobKeys.Secret);

            Assert.AreEqual(MESSAGE, unlocked);
        }

        [TestMethod]
        public void KeyCreationTest()
        {
            var AliceKeys = new KeyPair(new PrivateSecretKey(K_PRI_ALICE));
            
            CollectionAssert.AreEqual(K_PUB_ALICE, AliceKeys.Public.Bytes);
        }

        [TestMethod]
        public void RoundTripTest_Tampered()
        {
            var AliceKeys = new KeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));
            var BobKeys = new KeyPair(new PrivateSecretKey(K_PRI_BOB), new PublicKey(K_PUB_BOB));

            var locker = new SharedLocker(BobKeys.Public, AliceKeys.Secret);
            var locked = locker.Lock(MESSAGE);

            for (int i = 0; i < 5; i++)
                locked.Cipher[i] = 0;
            
            Assert.ThrowsException<CryptographicException>(() 
                => locked.UnlockString(AliceKeys.Public, BobKeys.Secret));
        }

        [TestMethod]
        public void RoundTripTest_WrongKeys()
        {
            var AliceKeys = new KeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));
            var BobKeys = new KeyPair(new PrivateSecretKey(K_PRI_BOB), new PublicKey(K_PUB_BOB));

            var locker = new SharedLocker(BobKeys.Public, AliceKeys.Secret);
            var locked = locker.Lock(MESSAGE);
           
            //Try to decrypt with alice key
            Assert.ThrowsException<CryptographicException>(() 
                => locked.UnlockString(AliceKeys.Public, AliceKeys.Secret));
        }

        [TestMethod]
        public void NullParameterTest()
        {
            var keyPair = new KeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));

            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocker(null, null));
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocker(keyPair.Public, null));
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocker(null, keyPair.Secret));

            var sharedLocker = new SharedLocker(keyPair.Public, keyPair.Secret);

            Assert.ThrowsException<ArgumentNullException>(() => sharedLocker.Lock(str: null));
            Assert.ThrowsException<ArgumentNullException>(() => sharedLocker.Lock(str: ""));
            Assert.ThrowsException<ArgumentNullException>(() => sharedLocker.Lock(data: null));
            Assert.ThrowsException<ArgumentNullException>(() => sharedLocker.Lock(data: new byte[0]));
        }

        [TestMethod]
        public void NullParameterLockedTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Signature(null));
            Assert.ThrowsException<ArgumentNullException>(() => new Signature(new byte[0]));
        }

        [TestMethod]
        public void NullParameterKeyTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new KeyPair(null));
            Assert.ThrowsException<ArgumentNullException>(() => new KeyPair(null, null));
            Assert.ThrowsException<ArgumentNullException>(() => new KeyPair(new PrivateSecretKey(K_PRI_ALICE), null));
            Assert.ThrowsException<ArgumentNullException>(() => new KeyPair(null, new PublicKey(K_PUB_ALICE)));  
        }

        [TestMethod]
        public void NullParamterLockedTest()
        {
            var nonce = new Utils.Nonce();
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocked(new byte[0], nonce));
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocked(null, nonce));
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocked(K_PUB_BOB, null));
            Assert.ThrowsException<ArgumentNullException>(() => new SharedLocked(null, null));

            var l = new SharedLocked(K_PUB_BOB, nonce);
            var keyPair = new KeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));

            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockBytes(null, keyPair.Secret));
            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockBytes(keyPair.Public, null));
            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockBytes(null, null));
            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockString(null, keyPair.Secret));
            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockString(keyPair.Public, null));
            Assert.ThrowsException<ArgumentNullException>(() => l.UnlockString(null, null));

        }
    }
}
