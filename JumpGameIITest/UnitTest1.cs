using System;
using System.IO;
using System.Linq;
using JumpGameII;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JumpGameIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.Jump(new int[] { 2, 3, 1, 1, 4 });

            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var length = 1000000;
            var input = Enumerable.Repeat(1, length).ToArray();
            var result = s.Jump(input);

            // WriteInput(input,"Test2.txt");

            Assert.AreEqual(result, length-1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var length = 1000;
            var input = Enumerable.Repeat(1, length).ToArray();
            input[10] = 0;
            input[9] = 2;
            var result = s.Jump(input);

            WriteInput(input,"Test3.txt");

            Assert.AreEqual(result, length - 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var length = 1000;
            var input = Enumerable.Repeat(1, length).ToArray();
            input[10] = 0;
            input[9] = 1;
            input[8] = 3;
            var result = s.Jump(input);

            WriteInput(input, "Test4.txt");

            Assert.AreEqual(result, length - 3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var length = 1000;
            var input = Enumerable.Repeat(1, length).ToArray();
            input[11] = 0;
            input[10] = 0;
            input[9] = 2;
            input[8] = 4;
            var result = s.Jump(input);

            WriteInput(input, "Test5.txt");

            Assert.AreEqual(result, length - 4);
        }

        private void WriteInput(int[] input, string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write('[');
                sw.Write(input[0]);
                foreach (var number in input.Skip(1))
                {
                    sw.Write("," + number);
                }
                sw.Write(']');
            }
        }
    }
}
