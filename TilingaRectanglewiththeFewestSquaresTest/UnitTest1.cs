using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TilingaRectanglewiththeFewestSquares;

namespace TilingaRectanglewiththeFewestSquaresTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(2,3);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(5, 8);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(3, 9);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(11, 13);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(6, 6);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(12, 13);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution1 s = new Solution1();
            var result = s.TilingRectangle(1, 1);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution1 s = new Solution1();
            for (int i = 1; i <= 13; i++)
            {
                var result = s.TilingRectangle(1, i);
                Assert.AreEqual(result, i);
            }

            for (int i = 1; i <= 13; i++)
            {
                var result = s.TilingRectangle(i, 1);
                Assert.AreEqual(result, i);
            }
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution1 s = new Solution1();
            for (int i = 1; i <= 13; i++)
            {
                var result = s.TilingRectangle(i, i);
                Assert.AreEqual(result, 1);
            }
        }
    }
}
