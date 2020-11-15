using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadNCharactersGivenRead4II_CallMultipleTimes;

namespace ReadNCharactersGivenRead4II_CallMultipleTimesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Reader4.StringToRead = "abc";
            Solution sol = new Solution();
            char[] buf = new char[3];
            int count = 1;
            int result = sol.Read(buf, count);
            Assert.AreEqual(result, 1);
            Assert.AreEqual(new string(buf.Take(result).ToArray()), "a");

            count = 2;
            result = sol.Read(buf, count);
            Assert.AreEqual(result, 2);
            Assert.AreEqual(new string(buf.Take(result).ToArray()), "bc");

            count = 1;
            result = sol.Read(buf, count);
            Assert.AreEqual(result, 0);
            Assert.AreEqual(new string(buf.Take(result).ToArray()), "");

        }

        [TestMethod]
        public void TestMethod2()
        {
            Reader4.StringToRead = "abc";
            Solution sol = new Solution();
            char[] buf = new char[3];
            int count = 1;
            int result = sol.Read(buf, count);
            Assert.AreEqual(result, 1);
            Assert.AreEqual(new string(buf.Take(result).ToArray()), "a");

            count = 2;
            result = sol.Read(buf, count);
            Assert.AreEqual(result, 2);
            Assert.AreEqual(new string(buf.Take(result).ToArray()), "bc");
        }
    }
}
