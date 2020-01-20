using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidSudoku;

namespace ValidSudokuTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            char[][] board = new char[][]{
                    new char[] {'5','3','.','.','7','.','.','.','.'},
                    new char[] {'6','.','.','1','9','5','.','.','.'},
                    new char[] {'.','9','8','.','.','.','.','6','.'},
                    new char[] {'8','.','.','.','6','.','.','.','3'},
                    new char[] {'4','.','.','8','.','3','.','.','1'},
                    new char[] {'7','.','.','.','2','.','.','.','6'},
                    new char[] {'.','6','.','.','.','.','2','8','.'},
                    new char[] {'.','.','.','4','1','9','.','.','5'},
                    new char[] {'.','.','.','.','8','.','.','7','9'}
                   };

            Solution s = new Solution();
            Assert.IsTrue(s.IsValidSudoku(board));
        }

        [TestMethod]
        public void TestMethod2()
        {
            char[][] board = new char[][]{
                    new char[] {'5','3','.','.','7','.','.','.','.'},
                    new char[] {'6','.','.','1','9','5','.','.','.'},
                    new char[] {'.','9','8','.','.','.','.','6','.'},
                    new char[] {'8','.','.','.','6','.','.','.','3'},
                    new char[] {'4','.','.','8','.','3','.','.','1'},
                    new char[] {'7','.','.','8','2','.','.','.','6'},
                    new char[] {'.','6','.','.','.','.','2','8','.'},
                    new char[] {'.','.','.','4','1','9','.','.','5'},
                    new char[] {'.','.','.','.','8','.','.','7','9'}
                   };

            Solution s = new Solution();
            Assert.IsFalse(s.IsValidSudoku(board));
        }

        [TestMethod]
        public void TestMethod3()
        {
            char[][] board = new char[][]{
                    new char[] {'5','3','.','.','7','.','.','.','.'},
                    new char[] {'6','9','.','1','9','5','.','.','.'},
                    new char[] {'.','9','8','.','.','.','.','6','.'},
                    new char[] {'8','.','.','.','6','.','.','.','3'},
                    new char[] {'4','.','.','8','.','3','.','.','1'},
                    new char[] {'7','.','.','.','2','.','.','.','6'},
                    new char[] {'.','6','.','.','.','.','2','8','.'},
                    new char[] {'.','.','.','4','1','9','.','.','5'},
                    new char[] {'.','.','.','.','8','.','.','7','9'}
                   };

            Solution s = new Solution();
            Assert.IsFalse(s.IsValidSudoku(board));
        }

        [TestMethod]
        public void TestMethod4()
        {
            char[][] board = new char[][]{
                    new char[] {'5','3','.','.','7','.','.','.','.'},
                    new char[] {'6','.','.','1','9','5','.','.','.'},
                    new char[] {'.','9','8','.','.','.','.','6','.'},
                    new char[] {'8','.','.','.','6','.','.','.','3'},
                    new char[] {'4','.','.','8','.','3','.','.','1'},
                    new char[] {'7','.','.','.','2','.','.','.','6'},
                    new char[] {'.','6','.','.','.','.','2','8','.'},
                    new char[] {'.','.','.','4','1','9','.','.','5'},
                    new char[] {'.','.','7','.','8','.','.','7','9'}
                   };

            Solution s = new Solution();
            Assert.IsFalse(s.IsValidSudoku(board));
        }

        [TestMethod]
        public void TestMethod5()
        {
            char[][] board = new char[][]{
                    new string[] {".", ".", ".", ".", "5", ".", ".", "1", "." }.Select(e=>e[0]).ToArray(),
                    new string[] {".", "4", ".", "3", ".", ".", ".", ".", "." }.Select(e=>e[0]).ToArray(),
                    new string[] {".", ".", ".", ".", ".", "3", ".", ".", "1"}.Select(e=>e[0]).ToArray(),
                    new string[] {"8", ".", ".", ".", ".", ".", ".", "2", "."}.Select(e=>e[0]).ToArray(),
                    new string[] {".", ".", "2", ".", "7", ".", ".", ".", "."}.Select(e=>e[0]).ToArray(),
                    new string[] { ".", "1", "5", ".", ".", ".", ".", ".", "."}.Select(e=>e[0]).ToArray(), 
                    new string[] { ".", ".", ".", ".", ".", "2", ".", ".", "."}.Select(e=>e[0]).ToArray(),
                    new string[] {".", "2", ".", "9", ".", ".", ".", ".", "."}.Select(e=>e[0]).ToArray(),
                    new string[] {".", ".", "4", ".", ".", ".", ".", ".", "."}.Select(e=>e[0]).ToArray()
                   };

            Solution s = new Solution();
            Assert.IsFalse(s.IsValidSudoku(board));
        }
    }
}
