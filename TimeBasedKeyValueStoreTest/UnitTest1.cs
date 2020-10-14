using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeBasedKeyValueStore;

namespace TimeBasedKeyValueStoreTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TimeMap kv = new TimeMap();
            kv.Set("foo", "bar", 1);
            var result = kv.Get("foo", 1);
            Assert.AreEqual(result, "bar");

            result = kv.Get("foo", 3);
            Assert.AreEqual(result, "bar");

            kv.Set("foo", "bar2", 4);
            result = kv.Get("foo", 4);
            Assert.AreEqual(result, "bar2");

            result = kv.Get("foo", 5);
            Assert.AreEqual(result, "bar2");

        }
    }
}
