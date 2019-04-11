using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class SignerTest
    {
        readonly byte[] K_PUB_ALICE = new byte[] { 104, 250, 198, 187, 189, 170, 210, 117, 241, 78, 12, 40, 233, 238, 53, 180, 112, 211, 122, 102, 48, 52, 226, 142, 70, 203, 164, 248, 70, 153, 26, 53 };
        readonly byte[] K_PRI_ALICE = new byte[] { 236, 94, 65, 236, 161, 189, 30, 199, 76, 168, 64, 167, 245, 180, 11, 119, 172, 126, 201, 64, 79, 175, 122, 100, 104, 121, 228, 180, 215, 102, 66, 171, 104, 250, 198, 187, 189, 170, 210, 117, 241, 78, 12, 40, 233, 238, 53, 180, 112, 211, 122, 102, 48, 52, 226, 142, 70, 203, 164, 248, 70, 153, 26, 53 };

        readonly byte[] K_PUB_BOB = new byte[] { 35, 189, 91, 55, 6, 189, 150, 237, 56, 170, 65, 145, 121, 22, 220, 173, 252, 125, 13, 83, 250, 75, 186, 207, 231, 176, 127, 65, 115, 145, 72, 100 };

        const string MESSAGE = "eine kuh macht muh, viele kühe machen mühe";
        const string MESSAGE_CHANGED = "eine kuh macht muh, viele keuhe machen auch muehe";

        [TestMethod]
        public void RoundTripTest()
        {
            var AliceKeys = new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));

            var pen = new Signer(AliceKeys.Secret);

            var signature = pen.Sign(MESSAGE);

            Assert.IsTrue(signature.Verify(MESSAGE, AliceKeys.Public));
        }

        [TestMethod]
        public void RoundTripTest_WrongKey()
        {
            var AliceKeys = new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));
            var BobsPubKey = new PublicKey(K_PUB_BOB);

            var pen = new Signer(AliceKeys.Secret);

            var signature = pen.Sign(MESSAGE);

            Assert.IsFalse(signature.Verify(MESSAGE, BobsPubKey));
        }

        [TestMethod]
        public void RoundTripTest_WrongMessage()
        {
            var AliceKeys = new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));
            var BobsPubKey = new PublicKey(K_PUB_BOB);

            var pen = new Signer(AliceKeys.Secret);

            var signature = pen.Sign(MESSAGE);

            Assert.IsFalse(signature.Verify(MESSAGE_CHANGED, BobsPubKey));
        }

        [TestMethod]
        public void RoundTripTest_Tampered()
        {
            var AliceKeys = new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));

            var pen = new Signer(AliceKeys.Secret);

            var signature = pen.Sign(MESSAGE);

            for (int i = 0; i < 5; i++)
                signature.Bytes[i] = 0;

            Assert.IsFalse(signature.Verify(MESSAGE, AliceKeys.Public));
        }

        [TestMethod]
        public void NullParamterTest()
        {
            var keyPair = new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), new PublicKey(K_PUB_ALICE));

            Assert.ThrowsException<ArgumentNullException>(() => new Signer(null));

            var pen = new Signer(keyPair.Secret);

            Assert.ThrowsException<ArgumentNullException>(() => pen.Sign(str: null));
            Assert.ThrowsException<ArgumentNullException>(() => pen.Sign(str: ""));
            Assert.ThrowsException<ArgumentNullException>(() => pen.Sign(data: null));
            Assert.ThrowsException<ArgumentNullException>(() => pen.Sign(data: new byte[0]));
        }

        [TestMethod]
        public void NullParamterSignatureTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Signature(new byte[0]));
            Assert.ThrowsException<ArgumentNullException>(() => new Signature(null));
        }

        [TestMethod]
        public void NullParamterSignatureKeyTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new SigningKeyPair(null));
            Assert.ThrowsException<ArgumentNullException>(() => new SigningKeyPair(null, null));
            Assert.ThrowsException<ArgumentNullException>(() => new SigningKeyPair(new PrivateSecretKey(K_PRI_ALICE), null));
            Assert.ThrowsException<ArgumentNullException>(() => new SigningKeyPair(null, new PublicKey(K_PUB_ALICE)));
        }
    }
}
