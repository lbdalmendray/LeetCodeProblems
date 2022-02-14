using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotBoundedInCircle;

namespace RobotBoundedInCircleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.IsRobotBounded("GGLLGG");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.IsRobotBounded("GG");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.IsRobotBounded("GL");
            Assert.AreEqual(result, true);
        }
    }
}
