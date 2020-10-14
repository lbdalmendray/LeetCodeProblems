using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubdomainVisitCount;

namespace SubdomainVisitCountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.SubdomainVisits(new string[] { "9001 discuss.leetcode.com" });
            CollectionAssert.AreEquivalent(result.ToArray(), new string[] { "9001 discuss.leetcode.com", "9001 leetcode.com", "9001 com" });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.SubdomainVisits(new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" });
            CollectionAssert.AreEquivalent(result.ToArray(), new string[] { "901 mail.com", "50 yahoo.com", "900 google.mail.com", "5 wiki.org", "5 org", "1 intel.mail.com", "951 com" });
        }
    }
}
