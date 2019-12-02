using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindElementsinaContaminatedBinaryTree
{
    public class FindElements
    {
        SortedDictionary<int, int> elements = new SortedDictionary<int, int>();

        public FindElements(TreeNode root)
        {
            
            LinkedList<Tuple<TreeNode, int>> queue = new LinkedList<Tuple<TreeNode, int>>();
            queue.AddLast(new Tuple<TreeNode, int>(root, 0));
            while ( queue.Count !=0 )
            {
                var value = queue.First.Value;
                queue.RemoveFirst();
                elements.Add(value.Item2, value.Item2);

                value.Item1.val = value.Item2;

                if (value.Item1.left != null)
                {
                    queue.AddLast(new Tuple<TreeNode, int>(value.Item1.left, value.Item2 * 2 + 1));
                }

                if (value.Item1.right != null)
                {
                    queue.AddLast(new Tuple<TreeNode, int>(value.Item1.right, value.Item2 * 2 + 2));
                }
            }
        }

        public bool Find(int target)
        {
            return elements.ContainsKey(target);
        }
    }
}
