using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructBinaryTreefromPreorderandInorderTraversal
{
    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;

            Dictionary<int, int> inorderIndexes = new Dictionary<int, int>(inorder.Length);
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexes.Add(inorder[i], i);
            }

            int[] preorderInput = new int[preorder.Length];

            for (int i = 0; i < inorder.Length; i++)
            {
                var index = inorderIndexes[preorder[i]];
                preorderInput[i] = index;
            }

            int iILeft = 0;
            int iIRight = preorder.Length - 1;
            int iPLeft = 0;
            int iPRight = preorder.Length - 1;

            var result = BuildTreeAux(iILeft, iIRight, iPLeft, iPRight, preorderInput, inorder);

            return result;
        }


        private TreeNode BuildTreeAux(int iILeft, int iIRight, int iPLeft, int iPRight, int[] preorderInput, int[] inorder)
        {
            if (iILeft > iIRight)
                return null;

            TreeNode result = new TreeNode(inorder[preorderInput[iPLeft]]);

            int rootPIndex = iPLeft;
            int rootIIndex = preorderInput[iPLeft];

            int rightLength = iIRight - rootIIndex ;
            var iPRightFirstIndex = iPRight - (rightLength - 1);
            var right = BuildTreeAux(rootIIndex + 1, iIRight, iPRightFirstIndex, iPRight,  preorderInput, inorder);
            var left = BuildTreeAux(iILeft, rootIIndex - 1, rootPIndex + 1, iPRightFirstIndex - 1 ,  preorderInput, inorder);

            result.left = left;
            result.right = right;

            return result;
        }

    }   
 
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
