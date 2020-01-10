using System;
using IntegertoEnglishWords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegertoEnglishWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(0);
            Assert.AreEqual(result, "Zero");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1);
            Assert.AreEqual(result, "One");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(4);
            Assert.AreEqual(result, "Four");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(123);
            Assert.AreEqual(result, "One Hundred Twenty Three");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(12345);
            Assert.AreEqual(result, "Twelve Thousand Three Hundred Forty Five");
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1234567);
            Assert.AreEqual(result, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven");
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1234567891);
            Assert.AreEqual(result, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One");
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000567891);
            Assert.AreEqual(result, "One Billion Five Hundred Sixty Seven Thousand Eight Hundred Ninety One");
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000000891);
            Assert.AreEqual(result, "One Billion Eight Hundred Ninety One");
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000000001);
            Assert.AreEqual(result, "One Billion One");
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000001011);
            Assert.AreEqual(result, "One Billion One Thousand Eleven");
        }
        [TestMethod]
        public void TestMethod111()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000001021);
            Assert.AreEqual(result, "One Billion One Thousand Twenty One");
        }

        [TestMethod]
        public void TestMethod1111()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000001020);
            Assert.AreEqual(result, "One Billion One Thousand Twenty");
        }

        [TestMethod]
        public void TestMethod11111()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000001220);
            Assert.AreEqual(result, "One Billion One Thousand Two Hundred Twenty");
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000000011);
            Assert.AreEqual(result, "One Billion Eleven");
        }

        [TestMethod]
        public void TestMethod121()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(1000000000);
            Assert.AreEqual(result, "One Billion");
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(10);
            Assert.AreEqual(result, "Ten");
            result = s.NumberToWords(11);
            Assert.AreEqual(result, "Eleven");

            result = s.NumberToWords(12);
            Assert.AreEqual(result, "Twelve");
            result = s.NumberToWords(13);
            Assert.AreEqual(result, "Thirteen");
            result = s.NumberToWords(14);
            Assert.AreEqual(result, "Fourteen");
            result = s.NumberToWords(15);
            Assert.AreEqual(result, "Fifteen");
            result = s.NumberToWords(16);
            Assert.AreEqual(result, "Sixteen");
            result = s.NumberToWords(17);
            Assert.AreEqual(result, "Seventeen");
            result = s.NumberToWords(18);
            Assert.AreEqual(result, "Eighteen");
            result = s.NumberToWords(19);
            Assert.AreEqual(result, "Nineteen");
        }


        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(20);
            Assert.AreEqual(result, "Twenty");
            result = s.NumberToWords(30);
            Assert.AreEqual(result, "Thirty");
            result = s.NumberToWords(40);
            Assert.AreEqual(result, "Forty");
            result = s.NumberToWords(50);
            Assert.AreEqual(result, "Fifty");
            result = s.NumberToWords(60);
            Assert.AreEqual(result, "Sixty");
            result = s.NumberToWords(70);
            Assert.AreEqual(result, "Seventy");
            result = s.NumberToWords(80);
            Assert.AreEqual(result, "Eighty");
            result = s.NumberToWords(90);
            Assert.AreEqual(result, "Ninety");
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var result = s.NumberToWords(21);
            Assert.AreEqual(result, "Twenty One");
            result = s.NumberToWords(31);
            Assert.AreEqual(result, "Thirty One");
            result = s.NumberToWords(51);
            Assert.AreEqual(result, "Fifty One");
            result = s.NumberToWords(61);
            Assert.AreEqual(result, "Sixty One");
            result = s.NumberToWords(71);
            Assert.AreEqual(result, "Seventy One");
            result = s.NumberToWords(81);
            Assert.AreEqual(result, "Eighty One");
            result = s.NumberToWords(91);
            Assert.AreEqual(result, "Ninety One");
        }
    }
}
