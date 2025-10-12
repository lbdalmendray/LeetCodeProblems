using System;
using FindWinneronaTicTacToeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace FindWinneronaTicTacToeGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0],[2,0],[1,1],[2,1],[2,2]]");
            Solution s = new Solution();
            var result = s.Tictactoe(input);

            Assert.AreEqual(result, "A");

        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]");
            Solution s = new Solution();
            var result = s.Tictactoe(input);

            Assert.AreEqual(result, "B");

        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]");
            Solution s = new Solution();
            var result = s.Tictactoe(input);

            Assert.AreEqual(result, "Draw");

        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0],[1,1]]");
            Solution s = new Solution();
            var result = s.Tictactoe(input);

            Assert.AreEqual(result, "Pending");

        }

        /*  
      [[1,0],[0,0],[0,2],[1,1],[1,2],[0,1]]   
    */

        [TestMethod]
        public void TestMethod5()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[1,0],[0,0],[0,2],[1,1],[1,2],[0,1]]");
            Solution s = new Solution();
            var result = s.Tictactoe(input);

            Assert.AreEqual(result, "Pending");

        }
    }
}
