using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumPossibleIntegerAfteratMostKAdjacentSwapsOnD;
using System.Numerics;
using System.Text;

namespace MinimumPossibleIntegerAfteratMostKAdjacentSwapsOnDTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinInteger("4321", 4);
            Assert.AreEqual(result, "1342");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MinInteger("100", 1);
            Assert.AreEqual(result, "010");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MinInteger("36789", 1000);
            Assert.AreEqual(result, "36789");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MinInteger("22", 1000);
            Assert.AreEqual(result, "22");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MinInteger("9438957234785635408", 23);
            Assert.AreEqual(result, "0345989723478563548");
        }

        [TestMethod]
        public void TestMethod6()
        {
            string base1 = "1234567890";
            string number = "";
            while(number.Length != 30000)
            {
                number += base1;
            }

            Solution s = new Solution();
            var result = s.MinInteger(number, int.MaxValue);
            var sb = new StringBuilder();
            foreach (var item in "0123456789" )
            {
                for (int i = 0; i < 30000/10; i++)
                {
                    sb.Append(item);
                }
            }

            Assert.AreEqual(result, sb.ToString());
        }
    }
}
