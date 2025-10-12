using GenerateParentheses;

namespace GenerateParenthesesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();

            var result = solution.GenerateParenthesis(3);

            string[] expected = ["((()))", "(()())", "(())()", "()(())", "()()()"];

            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();

            var result = solution.GenerateParenthesis(1);

            string[] expected = ["()"];

            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();

            var result = solution.GenerateParenthesis(2);

            string[] expected = ["()()" , "(())"];

            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }
    }
}