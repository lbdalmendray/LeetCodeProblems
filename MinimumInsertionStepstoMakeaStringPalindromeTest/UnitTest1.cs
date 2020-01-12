using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumInsertionStepstoMakeaStringPalindrome;

namespace MinimumInsertionStepstoMakeaStringPalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("zzazz");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("mbadm");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("leetcode");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("g");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("no");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("zjveiiwvc");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.MinInsertions("zbstzhjxfzebllrmgbwtuyhlwkcnpvmvqjvudbuwjdezrtnectvlduikdpgykjqzlktuvsgdpmexzfafiqgpebyhnfhrggftjeafecvkblppbolnepjcntvmtbszcdrehtloteshozphfvjfqvfjvyeqmrdoyzuqildnxabwpvxrejimpludvvqvphvbzjpblloigdublctsltvbzkvxmwbuwdampvrecgstnfpqiiymsrchnxzhefaissbjykrhefhhcltxbvdmqvntajntwndbqwbuzvrhkhwounzhilnqqsyfeofqldmyytyoyijxpfftorrbyucqbqzowcdcyjsnljmplwpxioyqroqdecmrskmafckzudgzbwsiotcnbcdfbyxujlvcvtfzjrpux");
            Assert.AreEqual(result, 280);
        }

        [TestMethod]
        public void TestPalindromeMethod1()
        {
            Solution s = new Solution();
            var result = s.GetBestPalindromeSequence("abcddcba");
            Assert.AreEqual(result.Length, 4);
        }

        [TestMethod]
        public void TestPalindromeMethod2()
        {
            Solution s = new Solution();
            int count = 2;
            LinkedList<char> list = new LinkedList<char>();
            list.AddFirst('a');
            list.AddLast('a');
            foreach (var item in "bcdefghijklmnopqrstuv")
            {
                list.AddFirst(item);
                list.AddLast(item);
                var result = s.GetBestPalindromeSequence(new string(list.ToArray()));
                Assert.AreEqual(result.Length, count);
                count++;
            }            
        }

        [TestMethod]
        public void TestPalindromeMethod3()
        {
            Solution s = new Solution();
            int count = 2;
            LinkedList<char> list = new LinkedList<char>();
            list.AddFirst('a');
            list.AddLast('a');
            foreach (var item in "bcdefg")
            {
                list.AddFirst(item);
                list.AddLast(count.ToString()[0]);
                list.AddLast(item);
                var result = s.GetBestPalindromeSequence(new string(list.ToArray()));
                Assert.AreEqual(result.Length, count);
                count++;
            }
        }
    }
}
