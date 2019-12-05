using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextJustification;

namespace TextJustificationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            var result = s.FullJustify(words, 16);
            var output = new string[] {
                                           "This    is    an",
                                           "example  of text",
                                           "justification.  "
            };

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(result[i], output[i]);
            }
        }

        /* 
      Input:
words = ["What","must","be","acknowledgment","shall","be"]
maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]   
    */

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var words = new string[] { "What", "must", "be", "acknowledgment", "shall", "be" };
            var result = s.FullJustify(words, 16);
            var output = new string[] {
                                           "What   must   be",
  "acknowledgment  ",
  "shall be        "
            };

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(result[i], output[i]);
            }
        }


        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var words = new string[] { "Science","is","what","we","understand","well","enough","to","explain",
         "to","a","computer.","Art","is","everything","else","we","do" };
            var result = s.FullJustify(words, 20);
            var output = new string[] {
                                           "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
            };

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(result[i], output[i]);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var words = new string[] { "word1" };
            var result = s.FullJustify(words, 10);
            var output = new string[] {
            "word1     "

            };

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(result[i], output[i]);
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var words = new string[] { "word1" , "word2" };
            var result = s.FullJustify(words, 6);
            var output = new string[] {
            "word1 ", "word2 "

            };

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(result[i], output[i]);
            }
        }
    }

   
}


