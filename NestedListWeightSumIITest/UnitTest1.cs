using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NestedListWeightSumII;

namespace NestedListWeightSumIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // [[1,1],2,[1,1]]
            List<NestedInteger> list = new List<NestedInteger>();
            NestedInteger ni = new NestedInteger();
            ni.Add(new NestedInteger(1));
            ni.Add(new NestedInteger(1));
            list.Add(ni);
            list.Add(new NestedInteger(2));
            ni = new NestedInteger();
            ni.Add(new NestedInteger(1));
            ni.Add(new NestedInteger(1));
            list.Add(ni);

            Solution s = new Solution();
            var result = s.DepthSumInverse(list);
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<NestedInteger> list = new List<NestedInteger>();
            NestedInteger ni = new NestedInteger(1);
            list.Add(ni);
            ni = new NestedInteger();
            ni.Add(new NestedInteger(4));
            var ni2 = new NestedInteger();
            ni2.Add(new NestedInteger(6));
            ni.Add(ni2);
            list.Add(ni);
            Solution s = new Solution();
            var result = s.DepthSumInverse(list);
            Assert.AreEqual(result, 17);
        }
    }
}
