using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAndDeserializeBinaryTree
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
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return null;


            StringBuilder sb = new StringBuilder();
            int nodeNumber = -1;
            LinkedList<(TreeNode, int,bool)> queue = new LinkedList<(TreeNode, int,bool)>();
            queue.AddLast((root, nodeNumber, true));
            bool first = true;
            while (queue.Count != 0)
            {
                nodeNumber++;
                (var treeNode, var fatherNumber, var isLeft) = queue.First.Value;
                queue.RemoveFirst();
                if(!first)
                    sb.Append(' ');
                else
                    first = false;
                serialize(treeNode, fatherNumber, isLeft, sb);

                if( treeNode.left != null)
                {
                    queue.AddLast((treeNode.left, nodeNumber,true));
                }
                if (treeNode.right != null)
                {
                    queue.AddLast((treeNode.right, nodeNumber, false));
                }                
            }

            return sb.ToString();
        }

        private void serialize(TreeNode node, int fatherNumber, bool isLeft, StringBuilder sb)
        {
            EncodeNumber(node.val, sb);
            sb.Append(' ');
            if (isLeft)
                sb.Append('L') ;
            else
                sb.Append('R') ;
            EncodeNumber(fatherNumber, sb);
        }

        private void EncodeNumber(int number, StringBuilder sb)
        {
            sb.Append(number);
        } 

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null)
                return null;

            string[] splitParts = data.Split(' ');
            TreeNode[] treenodes = new TreeNode[splitParts.Length / 2];
            for (int i = 0; i < splitParts.Length; i+=2)
            {
                int value = int.Parse(splitParts[i]);
                TreeNode node = new TreeNode(value);
                treenodes[i / 2] = node;
                var fatherNumber = int.Parse(splitParts[i + 1].Substring(1));
                if (fatherNumber == -1)
                    continue;
                bool isLeftChild = splitParts[i + 1][0] == 'L';
                if (isLeftChild)
                    treenodes[fatherNumber].left = node;
                else
                    treenodes[fatherNumber].right = node;
            }
            return treenodes[0];
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
