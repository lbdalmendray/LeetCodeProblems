using EvaluateDivision;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EvaluateDivisionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
             Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
             */

            IList<IList<string>> equations = new string[][]
            {
                 new string[] { "a", "b" }
                ,new string[] { "b", "c" }

            }.Select(e => e as IList<string>).ToList();
            var values = new double[] { 2.0, 3.0 };

            IList<IList<string>> queries = new string[][]
            {
                 new string[] { "a", "c" }
                ,new string[] { "b", "a" }
                ,new string[] { "a", "e" }
                ,new string[] { "a", "a" }
                ,new string[] { "x", "x" }

            }.Select(e => e as IList<string>).ToList();


            Solution solution = new Solution();
            var result = solution.CalcEquation(
                equations
                , values
                , queries
                );

            CollectionAssert.AreEquivalent(result, new double[] { 6.00000, 0.50000, -1.00000, 1.00000, -1.00000 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0]
            , queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
             Output: [3.75000,0.40000,5.00000,0.20000]
             */

            IList<IList<string>> equations = new string[][]
            {
                 new string[] { "a", "b" }
                ,new string[] { "b", "c" }
                ,new string[] { "bc", "cd" }

            }.Select(e => e as IList<string>).ToList();
            var values = new double[] { 1.5, 2.5, 5.0 };

            IList<IList<string>> queries = new string[][]
            {
                 new string[] { "a" , "c"  }
                ,new string[] { "c" , "b"  }
                ,new string[] { "bc", "cd" }
                ,new string[] { "cd", "bc" }

            }.Select(e => e as IList<string>).ToList();


            Solution solution = new Solution();
            var result = solution.CalcEquation(
                equations
                , values
                , queries
                );

            CollectionAssert.AreEquivalent
                (
                result
                , 
                new double[] { 3.75000, 0.40000, 5.00000, 0.20000 });
        }

        [TestMethod]
        public void TestMethod3()
        {
             /*
              Input: equations = [["a","b"]],
              values = [0.5],
              queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
              Output: [0.50000,2.00000,-1.00000,-1.00000]
             */

            IList<IList<string>> equations = new string[][]
            {
                 new string[] { "a", "b" }

            }.Select(e => e as IList<string>).ToList();
            var values = new double[] { 0.5 };

            IList<IList<string>> queries = new string[][]
            {
                 new string[] { "a", "b" }
                ,new string[] { "b", "a" }
                ,new string[] { "a", "c" }
                ,new string[] { "x", "y" }

            }.Select(e => e as IList<string>).ToList();


            Solution solution = new Solution();
            var result = solution.CalcEquation(
                equations
                , values
                , queries
                );

            CollectionAssert.AreEquivalent
                (
                result
                ,
                new double[] { 0.50000, 2.00000, -1.00000, -1.00000 });
        }
    }
}
