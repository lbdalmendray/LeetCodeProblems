using System;
using FindPositiveIntegerSolutionGivenEquation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindPositiveIntegerSolutionGivenEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var function = new CustomFunctionA();
            int z = 500;
            var result = s.FindSolution(function, z);
            Assert.IsTrue(result.Count == z-1);
            foreach (var item in result)
            {
                Assert.IsTrue(function.f(item[0], item[1]) == z);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var function = new CustomFunctionA();
            int z = 2001;
            var result = s.FindSolution(function, z);
            Assert.IsTrue(result.Count == 0);
            foreach (var item in result)
            {
                Assert.IsTrue(function.f(item[0], item[1]) == z);
            }
        }
    }

    public class CustomFunctionA : CustomFunction
    {
        public override int f(int x, int y)
        {
            return x + y;
        }
    }

}
