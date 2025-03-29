using TaskScheduler;

namespace TaskSchedulerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            
            var result = solution.LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 2);

            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();

            var result = solution.LeastInterval(['A', 'C', 'A', 'B', 'D', 'B'], 1);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();

            var result = solution.LeastInterval(['A','A','A','B','B','B'], 3);

            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();

            var result = solution.LeastInterval(['Z', 'J', 'Z', 'Y', 'R', 'Y'], 1);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();

            var result = solution.LeastInterval(['Z', 'J', 'Z', 'Y', 'R', 'Y'], 1);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();

            List<char> inputList = new List<char>();
            inputList.AddRange(Enumerable.Range(0,5000).Select(_=>'A'));
            inputList.AddRange(Enumerable.Range(0,5000).Select(_=>'B'));

            var result = solution.LeastInterval(inputList.ToArray(), 3);

            Assert.AreEqual(result, (5000-1)*2 + (5000 -1)*2 +2  );
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution solution = new Solution();

            var result = solution.LeastInterval(['B', 'C', 'D', 'A', 'A', 'A', 'A', 'G'], 1);

            Assert.AreEqual(result, 8);
        }

    }
}