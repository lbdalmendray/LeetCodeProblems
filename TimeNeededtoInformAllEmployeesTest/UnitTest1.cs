using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeNeededtoInformAllEmployees;

namespace TimeNeededtoInformAllEmployeesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {/*
            Input: n = 1, headID = 0, manager = [-1], informTime = [0]
Output: 0
            */
            var s = new Solution();
            var result = s.NumOfMinutes(1, 0, new int[] { -1 }, new int[] { 0 });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {/*
            Input: n = 6, headID = 2, manager = [2,2,-1,2,2,2], informTime = [0,0,1,0,0,0]
Output: 1
            */
            var s = new Solution();
            var result = s.NumOfMinutes(6, 2, new int[] { 2, 2, -1, 2, 2, 2 }, new int[] { 0, 0, 1, 0, 0, 0 });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {/*
            Input: n = 7, headID = 6, manager = [1,2,3,4,5,6,-1], informTime = [0,6,5,4,3,2,1]
Output: 21
            */
            var s = new Solution();
            var result = s.NumOfMinutes(7, 6, new int[] { 1, 2, 3, 4, 5, 6, -1 }, new int[] { 0, 6, 5, 4, 3, 2, 1 });
            Assert.AreEqual(result, 21);
        }

        [TestMethod]
        public void TestMethod4()
        {/*
            Input: n = 15, headID = 0, manager = [-1,0,0,1,1,2,2,3,3,4,4,5,5,6,6], informTime = [1,1,1,1,1,1,1,0,0,0,0,0,0,0,0]
Output: 3
            */
            var s = new Solution();
            var result = s.NumOfMinutes(15, 0, new int[] { -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod5()
        {/*
            Input: n = 4, headID = 2, manager = [3,3,-1,2], informTime = [0,0,162,914]
Output: 1076
            */
            var s = new Solution();
            var result = s.NumOfMinutes(4, 2, new int[] { 3, 3, -1, 2 }, new int[] { 0, 0, 162, 914 });
            Assert.AreEqual(result, 1076);
        }

        /*
         
         * */

        [TestMethod]
        public void TestMethod7()
        {/*
            8
0
[-1,5,0,6,7,0,0,0]
[89,0,0,0,0,523,241,519]
            */
            var s = new Solution();
            var result = s.NumOfMinutes(8, 0, new int[] { -1, 5, 0, 6, 7, 0, 0, 0 }, new int[] { 89, 0, 0, 0, 0, 523, 241, 519 });
            Assert.AreEqual(result, 612);
        }
    }
}
