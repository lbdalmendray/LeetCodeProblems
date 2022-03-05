using KClosestPointstoOrigin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KClosestPointstoOriginTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: points = [[1,3],[-2,2]], k = 1
             Output: [[-2,2]]
             */

            Solution2 s = new Solution2();
            var result = s.KClosest(new int[][]
            {
                new int[]{ 1, 3 },
                new int[]{ -2,2 },
            },1);
            Assert.IsTrue(result != null && result.Length == 1 && result[0].Length == 2);
            Assert.AreEqual(result[0][0], -2);
            Assert.AreEqual(result[0][1], 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: points = [[3,3],[5,-1],[-2,4]], k = 2
                    Output: [[3,3],[-2,4]]
             */

            Solution2 s = new Solution2();
            var result = s.KClosest(new int[][]
            {
                new int[]{ 3,3 },
                new int[]{ 5,-1 },
                new int[]{ -2,4 },
            }, 2);

            Assert.IsTrue(result != null && result.Length == 2);
            foreach (var item in result)
            {
                Assert.IsTrue(item.Length == 2);
            }

            Array.Sort(result, result, Comparer<int[]>.Create((a, b) =>
           {
               if (a[0] == b[0])
                   return a[1] - b[1];
               return a[0] - b[0];
           }));

            Assert.AreEqual(result[0][0], -2);
            Assert.AreEqual(result[0][1], 4);

            Assert.AreEqual(result[1][0], 3);
            Assert.AreEqual(result[1][1], 3);
        }
    }
}
