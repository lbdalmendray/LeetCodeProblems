using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductofArrayExceptSelf;

namespace ProductofArrayExceptSelfTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEquivalent(result, new int[] { 24, 12, 8, 6 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var input = new int[] { 2, 5, 1, 5, 7, 9, 2 };
            var result = s.ProductExceptSelf(input);
            CollectionAssert.AreEquivalent(result, Solving(input));
        }

        [TestMethod]
        public void TestMethodSome()
        {
            Solution s = new Solution();
            for (int i = 2; i < 13; i++)
            {
                var input = Enumerable.Range(1, i).ToArray();
                var result = s.ProductExceptSelf(input);
                CollectionAssert.AreEquivalent(result, Solving(input), Show(input));
            }

            for (int i = -12; i < 1; i++)
            {
                var input = Enumerable.Range(i, 13).ToArray();
                var result = s.ProductExceptSelf(input);
                CollectionAssert.AreEquivalent(result, Solving(input), Show(input));
            }
        }

        private string Show(int[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += input[i] + " ";
            }

            return result;
        }

        private int [] Solving(int [] input)
        {
            LinkedList<int> zeroPositions = new LinkedList<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                    zeroPositions.AddLast(i);
            }

            if ( zeroPositions.Count > 1)
            {
                return Enumerable.Repeat(0, input.Length).ToArray();
            }
            else if ( zeroPositions.Count == 1)
            {
                int index = zeroPositions.First.Value;
                var result = Enumerable.Repeat(0, input.Length).ToArray();
                int product = 1;
                for (int i = 0; i < input.Length; i++)
                {
                    if (i == index)
                        continue;
                    product *= input[i];
                }
                result[index] = product;
                return result;
            }
            else
            {
                int product = 1;
                for (int i = 0; i < input.Length; i++)
                {
                    product *= input[i];
                }

                return input.Select(e => product / e).ToArray();
            }
        }
    }
}
