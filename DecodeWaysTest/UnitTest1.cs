using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecodeWays;

namespace DecodeWaysTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("12");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("226");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("10");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("0");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("1");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("1010");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("210010");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            for (int i = 1; i <= 10; i++)
            {
                var result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 1);
            }

            for (int i = 11; i <= 19; i++)
            {
                var result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 2);
            }

            for (int i = 21; i <= 26 ; i++)
            {
                var result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 2);
            }

        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();

            for (int i = 27; i <= 99; i++)
            {
                if (i % 10 == 0)
                    continue;

                var result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 1);
            }

        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.NumDecodings(100.ToString()), 0);

            for (int i = 101; i <= 109; i++)
            {
                var result1 = s.NumDecodings(i.ToString());
                Assert.AreEqual(result1, 1);
            }

            var result = s.NumDecodings(110.ToString());
            Assert.AreEqual(result, 1);

            for (int i = 111; i <= 119; i++)
            {
                result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 3);
            }

            result = s.NumDecodings(120.ToString());
            Assert.AreEqual(result, 1);

            for (int i = 121; i <= 126; i++)
            {
                result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 3);
            }

            for (int i = 127; i <= 129; i++)
            {
                result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 2);
            }

            for (int i = 10111; i <= 10119; i++)
            {
                result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 3);
            }

            for (int i = 10111; i <= 10119; i++)
            {
                result = s.NumDecodings("0"+i.ToString());
                Assert.AreEqual(result, 0);
            }

            for (int i = 11111; i <= 11119; i++)
            {
                result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 8);
            }

        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("2611055971756562");
            //Assert.AreEqual(result, 1);
        }

        //"2611055971756562"
    }
}
