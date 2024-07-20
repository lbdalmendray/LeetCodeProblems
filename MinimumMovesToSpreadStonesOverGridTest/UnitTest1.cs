using MinimumMovesToSpreadStonesOverGrid;

namespace MinimumMovesToSpreadStonesOverGridTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Solution solution = new Solution();
        int result = solution.MinimumMoves([[1, 1, 0], [1, 1, 1], [1, 2, 1]]);
        Assert.AreEqual(result, 3);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Solution solution = new Solution();
        int result = solution.MinimumMoves([[1, 3, 0], [1, 0, 0], [1, 0, 3]]);
        Assert.AreEqual(result, 4);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Solution solution = new Solution();
        int result = solution.MinimumMoves([[9, 0, 0], [0, 0, 0], [0, 0, 0]]);
        Assert.AreEqual(result, 1+2 + 1+2+3 + 2+3+4);
    }

    [TestMethod]
    public void TestMethod4()
    {
        Solution solution = new Solution();
        int result = solution.MinimumMoves([[2, 1, 1], [0, 2, 0], [1, 1, 1]]);
        Assert.AreEqual(result, 2);
    }
}