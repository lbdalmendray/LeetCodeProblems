using ReorderedPowerof2;

namespace ReorderedPowerof2Test
{
    [TestClass]
    public sealed class Test11
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution1 = new Solution();
            Solution solution2 = new Solution();
            for (int i = 1; i < 1000_000; i++)
            {
                var result1 = solution1.ReorderedPowerOf2(i);
                var result2 = solution2.ReorderedPowerOf2(i);
                Assert.AreEqual(result1,result2);
            }            
        }

        
    }
}
