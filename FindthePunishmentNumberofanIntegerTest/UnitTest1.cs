using FindthePunishmentNumberofanInteger;

namespace FindthePunishmentNumberofanIntegerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.PunishmentNumber(1000);
            Assert.AreEqual(result, 10804657);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.PunishmentNumber(999);
            Assert.AreEqual(result, 9804657);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.PunishmentNumber(1);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.PunishmentNumber(17);
            Assert.AreEqual(result, 182);
        }
    }
}