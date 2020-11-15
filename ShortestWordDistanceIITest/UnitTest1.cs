using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestWordDistanceII;

namespace ShortestWordDistanceIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            WordDistance s = new WordDistance(new string[] { "practice", "makes", "perfect", "coding", "makes" });
            var result = s.Shortest("coding", "practice");
            Assert.AreEqual(result, 3);
            result = s.Shortest("makes", "practice");
            Assert.AreEqual(result, 1);
            result = s.Shortest("perfect", "practice");
            Assert.AreEqual(result, 2);
        }
        /*
         ["WordDistance","shortest","shortest"]
[[["practice","makes","perfect","coding","makes"]],["coding","practice"],["makes","coding"]]
         */
        [TestMethod]
        public void TestMethod2()
        {
            WordDistance s = new WordDistance(new string[] { "practice", "makes", "perfect", "coding", "makes" });
            var result = s.Shortest("coding", "practice");
            Assert.AreEqual(result, 3);
            result = s.Shortest("makes", "coding");
            Assert.AreEqual(result, 1);
        }
    }
}
