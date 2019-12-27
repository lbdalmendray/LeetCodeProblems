using System;
using System.Linq;
using LongestValidParentheses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestValidParenthesesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.LongestValidParentheses("(()");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.LongestValidParentheses("()()");
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();

            foreach (var item in Utils.Utils.GetAllSelections(16))
            {
                var stringValue = new string(item.Select(e => e ? '(' : ')').ToArray());
                int currentResult = 0;
                for (int i = 0; i < stringValue.Length-1; i++)
                {
                    for (int j = 0; j < stringValue.Length; j++)
                    {
                        if ( isValueParentheses(stringValue,i,j))
                        {
                            if (currentResult < j - i + 1)
                                currentResult = j - i + 1;
                        }
                    }
                }

                var result = s.LongestValidParentheses(stringValue);
                Assert.AreEqual(result, currentResult, stringValue);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.LongestValidParentheses("(((((())()");
            Assert.AreEqual(result, 6);
        }

        private bool isValueParentheses(string stringValue, int i, int j)
        {
            int dif = 0;
            for (int k = i; k <= j; k++)
            {
                if (stringValue[k] == '(')
                    dif--;
                else
                    dif++;

                if (dif > 0)
                    return false;
            }

            return dif == 0;
        }
    }
}
