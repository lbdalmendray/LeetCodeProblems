using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LRUCache;

namespace LRUCacheTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LRUCache.LRUCache cache = new LRUCache.LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);           // returns 1
            cache.Put(3, 3);                            // evicts key 2
            Assert.AreEqual(cache.Get(2), -1);          // returns -1 (not found)
            cache.Put(4, 4);                            // evicts key 1
            Assert.AreEqual(cache.Get(1), -1);          // returns -1 (not found)
            Assert.AreEqual(cache.Get(3), 3);           // returns 3
            Assert.AreEqual(cache.Get(4), 4);           // returns 4
        }

        [TestMethod]
        public void TestMethod2()
        {
            LRUCache.LRUCache cache = new LRUCache.LRUCache(0);
            /*
             ["LFUCache","put","get"]
[[0],[0,0],[0]]
             */
            cache.Put(0, 0);
            cache.Get(0);
        }
    }
}
