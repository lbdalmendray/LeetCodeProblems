using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMaximumPathSum
{
    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            return TreeNodeSolution.CalculateSolution(root);
        }
    }

    public class TreeNodeSolution : TreeNode
    {
        public TreeNodeSolution(int value)
            : base(value)
        {

        }

        public int SumLeftRight { get; private set; }

        public static TreeNodeSolution GetFromTreeNode(TreeNode similar, List<TreeNodeSolution> solutions)
        {
            TreeNodeSolution result = new TreeNodeSolution(similar.val);

            if (similar.left != null)
            {
                var left = GetFromTreeNode(similar.left, solutions);
                result.left = left;
            }
            if (similar.right != null)
            {
                var right = GetFromTreeNode(similar.right, solutions);
                result.right = right;
            }
            solutions.Add(result);

            return result;
        }

        public static int CalculateSolution(TreeNode root)
        {
            List<TreeNodeSolution> solutions = new List<TreeNodeSolution>();
            var treeNodeSolution = GetFromTreeNode(root, solutions);

            CalculateLeftSolution(treeNodeSolution);
            CalculateRightSolution(treeNodeSolution);

            return solutions.Max(s => s.SumLeftRight + s.val);
        }

        private static int CalculateLeftSolution(TreeNodeSolution solution)
        {
            if (solution == null)
                return 0;

            var result = Math.Max(solution.val, solution.val + Math.Max(CalculateLeftSolution(solution.left as TreeNodeSolution), CalculateRightSolution(solution.left as TreeNodeSolution)));
            solution.SumLeftRight += result - solution.val;
            return result;
        }

        private static int CalculateRightSolution(TreeNodeSolution solution)
        {
            if (solution == null)
                return 0;

            var result = Math.Max(solution.val, solution.val + Math.Max(CalculateLeftSolution(solution.right as TreeNodeSolution), CalculateRightSolution(solution.right as TreeNodeSolution)));
            solution.SumLeftRight += result - solution.val;
            return result;
        }
    }
}
