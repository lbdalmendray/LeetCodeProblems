﻿using System;
using System.Linq;
using LetterCombinationsofaPhoneNumber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetterCombinationsofaPhoneNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.LetterCombinations("23");
            foreach (var item in result)
            {
                Assert.IsTrue(new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }
                .Contains(item));
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.LetterCombinations("7");
            foreach (var item in result)
            {
                Assert.IsTrue(new string[] { "p", "q", "r", "s" }
                .Contains(item));
            }
        }
    }
}
