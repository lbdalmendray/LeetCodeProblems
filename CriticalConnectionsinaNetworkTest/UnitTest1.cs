using CriticalConnectionsinaNetwork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CriticalConnectionsinaNetworkTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: n = 4, connections = [[0,1],[1,2],[2,0],[1,3]]
Output: [[1,3]]
Explanation: [[3,1]] is also accepted.
             */
            Solution solution = new Solution();
            var result = solution.CriticalConnections(4, new int[][]
                {
                    new int[]{0,1},
                    new int[]{ 1, 2 },
                    new int[]{ 2,0 },
                    new int[]{ 1, 3 }
                });
        }
    }
}
