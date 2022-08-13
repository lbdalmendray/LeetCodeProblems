using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LongestSubstringofOneRepeatingCharacter
{
    public class Solution
    {
        public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
        {
            Tree tree = new Tree(s);

            int[] result = new int[queryCharacters.Length];
            for (int i = 0; i < queryCharacters.Length; i++)
            {
                tree.SetCharArryaAt(queryIndices[i], queryCharacters[i]) ;
                result[i] = tree.Nodes[0].Max;
            }

            return result;
        }        
    }
    /// <summary>
    /// Segment Tree
    /// </summary>
    public class Tree
    {
        public char[] CharArray;
        public int[] CharNodeIndex;
        public Node[] Nodes;

        public Tree(string s)
        {
            CharArray = s.ToArray();
            CharNodeIndex = new int[s.Length];
            Nodes = new Node[s.Length * 4];
            GenerateNodes(CharArray, 0, s.Length - 1, 0);
        }

        public Node GenerateNodes(char [] s, int index1, int index2, int nodeIndex)
        {
            Node result;

            if (index1 == index2)
            {
                result = new Node
                {
                    Max = 1, /// MAX CALCULATED
                    LeftIndex1 = index1,
                    LeftIndex2 = index2,
                    RightIndex1 = index1,
                    RightIndex2 = index2
                };

                this.CharNodeIndex[index1] = nodeIndex;
            }
            else // index1 < index2
            {
                result = new Node();

                int midIndex = (index1 + index2) / 2;

                Node leftNode = GenerateNodes(s, index1, midIndex, nodeIndex * 2 + 1);
                Node rightNode = GenerateNodes(s, midIndex + 1, index2, nodeIndex * 2 + 2);
                ReCalculateNode(result, leftNode, rightNode);
            }

            this.Nodes[nodeIndex] = result;
            return result;
        }

        internal void SetCharArryaAt(int charArrayIndex, char charValue)
        {
            CharArray[charArrayIndex] = charValue;
            int index = CharNodeIndex[charArrayIndex];
            Node node = Nodes[index];
            index = index % 2 == 1 ? index / 2 : index / 2 - 1;

            while (index > -1)
            {
                node = Nodes[index];
                ReCalculateNode(node, Nodes[index * 2 + 1], Nodes[index * 2 + 2]);
                index = index % 2 == 1 ? index / 2 : index / 2 - 1;
            }
        }

        private void ReCalculateNode(Node result, Node leftNode, Node rightNode)
        {
            if (CharArray[leftNode.RightIndex2] != CharArray[rightNode.LeftIndex1])
            {
                result.LeftIndex1 = leftNode.LeftIndex1;
                result.LeftIndex2 = leftNode.LeftIndex2;
                result.RightIndex1 = rightNode.RightIndex1;
                result.RightIndex2 = rightNode.RightIndex2;
                result.Max = Math.Max(leftNode.Max, rightNode.Max);
            }
            else
            {
                int midIndex1 = leftNode.RightIndex1;
                int midIndex2 = rightNode.LeftIndex2;
                int midIndexLength = midIndex2 - midIndex1 + 1;
                result.Max = Math.Max(Math.Max(midIndexLength, leftNode.Max), rightNode.Max);

                if (midIndex1 == leftNode.LeftIndex1)
                {
                    result.LeftIndex1 = midIndex1;
                    result.LeftIndex2 = midIndex2;
                }
                else
                {
                    result.LeftIndex1 = leftNode.LeftIndex1;
                    result.LeftIndex2 = leftNode.LeftIndex2;
                }

                if (midIndex2 == rightNode.RightIndex2)
                {
                    result.RightIndex1 = midIndex1;
                    result.RightIndex2 = midIndex2;
                }
                else
                {
                    result.RightIndex1 = rightNode.RightIndex1;
                    result.RightIndex2 = rightNode.RightIndex2;
                }
            }
        }

        public int GetMax(int index1, int index2)
        {
            if (!(index1 <= index2 && 0 <= index1
                && index2 <= CharArray.Length - 1))
                return -1;

            if (Nodes.Length == 1)
            {
                if (index1 == index2 && index1 == Nodes[0].LeftIndex1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            else
            {
                var result = GetMaxNode(index1, index2, 0);
                return result.Max;
            }
        }

        private Node GetMaxNode(int index1, int index2, int nodeIndex)
        {
            if (index1 > index2)
                return null;

            Node node = Nodes[nodeIndex];
            if (index1 == node.LeftIndex1 && index2 == node.RightIndex2)
            {
                return node;
            }
            else
            {
                int midIndex = (node.LeftIndex1 + node.RightIndex2) / 2;
                if (index1 <= midIndex && midIndex <= index2)
                {
                    var node1 = GetMaxNode(index1, midIndex, nodeIndex * 2 + 1);
                    var node2 = GetMaxNode(midIndex + 1, index2, nodeIndex * 2 + 2);
                    if (node1 == null)
                        return node2;
                    else if (node2 == null)
                        return node1;
                    else
                    {
                        var result = new Node();
                        ReCalculateNode(result, node1, node2);
                        return result;
                    }
                }
                else if (midIndex < index1)
                {
                    var node2 = GetMaxNode(index1, index2, nodeIndex * 2 + 2);
                    return node2;
                }
                else
                {
                    var node1 = GetMaxNode(index1, index2, nodeIndex * 2 + 1);
                    return node1;
                }
            }
        }
    }

    public class Node
    {
        public int Max { get; set; }
        public int LeftIndex1 { get; set; }
        public int LeftIndex2 { get; set; }
        public int RightIndex1 { get; set; }
        public int RightIndex2 { get; set; }
    }
}
