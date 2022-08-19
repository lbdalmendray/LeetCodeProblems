using MaximalSquare;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximalSquareTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MaximalSquare(new char[][]
            {
                new char[]{ '1', '0', '1', '0', '0' },
                new char[]{ '1', '0', '1', '1', '1' },
                new char[]{ '1', '1', '1', '1', '1' },
                new char[]{ '1', '0', '0', '1', '0' },
            });
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MaximalSquare(new char[][]
            {
                new char[]{ '0', '1'},
                new char[]{ '1', '0'},
            });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MaximalSquare(new char[][]
            {
                new char[]{ '0'},
            });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MaximalSquare(new char[][]
            {
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
            });
            Assert.AreEqual(result, 49);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.MaximalSquare(new char[][]
            {
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '0', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '1', '1', '1', '1', '1', '1', '1', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '1', '1', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                new char[]{ '0', '0', '0', '0', '0', '0', '0', '0', '0' },
            });
            Assert.AreEqual(result, 9);
        }
    }
}