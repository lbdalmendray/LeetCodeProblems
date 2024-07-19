namespace FindMissingObservationsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FindMissingObservations.Solution solution = new FindMissingObservations.Solution();
            int [] mList = [3, 2, 4, 3];
            int mean = 4;
            int n = 2;
            var nList = solution.MissingRolls(mList, mean, n);
            var nSum = nList.Sum();
            var mSum = mList.Sum();
            Assert.AreEqual(n, nList.Length);
            Assert.AreEqual(mSum + nSum, mean * (mList.Length + nList.Length));
        }

        [TestMethod]
        public void TestMethod2()
        {
            FindMissingObservations.Solution solution = new FindMissingObservations.Solution();
            int[] mList = [1,5,6];
            int mean = 3;
            int n = 4;
            var nList = solution.MissingRolls(mList, mean, n);
            var nSum = nList.Sum();
            var mSum = mList.Sum();
            Assert.AreEqual(n, nList.Length);
            Assert.AreEqual(mSum + nSum, mean * (mList.Length + nList.Length));
        }

        [TestMethod]
        public void TestMethod3()
        {
            FindMissingObservations.Solution solution = new FindMissingObservations.Solution();
            int[] mList = [1, 2, 3, 4];
            int mean = 6;
            int n = 4;
            var nList = solution.MissingRolls(mList, mean, n);
            var nSum = nList.Sum();
            var mSum = mList.Sum();
            Assert.AreEqual(0, nList.Length);
        }
    }
}