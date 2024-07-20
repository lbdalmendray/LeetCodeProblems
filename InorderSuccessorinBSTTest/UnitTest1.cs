using InorderSuccessorinBST;

namespace InorderSuccessorinBSTTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode node2 = new TreeNode(2);
            TreeNode node1 = new TreeNode(1);
            TreeNode node3 = new TreeNode(3);
            node2.left = node1;
            node2.right = node3;

            Solution solution = new Solution();
            var result = solution.InorderSuccessor(node2, node1);
            Assert.AreEqual(result, node2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node5.right = node6;
            node5.left = node3;
            node3.right = node4;
            node3.left = node2;
            node2.left = node1;

            Solution solution = new Solution();
            var result = solution.InorderSuccessor(node5, node6);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node5.right = node6;
            node5.left = node3;
            node3.right = node4;
            node3.left = node1;
            node6.right = node2;

            Solution solution = new Solution();
            var result = solution.InorderSuccessor(node5, node4);
            Assert.AreEqual(result, node5);
        }

        [TestMethod]
        public void TestMethod4()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node5.left = node6;
            node5.right = node3;
            node3.right = node4;
            node3.left = node1;
            node6.right = node2;

            Solution solution = new Solution();
            var result = solution.InorderSuccessor(node5, node4);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestMethod5()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);

            node5.left = node6;
            node5.right = node3;
            node3.right = node4;
            node3.left = node2;
            node2.left = node1;
            node4.left = node7;

            Solution solution = new Solution();
            var result = solution.InorderSuccessor(node5, node3);
            Assert.AreEqual(result, node7);
        }
    }
}