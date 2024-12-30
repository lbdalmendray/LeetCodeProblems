using ReverseInteger;

namespace ReverseIntegerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(123);
            Assert.AreEqual(result, 321);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(-123);
            Assert.AreEqual(result, -321);
        }

        [TestMethod]
        public void TestMethod3()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(120);
            Assert.AreEqual(result, 21);
        }

        [TestMethod]
        public void TestMethod4()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(2147483647);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(-2147483647);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(-2147483648);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod7()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(-1111111122);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod8()
        {
            ReverseInteger.Solution s = new ReverseInteger.Solution();
            var result = s.Reverse(1111111122);
            Assert.AreEqual(result, 0);
        }
    }
}