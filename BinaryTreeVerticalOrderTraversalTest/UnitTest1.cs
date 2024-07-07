using BinaryTreeVerticalOrderTraversal;

namespace BinaryTreeVerticalOrderTraversalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode root = new TreeNode(3);
            TreeNode left = new TreeNode(9);
            root.left = left;
            TreeNode right = new TreeNode(20);
            root.right = right;
            TreeNode RightLeft = new TreeNode(15);
            right.left = RightLeft;

            TreeNode rightRight = new TreeNode(7);
            right.right = rightRight;  
            Solution solution = new Solution();
            var result = solution.VerticalOrder(root);
            Assert.AreEqual(result.Count, 4);
            CollectionAssert.AreEquivalent(result[0].ToArray(), new int[] { 9 });
            CollectionAssert.AreEquivalent(result[1].ToArray(), new int[] { 3,15 });
            CollectionAssert.AreEquivalent(result[2].ToArray(), new int[] { 20 });
            CollectionAssert.AreEquivalent(result[3].ToArray(), new int[] { 7 });

        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeNode root = new TreeNode(3);
            TreeNode left = new TreeNode(9);
            root.left = left;
            TreeNode leftRight = new TreeNode(0);
            left.right = leftRight;
            left.left = new TreeNode(4);

            TreeNode right = new TreeNode(8);
            root.right = right;
            TreeNode RightLeft = new TreeNode(1);
            right.left = RightLeft;

            TreeNode rightRight = new TreeNode(7);
            right.right = rightRight;
            Solution solution = new Solution();
            var result = solution.VerticalOrder(root);
            Assert.AreEqual(result.Count, 5);
            CollectionAssert.AreEquivalent(result[0].ToArray(), new int[] { 4 });
            CollectionAssert.AreEquivalent(result[1].ToArray(), new int[] { 9 });
            CollectionAssert.AreEquivalent(result[2].ToArray(), new int[] { 3,0,1 });
            CollectionAssert.AreEquivalent(result[3].ToArray(), new int[] { 8 });
            CollectionAssert.AreEquivalent(result[4].ToArray(), new int[] { 7 });

        }

        [TestMethod]
        public void TestMethod100()
        {
            TreeNode root = new TreeNode(0);
            TreeNode currentNode = root;
            for (int i = 1; i <= 99; i++)
            {
                var newNode = new TreeNode(i);
                currentNode.left = newNode;
                currentNode = newNode;
            }

            Solution solution = new Solution();
            var result = solution.VerticalOrder(root);
        }
    }
}