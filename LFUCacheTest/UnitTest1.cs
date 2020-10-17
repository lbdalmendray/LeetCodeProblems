using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LFUCacheTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LFUCache.LFUCache cache = new LFUCache.LFUCache(2 /* capacity */ );
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Get(3);       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
        }
    }
}
