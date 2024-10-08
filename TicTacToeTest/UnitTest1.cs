namespace TicTacToeTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        TicTacToe.TicTacToe ticTacToe = new TicTacToe.TicTacToe(3);

        var result = ticTacToe.Move(0, 0, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(0, 2, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 2, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(1, 1, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 0, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(1, 0, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 1, 1);
        Assert.AreEqual(result, 1);

    }

    [TestMethod]
    public void TestMethod2()
    {
        TicTacToe.TicTacToe ticTacToe = new TicTacToe.TicTacToe(4);

        var result = ticTacToe.Move(1, 1, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 1, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 2, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(1, 2, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(3, 1, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(0, 3, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(3, 3, 1);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(2, 0, 2);
        Assert.AreEqual(result, 0);

        result = ticTacToe.Move(0, 0, 1);
        Assert.AreEqual(result, 1);
    }
}