using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MaximumProductofSplittedBinaryTree
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    public class Solution
    {
        public int MaxProduct(TreeNode root)
        {
            var rootSum = CreateTreeSum(root);
            BigInteger mod = 1000000007;
            return (int)(MaxProduct(rootSum, rootSum.Sum) % mod);
        }

        private BigInteger MaxProduct(MyTreeNode rootSum, BigInteger sum)
        {
            BigInteger result = 0;
             
            if( rootSum.left != null )
            {
                var left = rootSum.left as MyTreeNode;
                BigInteger fac1 = sum - left.Sum ;
                var prod = (fac1) * (left.Sum);
                if (prod > result)
                    result = prod;

                var leftProd = MaxProduct(left, sum);

                if (leftProd > result)
                    result = leftProd;

            }

            if (rootSum.right != null)
            {
                var right = rootSum.right as MyTreeNode;
                BigInteger fac1 = sum - right.Sum;
                var prod = (fac1) * (right.Sum);
                if (prod > result)
                    result = prod;

                var rightProd = MaxProduct(right, sum);

                if (rightProd > result)
                    result = rightProd;
            }

            return result;
        }

        private MyTreeNode CreateTreeSum(TreeNode node)
        {
            if (node == null)
                return null;

            MyTreeNode nodeSum = new MyTreeNode(node.val);
            nodeSum.Sum = node.val;

            
            if(node.left != null)
            {
                var left = CreateTreeSum(node.left);
                nodeSum.left = left;
                nodeSum.Sum += left.Sum;
            }

            
            if (node.right != null)
            {
                var right = CreateTreeSum(node.right);
                nodeSum.right = right;
                nodeSum.Sum += right.Sum;
            }

            return nodeSum;
        }
    }

    public class MyTreeNode : TreeNode
    {
        public BigInteger Sum { get; set; }
        public MyTreeNode(int value)
            :base(value)
        {

        }
    }
}
