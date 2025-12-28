using KeyboardRow;

namespace KeyboardRowTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["asdfghjkl"]);
            CollectionAssert.AreEquivalent(new string[] { "asdfghjkl" }, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["qQwWeErRtTyYuUiIoOpP"]);
            CollectionAssert.AreEquivalent(new string[] { "qQwWeErRtTyYuUiIoOpP" }, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["zZxXcCvVbBnNmM"]);
            CollectionAssert.AreEquivalent(new string[] { "zZxXcCvVbBnNmM" }, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["Hello", "Alaska", "Dad", "Peace"]);
            CollectionAssert.AreEquivalent(new string[] { "Alaska", "Dad" }, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["omk"]);
            CollectionAssert.AreEquivalent(new string[] { }, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            var result = solution.FindWords(["adsdf", "sfd"]);
            CollectionAssert.AreEquivalent(new string[] { "adsdf", "sfd" }, result);
        }
    }
}
