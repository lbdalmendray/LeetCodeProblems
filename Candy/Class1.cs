using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy
{
    public class Solution
    {
        /// <summary>
        /// O(n*log(n)) . There are O(n) solutions . 
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int Candy(int[] ratings)
        {
            var ratingsClone = ratings.Select(e => e).ToArray();
            var indexes = Enumerable.Range(0, ratingsClone.Length).ToArray();
            Array.Sort(ratingsClone, indexes);

            int[] result = new int[ratings.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                int rating = ratings[index];

                if ( index > 0 )
                {
                    if (ratings[index - 1] < rating)
                        result[index] = result[index - 1] + 1;
                    else
                        result[index] = 1;
                }
                else
                {
                    result[index] = 1;
                }

                if ( index < indexes.Length - 1)
                {
                    if( ratings[index+1] < rating)
                    {
                        result[index] = Math.Max(result[index], result[index + 1] + 1);
                    }
                }
            }

            return result.Sum();
        }
        /// <summary>
        /// Other Solution . O(n^2)
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        private int Candy1(int[] ratings)
        {
            var treeNode = CreateTreeNode(ratings);
            return Candy1Aux(treeNode);
        }

        private int Candy1Aux(TreeNode treeNode)
        {
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
            queue.AddLast(treeNode);
            LinkedList<TreeNode> ordered = new LinkedList<TreeNode>();

            while (queue.Count != 0)
            {
                var first = queue.First.Value;
                ordered.AddLast(first);
                queue.RemoveFirst();
                if (first.Left != null)
                    queue.AddLast(first.Left);
                if (first.Right != null)
                    queue.AddLast(first.Right);
            }

            var node = ordered.Last;
            while (node != null)
            {
                var currentTreeNode = node.Value;
                var mostLeftCandy = currentTreeNode.Left != null ? currentTreeNode.Left.MostRightNode.Candy : 0;
                var mostRightCandy = currentTreeNode.Right != null ? currentTreeNode.Right.MostLeftNode.Candy : 0;
                var leftTotal = currentTreeNode.Left != null ? currentTreeNode.Left.Total : 0;
                var rightTotal = currentTreeNode.Right != null ? currentTreeNode.Right.Total : 0;

                if (currentTreeNode.Left != null && currentTreeNode.Right != null)
                {
                    if (currentTreeNode.Left.MostRightNode.Value == currentTreeNode.Value && currentTreeNode.Right.MostLeftNode.Value == currentTreeNode.Value)
                    {
                        currentTreeNode.Candy = 1;
                        
                    }
                    else if (currentTreeNode.Left.MostRightNode.Value == currentTreeNode.Value)
                    {
                        currentTreeNode.Candy = mostRightCandy + 1;
                        
                    }
                    else if (currentTreeNode.Right.MostLeftNode.Value == currentTreeNode.Value)
                    {
                        currentTreeNode.Candy = mostLeftCandy + 1;
                        
                    }
                    else
                    {
                        currentTreeNode.Candy = Math.Max(mostLeftCandy, mostRightCandy) + 1;                       
                    }
                    currentTreeNode.MostLeftNode = currentTreeNode.Left.MostLeftNode;
                    currentTreeNode.MostRightNode = currentTreeNode.Right.MostRightNode;
                }
                else if (currentTreeNode.Left != null)
                {
                    if (currentTreeNode.Left.MostRightNode.Value == currentTreeNode.Value)
                    {
                        currentTreeNode.Candy = 1;
                    }
                    else
                    {
                        currentTreeNode.Candy = mostLeftCandy + 1;
                    }
                    currentTreeNode.MostLeftNode = currentTreeNode.Left.MostLeftNode;
                    currentTreeNode.MostRightNode = currentTreeNode;
                }

                else if (currentTreeNode.Right != null)
                {
                    if (currentTreeNode.Right.MostLeftNode.Value == currentTreeNode.Value)
                    {
                        currentTreeNode.Candy = 1;
                    }
                    else
                    {
                        currentTreeNode.Candy = mostRightCandy + 1;
                    }
                    currentTreeNode. MostRightNode = currentTreeNode.Right.MostRightNode;
                    currentTreeNode.MostLeftNode = currentTreeNode;
                }

                else
                {
                    currentTreeNode.Candy = 1;
                    currentTreeNode.MostRightNode = currentTreeNode;
                    currentTreeNode.MostLeftNode = currentTreeNode;
                }

                currentTreeNode.Total = currentTreeNode.Candy + rightTotal + leftTotal;
                node = node.Previous;
            }

            return treeNode.Total;
        }

        private TreeNode CreateTreeNode(int[] ratings)
        {
            var indexes = Enumerable.Range(0, ratings.Length).ToArray();
            Array.Sort(ratings, indexes);

            TreeNode result = new TreeNode { Index = indexes[ratings.Length-1], Value = ratings[ratings.Length-1] };

            for (int i = ratings.Length-2; i >= 0; i--)
            {
                Insert(i, ratings, indexes, result);
            }

            return result;
        }

        private void Insert(int i, int[] ratings, int[] indexes, TreeNode result)
        {
            var node = result;
            while(true)
            {
                if(indexes[i] > node.Index)
                {
                    if( node.Right == null)
                    {
                        node.Right = new TreeNode { Index = indexes[i], Value = ratings[i] };
                        break;
                    }
                    node = node.Right;
                }
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode { Index = indexes[i], Value = ratings[i] };
                        break;
                    }
                    node = node.Left;
                }
            }
        }
    }

    internal class TreeNode
    {
        public int Value { get; set; }
        public int Index { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Candy { get; internal set; }
        public int Total { get; internal set; }
        public TreeNode MostRightNode { get; internal set; }
        public TreeNode MostLeftNode { get; internal set; }
    }
}
