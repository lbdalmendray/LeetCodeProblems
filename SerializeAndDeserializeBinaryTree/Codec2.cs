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
    public class Codec2
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
            queue.AddLast(root);
            bool first = true;
            while(queue.Count != 0)
            {
                var node = queue.First.Value;
                queue.RemoveFirst();
                if (first)
                    first = false;
                else
                    sb.Append(' ');
                if (node == null)
                    sb.Append('N');
                else
                {
                    sb.Append(node.val);

                    queue.AddLast(node.left);
                    queue.AddLast(node.right);
                }                
            }

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var infos = data.Split(' ');
            LinkedList<(string,TreeNode,bool)> queue = new LinkedList<(string, TreeNode, bool)>();
            TreeNode resultIsChildLeft = new TreeNode(10);
            int index = 0;
            queue.AddLast((infos[index++], resultIsChildLeft, true));

            while(queue.Count != 0)
            {
                (string strValue, TreeNode father, bool isLeft) = queue.First.Value;
                queue.RemoveFirst();

                if ( strValue != "N")
                {
                    TreeNode node = new TreeNode(int.Parse(strValue));
                    if (isLeft)
                        father.left = node;
                    else
                        father.right = node;

                    queue.AddLast((infos[index++], node, true));    
                    queue.AddLast((infos[index++], node, false));
                }     
            }

            return resultIsChildLeft.left;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
