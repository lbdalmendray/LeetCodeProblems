using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumNumberofFlipstoConvertBinaryMatrixtoZeroMatrix;

namespace MinimumNumberofFlipstoConvertBinaryMatrixtoZeroMatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.GetNumber(new bool[,]
            {
                {true,false,false },
                {false,false,false },
                {false,false,false }
            });

            Assert.AreEqual(result, (uint)1);

            result = s.GetNumber(new bool[,]
            {
                {false,false,false },
                {false,false,false },
                {false,false,false }
            });

            Assert.AreEqual(result, (uint)0);

            result = s.GetNumber(new bool[,]
            {
                {false,true,false },
                {false,false,false },
                {false,false,false }
            });

            Assert.AreEqual(result, (uint)2);


            result = s.GetNumber(new bool[,]
            {
                {false,true,true },
                {false,false,false },
                {false,false,false }
            });

            Assert.AreEqual(result, (uint)6);

            result = s.GetNumber(new bool[,]
            {
                {false,false,false },
                {false,false,false },
                {false,false,true }
            });

            Assert.AreEqual(result, (uint)(Math.Pow(2,8)));

            result = s.GetNumber(new bool[,]
            {
                {true,true,true },
                {true,true,true },
                {true,true,true }
            });

            Assert.AreEqual(result, (uint)(Math.Pow(2, 9)-1));

        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            int n = 3;
            int m = 3;
            var result = s.GetRect(0,3,3);
            var positionsTrue = new int[][] { /* new int[] { } */ };
            foreach (var item in positionsTrue )
            {
                Assert.IsTrue(result[item[0], item[1]]);
            }

            var positions = new LinkedList<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (positionsTrue.All(e => e[0] != i && e[1] != j))
                        positions.AddLast(new int[] { i, j });
                }
            }

            foreach (var item in positions)
            {
                Assert.IsFalse(result[item[0], item[1]]);
            }

        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            int n = 3;
            int m = 3;
            var result = s.GetRect(1, 3, 3);
            var positionsTrue = new int[][] {  new int[] { 0,0 }  };
            foreach (var item in positionsTrue)
            {
                Assert.IsTrue(result[item[0], item[1]]);
            }

            var positions = new LinkedList<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (positionsTrue.All(e => e[0] != i && e[1] != j))
                        positions.AddLast(new int[] { i, j });
                }
            }

            foreach (var item in positions)
            {
                Assert.IsFalse(result[item[0], item[1]]);
            }

        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            int n = 3;
            int m = 3;
            var result = s.GetRect(6, 3, 3);
            var positionsTrue = new int[][] { new int[] { 0, 1 } , new int[] { 0, 2 } };
            foreach (var item in positionsTrue)
            {
                Assert.IsTrue(result[item[0], item[1]]);
            }

            var positions = new LinkedList<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (positionsTrue.All(e => e[0] != i && e[1] != j))
                        positions.AddLast(new int[] { i, j });
                }
            }

            foreach (var item in positions)
            {
                Assert.IsFalse(result[item[0], item[1]]);
            }

        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            int n = 3;
            int m = 3;
            var result = s.GetRect(14, 3, 3);
            var positionsTrue = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } ,  new int[] { 1, 0 } };
            foreach (var item in positionsTrue)
            {
                Assert.IsTrue(result[item[0], item[1]]);
            }

            var positions = new LinkedList<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (positionsTrue.All(e => e[0] != i && e[1] != j))
                        positions.AddLast(new int[] { i, j });
                }
            }

            foreach (var item in positions)
            {
                Assert.IsFalse(result[item[0], item[1]]);
            }

        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            int n = 3;
            int m = 3;
            var result = s.GetRect(256, 3, 3);
            var positionsTrue = new int[][] { new int[] { 2, 2 } };
            foreach (var item in positionsTrue)
            {
                Assert.IsTrue(result[item[0], item[1]]);
            }

            var positions = new LinkedList<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (positionsTrue.All(e => e[0] != i && e[1] != j))
                        positions.AddLast(new int[] { i, j });
                }
            }

            foreach (var item in positions)
            {
                Assert.IsFalse(result[item[0], item[1]]);
            }

        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 1 } });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 1,0 } });
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // [[1,1,1],[1,0,1],[0,0,0]]
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 1, 1, 1 } , new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 } });
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod11()
        {
            // [[1,0,0],[1,0,0]]
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 1, 0,0 }, new int[] { 1,0,0 }});
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod12()
        {
            // [[1,0,0],[1,0,0]]
            Solution s = new Solution();
            var result = s.MinFlips(new int[][] { new int[] { 1, 0, 0 }, new int[] { 1, 0, 0 }, new int[] { 1, 0, 0 } });
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod13()
        {
            // [[1,0,0],[1,0,0]]
            Solution s = new Solution();
            for (int i = 1; i <= 3; i++)
            {
                var result = s.MinFlips( new int[][] { Enumerable.Repeat(0, i).ToArray() });
                Assert.AreEqual(result, 0);
            }
            
        }

    }
}
