using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reconstructa2_RowBinaryMatrix;

namespace Reconstructa2_RowBinaryMatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            s.ReconstructMatrix(5, 5, new int[] { 2, 1, 2, 0, 1, 0, 1, 2, 0, 1 }) ;
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             
    9
2
[0,1,2,0,0,0,0,0,2,1,2,1,2]
    */


            Solution s = new Solution();
            s.ReconstructMatrix(9, 2, new int[] { 0, 1, 2, 0, 0, 0, 0, 0, 2, 1, 2, 1, 2 });
        }
    }
}
