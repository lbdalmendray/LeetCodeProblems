using LowestCommonAncestorOfABinaryTreeIII;

namespace LowestCommonAncestorOfABinaryTreeIIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Node root = CreateTree();
            Solution solution = new Solution();

            Node node5 = root.left;
            Node node1 = root.right;

            var result = solution.LowestCommonAncestor(node5, node1);
            Assert.AreEqual(result, root);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Node root = CreateTree();
            Solution solution = new Solution();

            Node node5 = root.left;
            Node node4 = node5.right.right;

            var result = solution.LowestCommonAncestor(node5, node4);
            Assert.AreEqual(result, node5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Node root = CreateTree();
            Solution solution = new Solution();

            var result = solution.LowestCommonAncestor(root, root.right);
            Assert.AreEqual(result, root);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Node root = CreateTree();
            Solution solution = new Solution();

            var result = solution.LowestCommonAncestor(root.right, root.left.right.right);
            Assert.AreEqual(result, root);
        }


        Node CreateTree()
        {
            var leftleft = new Node
            {
                val = 6,
            };

            var leftrightleft = new Node
            {
                val = 7
            };

            var leftrightright = new Node
            {
                val = 4
            };

            var leftright = new Node
            {
                val = 2,
                left = leftrightleft
                        ,
                right = leftrightright
            };
            leftrightleft.parent = leftright;
            leftrightright.parent = leftright;

            var left = new Node
            {
                val = 5
                    ,
                left = leftleft
                    ,
                right = leftright
            };
            leftleft.parent = left;
            leftright.parent = left;

            var rightLeft = new Node
            {
                val = 0
            };

            var rightright = new Node
            {
                val = 8
            };

            var right = new Node
            {
                val = 1
                     ,
                left = rightLeft
                     ,
                right = rightright
            };

            rightLeft.parent = right;
            rightright.parent = right;

            Node result = new Node
            {
                val = 3
                , left = left
                , right = right
            };

            left.parent = result;
            right.parent = result;

            return result;
        }
    }
}