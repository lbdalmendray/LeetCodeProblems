using DesignHitCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignHitCounterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HitCounter hitCounter = new HitCounter();
            hitCounter.Hit(1);
            hitCounter.Hit(2);
            hitCounter.Hit(3);
            Assert.AreEqual(hitCounter.GetHits(4),3);   // get hits at timestamp 4, return 3.
            hitCounter.Hit(300);     // hit at timestamp 300.
            Assert.AreEqual(hitCounter.GetHits(300),4); // get hits at timestamp 300, return 4.
            Assert.AreEqual(hitCounter.GetHits(301),3); // get hits at timestamp 301, return 3.
        }

        [TestMethod]
        public void TestMethod2()
        {
            HitCounter hitCounter = new HitCounter();
            hitCounter.Hit(1);
            hitCounter.Hit(1);
            hitCounter.Hit(2);
            hitCounter.Hit(2);
            hitCounter.Hit(3);
            hitCounter.Hit(3);
            Assert.AreEqual(hitCounter.GetHits(4), 6);   // get hits at timestamp 4, return 3.
            hitCounter.Hit(300);     // hit at timestamp 300.
            hitCounter.Hit(300);     // hit at timestamp 300.
            Assert.AreEqual(hitCounter.GetHits(300), 8); // get hits at timestamp 300, return 4.
            Assert.AreEqual(hitCounter.GetHits(301), 6); // get hits at timestamp 301, return 3.
        }
    }
}