using System;
using AllOoneDataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AllOoneDataStructureTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
        }

        [TestMethod]
        public void TestMethod2()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k1");
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
        }

        [TestMethod]
        public void TestMethod4()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k2");
        }
        [TestMethod]
        public void TestMethod5()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k2");
            s.Inc("k2");
            Assert.IsTrue(s.GetMaxKey() == "k1" || s.GetMaxKey() == "k2");
            Assert.IsTrue(s.GetMinKey() == "k1" || s.GetMinKey() == "k2");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k2");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k2");
            s.Dec("k2");
            s.Dec("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k1");
            s.Dec("k1");
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
        }

        [TestMethod]
        public void TestMethod6()
        {
            AllOne s = new AllOne();
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k2");
            s.Inc("k2");
            Assert.IsTrue(s.GetMaxKey() == "k1" || s.GetMaxKey() == "k2");
            Assert.IsTrue(s.GetMinKey() == "k1" || s.GetMinKey() == "k2");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k2");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k2");
            s.Dec("k2");
            s.Dec("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Dec("k1");
            s.Dec("k1");
            Assert.AreSame(s.GetMaxKey(), "");
            Assert.AreSame(s.GetMinKey(), "");

            //// 
            ///

            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k1");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k1");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k1");
            Assert.AreSame(s.GetMinKey(), "k2");
            s.Inc("k2");
            Assert.IsTrue(s.GetMaxKey() == "k1" || s.GetMaxKey() == "k2");
            Assert.IsTrue(s.GetMinKey() == "k1" || s.GetMinKey() == "k2");
            s.Inc("k2");
            Assert.AreSame(s.GetMaxKey(), "k2");
            Assert.AreSame(s.GetMinKey(), "k1");

            s.Inc("k3");
            Assert.AreSame(s.GetMaxKey(), "k2");
            Assert.AreSame(s.GetMinKey(), "k3");
            s.Inc("k3");
            s.Inc("k3");
            s.Inc("k3");
            Assert.AreSame(s.GetMaxKey(), "k3");
            Assert.AreSame(s.GetMinKey(), "k1");
        }
    }
}
