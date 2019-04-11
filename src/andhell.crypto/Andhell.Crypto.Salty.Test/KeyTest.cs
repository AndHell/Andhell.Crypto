using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andhell.Crypto.Salty.Test
{
    [TestClass]
    public class KeyTest
    {
        [TestMethod]
        public void DPAPIRoundTripCheck()
        {
            var key = new Key();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var storeable = key.Storable();
                var key2 = new Key(storeable);

                CollectionAssert.AreEqual(key.Bytes, key2.Bytes);
            }
            else
            {
                Assert.ThrowsException<NotImplementedException>(() => key.Storable());
            }
        }

        [TestMethod]
        public void DPAPIRoundTripCheck_Tampered()
        {
            var key = new Key();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var storeable = key.Storable();

                for (int i = 0; i < 5; i++)
                    storeable.ProtectedBytes[i] = 0;

                try
                {
                    var key2 = new Key(storeable);
                    Assert.Fail();
                }
                catch (Exception)
                {
                    // tampered message detected
                } 
            }
            else
            {
                Assert.ThrowsException<NotImplementedException>(() => key.Storable());
            }
        }
    }
}
