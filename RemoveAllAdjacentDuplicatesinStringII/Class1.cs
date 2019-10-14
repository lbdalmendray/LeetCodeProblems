using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllAdjacentDuplicatesinStringII
{
    public class Solution
    {
        public string RemoveDuplicates(string s, int k)
        {
            LinkedList<int[]> stretched = new LinkedList<int[]>();
            for (int i = 0; i < s.Length; i++)
            {
                stretched.AddLast(new int[] { s[i], 1 });
                int j = i + 1;
                for (; j < s.Length; j++)
                {
                    if( s[i] != s[j])
                    {
                        break;
                    }
                    stretched.Last.Value[1]++;
                }
                i = j - 1;
            }

            LinkedList<LinkedListNode<int[]>> reducables = new LinkedList<LinkedListNode<int[]>>();
            var currentNode = stretched.First;

            while(currentNode != null)
            {
                if (currentNode.Value[1] >= k)
                    reducables.AddLast(currentNode);
                currentNode = currentNode.Next;
            }

            while (reducables.Count != 0 )
            {
                var node = reducables.First;
                if( node.Value.Previous == null && node.Value.Next == null && stretched.First != node.Value)
                {
                    reducables.RemoveFirst();
                    continue;
                }
                int count = node.Value.Value[1];
                /*
                 if(node.Value.Length > 1 )
                {
                    stretched.Remove(node.Value[1]);
                    node.Value = new LinkedListNode<int[]>[] { node.Value[0] };
                }
                */

                count = count % k;
                node.Value.Value[1] = count;

                var stretchedNode = node.Value;

                if(count == 0)
                {
                    if(stretchedNode.Previous != null && stretchedNode.Next != null && stretchedNode.Previous.Value[0] == stretchedNode.Next.Value[0])
                    {
                        var isInReducables = stretchedNode.Previous.Value[1] >= k;
                        stretchedNode.Previous.Value[1] += stretchedNode.Next.Value[1];
                        stretched.Remove(stretchedNode.Next);
                        if (!isInReducables && stretchedNode.Previous.Value[1] >= k)
                            reducables.AddLast( stretchedNode.Previous );
                    }
                    stretched.Remove(stretchedNode);
                }
                reducables.RemoveFirst();
            }

            LinkedList<char> chars = new LinkedList<char>();
            foreach (var item in stretched)
            {
                for (int i = 0; i < item[1]; i++)
                {
                    chars.AddLast((char)item[0]);
                }
            }

            return new string(chars.ToArray());            
        }
    }    
}
