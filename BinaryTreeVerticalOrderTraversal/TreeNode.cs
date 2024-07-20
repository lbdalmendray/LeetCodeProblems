using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeVerticalOrderTraversal
{

    /**
     * Definition for a binary tree node.*/
    public class TreeNode
    {
        public int val;
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int val )
        {
            this.val = val;
        }
    }
}
