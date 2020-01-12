using System;
using System.Linq;
using AddTwoNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddTwoNumbersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.AddTwoNumbers(CreateNumber(101), CreateNumber(99));
            Assert.AreEqual(GetValue(result), 200);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.AddTwoNumbers(CreateNumber(102), CreateNumber(98));
            Assert.AreEqual(GetValue(result), 200);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.AddTwoNumbers(CreateNumber(0), CreateNumber(0));
            Assert.AreEqual(GetValue(result), 0);
            for (int i = 0; i < 1000; i++)
            {
                result = s.AddTwoNumbers(CreateNumber(0), CreateNumber(i));
                Assert.AreEqual(GetValue(result), i);
            }
            
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    var result = s.AddTwoNumbers(CreateNumber(i), CreateNumber(j));
                    Assert.AreEqual(GetValue(result), i+j);
                }                
            }
        }

        private int GetValue(ListNode input)
        {
            int potence = 1;
            int result = 0;
            while(input != null)
            {
                result += input.val * potence;
                potence *= 10;
                input = input.next;
            }

            return result;
        }

        ListNode CreateNumber(int n)
        {
            ListNode current = new ListNode(0);
            var result = current;
            var nString = n.ToString();            ;
            foreach (var item in nString.Reverse())
            {
                current.next = new ListNode(int.Parse(item.ToString()));
                current = current.next;
            }
            return result.next;
        }
    }
}
