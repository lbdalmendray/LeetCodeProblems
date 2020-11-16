using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowXN;

namespace PowXNTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MyPow(2.00000, 10);
            Assert.IsTrue(Math.Abs(result - 1024.00000) < 0.00001);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MyPow(2.10000, 3);
            Assert.IsTrue(Math.Abs(result - 9.26100) < 0.00001);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             2.00000, -2
Output: 0.25000
             */
            Solution s = new Solution();
            var result = s.MyPow(2.00000, -2);
            Assert.IsTrue(Math.Abs(result - 0.25000) < 0.00001);
        }

        [TestMethod]
        public void TestMethod4()
        {

            Solution s = new Solution();
            for (int i = 2; i < 20; i++)
            {
                for (int j = 1; j < 10 ; j++)
                {
                    var result = s.MyPow(i, j);
                    Assert.IsTrue(Math.Abs(result - Math.Pow(i,j)) < 0.00001, i.ToString() + " " + j.ToString());

                    result = s.MyPow(i, -j);
                    Assert.IsTrue(Math.Abs(result - Math.Pow(i, -j)) < 0.00001, i.ToString() + " " + (-j).ToString());

                    result = s.MyPow(-i, -j);
                    Assert.IsTrue(Math.Abs(result - Math.Pow(-i, -j)) < 0.00001, (-i).ToString() + " " + (-j).ToString());

                    result = s.MyPow(-i, j);
                    Assert.IsTrue(Math.Abs(result - Math.Pow(-i, j)) < 0.00001, (-i).ToString() + " " + j.ToString());
                }                
            }
            
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MyPow(-2, -1);
            Assert.IsTrue(Math.Abs(result - Math.Pow(-2, -1)) < 0.00001);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.MyPow(1.00000, -2147483648);
            Assert.IsTrue(Math.Abs(result - Math.Pow(1.00000, 2147483648)) < 0.00001);
        }
    }
}
