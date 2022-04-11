using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniqueWordAbbreviation;

namespace UniqueWordAbbreviationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input
["ValidWordAbbr", "isUnique", "isUnique", "isUnique", "isUnique", "isUnique"]
[[["deer", "door", "cake", "card"]], ["dear"], ["cart"], ["cane"], ["make"], ["cake"]]
Output
[null, false, true, false, true, true]
             
            Explanation
ValidWordAbbr validWordAbbr = new ValidWordAbbr(["deer", "door", "cake", "card"]);
validWordAbbr.isUnique("dear"); // return false, dictionary word "deer" and word "dear" have the same abbreviation "d2r" but are not the same.
validWordAbbr.isUnique("cart"); // return true, no words in the dictionary have the abbreviation "c2t".
validWordAbbr.isUnique("cane"); // return false, dictionary word "cake" and word "cane" have the same abbreviation  "c2e" but are not the same.
validWordAbbr.isUnique("make"); // return true, no words in the dictionary have the abbreviation "m2e".
validWordAbbr.isUnique("cake"); // return true, because "cake" is already in the dictionary and no other word in the dictionary has "c2e" abbreviation.
             
            */

            ValidWordAbbr validWordAbbr 
                = new ValidWordAbbr(
                    new string[] 
                    { 
                        "deer"
                        , "door"
                        , "cake"
                        , "card"
                    });

            bool result;
            result = validWordAbbr.IsUnique("dear"); // return false, dictionary word "deer" and word "dear" have the same abbreviation "d2r" but are not the same.
            Assert.AreEqual(result, false);
            result = validWordAbbr.IsUnique("cart"); // return true, no words in the dictionary have the abbreviation "c2t".
            Assert.AreEqual(result, true);
            result = validWordAbbr.IsUnique("cane"); // return false, dictionary word "cake" and word "cane" have the same abbreviation  "c2e" but are not the same.
            Assert.AreEqual(result, false);
            result = validWordAbbr.IsUnique("make"); // return true, no words in the dictionary have the abbreviation "m2e".
            Assert.AreEqual(result, true);
            result = validWordAbbr.IsUnique("cake"); // return true, because "cake" is already in the dictionary and no other word in the dictionary has "c2e" abbreviation.
            Assert.AreEqual(result, true);

        }
    }
}
