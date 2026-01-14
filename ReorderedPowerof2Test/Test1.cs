using ReorderedPowerof2;

namespace ReorderedPowerof2Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution2 solution = new Solution2();

            foreach (var numberString in new string[] { "1", "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768", "65536", "131072", "262144", "524288", "1048576", "2097152", "4194304", "8388608", "16777216", "33554432", "67108864", "134217728", "268435456", "536870912"/*, "1073741824"*/ })
            {
                var number = int.Parse(numberString);
                var result = solution.ReorderedPowerOf2(number);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution2 solution = new Solution2();

            foreach (var numberString in new string[] { "3", "5", "6", "7", "9", "10", "11", "12" })
            {
                var number = int.Parse(numberString);
                var result = solution.ReorderedPowerOf2(number);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution2 solution = new Solution2();

            foreach (var numberString in new string[] { "135", "153" ,"315" ,"351" ,"513", "531" })
            {
                var number = int.Parse(numberString);
                var result = solution.ReorderedPowerOf2(number);
                Assert.IsFalse(result);
            }
        }
    }
}
