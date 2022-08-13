using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextClosestTime;

namespace NextClosestTimeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
                Input: time = "19:34"
                Output: "19:39"
            */

            Solution2 solution = new Solution2();
            var result = solution.NextClosestTime("19:34");
            Assert.AreEqual(result, "19:39");
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
                Input: time = "23:59"
                Output: "22:22"
            */

            Solution2 solution = new Solution2();
            var result = solution.NextClosestTime("23:59");
            Assert.AreEqual(result, "22:22");
        }
    }
}
