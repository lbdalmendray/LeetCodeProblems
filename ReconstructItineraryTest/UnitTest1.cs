using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReconstructItinerary;

namespace ReconstructItineraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var stringValues = new List<List<string>>{new List<string> { "MUC", "LHR" }, new List<string> { "JFK", "MUC" }, new List<string> { "SFO", "SJC" }, new List<string> { "LHR", "SFO" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK", "MUC", "LHR", "SFO", "SJC" });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var stringValues = new List<List<string>> { new List<string> { "JFK", "SFO" }, new List<string> { "JFK", "ATL" }, new List<string> { "SFO", "ATL" }, new List<string> { "ATL", "JFK" }, new List<string> { "ATL", "SFO" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var stringValues = new List<List<string>> { new List<string> { "JFK", "AAB" }, new List<string> { "JFK", "AAA" }, new List<string> { "AAA", "ATL" }, new List<string> { "ATL", "JFK" }, new List<string> { "AAB", "SFO" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK", "AAA", "ATL", "JFK", "AAB", "SFO" });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var stringValues = new List<List<string>> { new List<string> { "MUC", "LHR" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK" });
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var stringValues = new List<List<string>> { new List<string> { "JFK", "JFK" } , new List<string> { "JFK", "JFK" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK", "JFK", "JFK"});
        }

        [TestMethod]
        public void TestMethod6()
        {
            // [["JFK","KUL"],["JFK","NRT"],["NRT","JFK"]]
            Solution s = new Solution();
            var stringValues = new List<List<string>> { new List<string> { "JFK", "KUL" }, new List<string> { "JFK", "NRT" }, new List<string> { "NRT", "JFK" } };
            var result = s.FindItinerary(stringValues.Select(e => e as IList<string>).ToList() as IList<IList<string>>);
            CollectionAssert.AreEqual(result.ToArray(), new List<string> { "JFK", "NRT" , "JFK", "KUL" });
        }
    }
}
