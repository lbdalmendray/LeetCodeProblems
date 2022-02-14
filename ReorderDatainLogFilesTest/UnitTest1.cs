using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReorderDatainLogFiles;

namespace ReorderDatainLogFilesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.ReorderLogFiles(
                new string[]
                {
                    "dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"
                    
                }
                );

            CollectionAssert.AreEquivalent(result, new string[] 
            {
                "let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"
            });

        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.ReorderLogFiles(
                new string[]
                {
                    "a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"
                }
                );

            CollectionAssert.AreEquivalent(result, new string[]
            {
                "g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4 7"
            });

        }
    }
}
