using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperEggDrop;

namespace SuperEggDropTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(1, 2);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 6);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 5);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(3, 14); // ( 7 ) | ( 4 | 3 ) 
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(100, 10000);  // ( 500 ) | ( 255 | ( 128 | ( 64 |  ( 32 | ( 16 | ( 8 | ( 4 | ( 3=R(2) ) ) ) ) ) ) ) )
            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(90, 100);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(89, 49);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(89, 25);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(89, 13);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(89, 7);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(89, 4);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(88, 3);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 9);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 5);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(5, 17);
            Assert.AreEqual(result, 5);
        }


        [TestMethod]
        public void TestMethod16()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(3, 25);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod17()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 10);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod18()
        {
            Solution s = new Solution();
            for (int k = 1; k <= 10; k++)
            {
                for (int i = 1; i <= 200; i++)
                {
                    var result = s.SuperEggDrop(k, i);
                    var result1 = SuperEggDrop(k, i);
                    Assert.AreEqual(result, result1, "k: "+ k + " N:" + i);
                }
            }            
        }

        [TestMethod]
        public void TestMethod19()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(2, 20);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod20()
        {
            Solution s = new Solution();
            for (int i = 1; i <= 500; i++)
            {
                double kDouble = Math.Log(i+1, 2);
                int k = (int)kDouble;
                if (k < kDouble)
                    k++;
                var result = k;
                var result1 = SuperEggDrop(k, i);
                Assert.AreEqual(result, result1, "k: " + k + " N:" + i);
            }            
        }

        [TestMethod]
        public void TestMethod21()
        {
            Solution s = new Solution();

            /**/
            for (int k = 2; k <= 10; k++)
            {
                for (int i = 1; i <= 500; i++)
                {
                    double kDouble = Math.Log(i + 1, 2);
                    int kMax = (int)kDouble;
                    if (kMax < kDouble)
                        kMax++;
                    var result = kMax - (k >= kMax ? kMax : k) + 1;
                    result = ((int)Math.Pow(2, result)) - 1;
                    var result1 = SuperEggDrop(k, i);
                    //Assert.AreEqual(result, result1, "k: " + kMax + " N:" + i);
                }
            }
        }

        [TestMethod]
        public void TestMethod22()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(5, 2000);
            Assert.AreEqual(result, 13);
        }

        [TestMethod]
        public void TestMethod23()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(8, 10000);
            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void TestMethod24()
        {
            Solution s = new Solution();
            var result = s.SuperEggDrop(9, 10000);
            Assert.AreEqual(result, 14);
        }

        public int SuperEggDrop(int K, int N)
        {
            int?[,] infos = new int?[K + 1, N + 2];
            for (int j = 2; j <= K; j++)
            {
                for (int i = 0; i <= N; i++)
                {

                    SuperEggDrop(j, 0, i, infos);

                }
            }
            return SuperEggDrop(K, 0, N, infos);
        }

        private int SuperEggDrop(int k, int index1, int index2, int?[,] infos)
        {
            int length = index2 - index1 + 1;

            if (infos[k, length].HasValue)
                return infos[k, length].Value;

            int result;

            if (k == 1)
            {
                result = length - 1;
            }
            else if (index1 == index2)
            {
                result = 0;
            }
            else if (index1 == index2 - 1)
            {
                result = 1;
            }
            else
            {
                result = 1 + SuperEggDrop(k - 1, index1, index1, infos);
                result = Math.Max(result, 1 + SuperEggDrop(k, index1 + 1, index2, infos));
                //int iBestValue = index1;
                for (int i = index1 + 2; i <= index2; i++)
                {
                    var cResult = 1 + SuperEggDrop(k - 1, index1, i - 1, infos);
                    cResult = Math.Max(cResult, 1 + SuperEggDrop(k, i, index2, infos));

                    if (cResult < result)
                    {
                        result = cResult;
                        //iBestValue = i;
                    }
                }
            }
            infos[k, length] = result;
            return result;
        }
    }
}
