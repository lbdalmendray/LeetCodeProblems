using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoSumIIIDatastructuredesign;

namespace TwoSumIIIDatastructuredesignTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TwoSum s = new TwoSum();
            s.Add(1); 
            s.Add(3);
            s.Add(5);
            Assert.IsTrue(s.Find(4));
            Assert.IsFalse(s.Find(7));
        }

        [TestMethod]
        public void TestMethod2()
        {
            TwoSum s = new TwoSum();
            s.Add(3);
            s.Add(1);
            s.Add(2);
            Assert.IsTrue(s.Find(3));
            Assert.IsFalse(s.Find(6));
        }

        [TestMethod]
        public void TestMethod3()
        {
            TwoSum s = new TwoSum();
            s.Add(0);
            s.Add(-1);
            s.Add(1);
            Assert.IsTrue(s.Find(0));
        }
    }
}
