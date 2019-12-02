using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitArrayWithSameAverage;
using Utils;
using System.Security.Cryptography;

namespace SplitArrayWithSameAverageTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.SplitArraySameAverage(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
        }


        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.IsFalse(s.SplitArraySameAverage(new int[] { 1,1,4 }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.SplitArraySameAverage(Enumerable.Repeat(1, 30).ToArray()));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.SplitArraySameAverage(Enumerable.Range(1, 30).ToArray()));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.SplitArraySameAverage(Enumerable.Range(1, 29).ToArray()));
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = Enumerable.Range(10000 - 29, 30).ToArray();
            Solution s = new Solution();
            Assert.IsTrue(s.SplitArraySameAverage(input));
        }


        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            int maximum = 18;
            for (int i = 1; i < 5; i++)
            {
                foreach (var input in GenerateInputs(maximum, i))
                {
                    var result1 = s.SplitArraySameAverage(input);
                    var result2 = SplitArraySameAverageTest(input);
                    Assert.AreEqual(result1, result2);
                }
            }

            for (int i = 1; i < 5; i++)
            {
                foreach (var input in GenerateInputs(18, i).Select(e=>e.Select(e1=>e1+10000).ToArray()))
                {
                    var result1 = s.SplitArraySameAverage(input);
                    var result2 = SplitArraySameAverageTest(input);
                    Assert.AreEqual(result1, result2);
                }
            }

            for (int i = 1; i < 5; i++)
            {
                foreach (var input in GenerateInputs(18, i).Select(e => e.Select(e1 => e1 + 3963).ToArray()))
                {
                    var result1 = s.SplitArraySameAverage(input);
                    var result2 = SplitArraySameAverageTest(input);
                    Assert.AreEqual(result1, result2);
                }
            }

        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();

            foreach (var input in new int[1][] { new int[] { 0, 0, 0, 0, 1 } })
            {
                var result1 = s.SplitArraySameAverage(input);
                var result2 = SplitArraySameAverageTest(input);
                Assert.AreEqual(result1, result2);
            }
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();

            foreach (var input in new int[1][] { new int[] { 0, 0, 0, 1, 2 } })
            {
                var result1 = s.SplitArraySameAverage(input);
                var result2 = SplitArraySameAverageTest(input);
                Assert.AreEqual(result1, result2);
            }
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();

            foreach (var input in new int[1][] { new int[] { 0, 0, 0, 2, 3 } })
            {
                var result1 = s.SplitArraySameAverage(input);
                var result2 = SplitArraySameAverageTest(input);
                Assert.AreEqual(result1, result2);
            }
        }
        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();

            //foreach (var input in GenerateRandom(10000,10,10000))
            foreach (var input in GenerateRandom(1000,10,1000))
            {
                var result1 = s.SplitArraySameAverage(input);
                var result2 = SplitArraySameAverageTest(input);
                Assert.AreEqual(result1, result2,"input:" + ToStringNew(input));
            }
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();

            foreach (var input in new int[1][] { new int[] { 7263 ,4405, 1548, 8692, 5835, 2978, 120, 7264, 4407, 1550 } })
            {
                var result1 = s.SplitArraySameAverage(input);
                var result2 = SplitArraySameAverageTest(input);
                Assert.AreEqual(result1, result2);
            }
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();

            foreach (var input in GenerateRandom(10000,30,1))
            {
                var result1 = s.SplitArraySameAverage(input);
                //var result2 = SplitArraySameAverageTest(input);
                //Assert.AreEqual(result1, result2);
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            /*
             Solution s = new Solution();
            for (int i = 1; i < 29; i++)
            {
                var input = Enumerable.Repeat(-1, 29).ToList();
                input.Add(i);
                //input.Add(i);
                var result1 = s.SplitArraySameAverage(input.ToArray());
                //Assert.IsFalse(result1);
            }
            */
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var input = Enumerable.Repeat(-1, 28).ToList();
            input.Add(1);
            input.Add(1);
            var result1 = s.SplitArraySameAverage(input.ToArray());
        }

        // 7263 4405 1548 8692 5835 2978 120 7264 4407 1550

        private string ToStringNew(int[] input)
        {
            string result = "";
            foreach (var item in input)
            {
                result += " " + item;
            }
            return result;
        }

        private IEnumerable<int[]> GenerateRandom(int maximum, int length,int count)
        {
            for (int i = 1; i <= count; i++)
            {
                LinkedList<int> result = new LinkedList<int>();
                for (int j = 0; j < length; j++)
                {
                    Random r = new Random((int)DateTime.Now.Ticks + j * i);
                    result.AddLast(r.Next(0, maximum + 1));
                }
                yield return result.ToArray();
            }
        }

        private bool SplitArraySameAverageTest(int[] input)
        {
            if ( input.Length == 0)
            {
                return false;
            }
            if (input.Length == 1)
                return true;
            
            foreach (var item in Utils.Utils.GetAllSelections(input.Length))
            {
                LinkedList<int> set1 = new LinkedList<int>();
                LinkedList<int> set2 = new LinkedList<int>();

                int index = 0;
                foreach (var value in item)
                {
                    if (value)
                    {
                        set1.AddLast(index);
                    }
                    else
                    {
                        set2.AddLast(index);
                    }
                    index++;
                }

                if (set1.Count == 0 || set2.Count == 0)
                    continue;

                if (set1.Select(i=>input[i]).Average() == set2.Select(i => input[i]).Average())
                    return true;
            }

            return false;
        }

        private IEnumerable<int[]> GenerateInputs(int maximum, int length)
        {
            int[] currentResult = Enumerable.Range(0, length).ToArray();
            return GenerateInputs(maximum, length, 0, currentResult);
        }

        private IEnumerable<int[]> GenerateInputs(int maximum, int length, int index, int[] currentResult)
        {
            if (index == length)
                yield return currentResult.Select(e => e).ToArray();
            else
            {
                for (int i = 0; i <= maximum; i++)
                {
                    currentResult[index] = i;
                    foreach (var item in GenerateInputs(maximum, length, index + 1, currentResult))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
