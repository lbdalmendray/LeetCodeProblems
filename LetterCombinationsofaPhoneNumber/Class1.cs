using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationsofaPhoneNumber
{
    public class Solution
    {
        Node[] nodes = new Node[10]; 

        public Solution()
        {
            var node2 = new Node { Values = "abc" };
            var node3 = new Node { Values = "def" };
            var node4 = new Node { Values = "ghi" };
            var node5 = new Node { Values = "jkl" };
            var node6 = new Node { Values = "mno" };
            var node7 = new Node { Values = "pqrs" };
            var node8 = new Node { Values = "tuv" };
            var node9 = new Node { Values = "wxyz" };

            nodes[2] = node2;
            nodes[3] = node3;
            nodes[4] = node4;
            nodes[5] = node5;
            nodes[6] = node6;
            nodes[7] = node7;
            nodes[8] = node8;
            nodes[9] = node9;
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();

            List<string> result = new List<string>();

            Node [] nodeList = CreateNodeList(digits);
            DFS(nodeList, 0, result, new LinkedList<char>() , digits.Length - 1);

            return result;
        }

        private void DFS(Node[] nodeList, int index, List<string> result, LinkedList<char> cResult, int lastIndex)
        {
            foreach (var charValue in nodeList[index].Values)
            {
                cResult.AddLast(charValue);

                if ( index == lastIndex)
                {
                    result.Add(new string(cResult.ToArray()));
                }
                else
                {
                    DFS(nodeList, index + 1, result, cResult, lastIndex);
                }

                cResult.RemoveLast();
            }            
        }

        private Node[] CreateNodeList(string digits)
        {
            Node[] result = digits.Select(d => nodes[d - '0']).ToArray();
            return result;
        }
    }

    public class Node
    {
        public string Values { get; internal set; }
    }
}
