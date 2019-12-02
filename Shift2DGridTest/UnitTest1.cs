using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Shift2DGrid.Class1;

namespace Shift2DGridTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             * 
[[1,2,3],[4,5,6],[7,8,9]]   
    */

            Solution s = new Solution();
            var result  = s.ShiftGrid(new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{ 7, 8, 9 }
            },10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             * 
[[1,2,3],[4,5,6],[7,8,9]]   
    */

            Solution s = new Solution();
            var result = s.ShiftGrid(new int[][]
            {
                new int[]{1,2},
            }, 11);
        }
    }
}
