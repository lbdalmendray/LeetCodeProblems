using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideArrayinSetsofKConsecutiveNumbers
{
    public class Solution
    {
        public bool IsPossibleDivide(int[] nums, int k)
        {
            if (nums.Length % k != 0)
                return false;
            Array.Sort(nums);
            LinkedList<int> numbers = new LinkedList<int>(nums);
            Dictionary<int, LinkedList<LinkedListNode<int>>> relations = new Dictionary<int, LinkedList<LinkedListNode<int>>>();

            var node = numbers.First;

            while(node != null)
            { 
                if(!relations.ContainsKey(node.Value))
                {
                    relations.Add(node.Value, new LinkedList<LinkedListNode<int>>());
                }

                relations[node.Value].AddLast(node);
                node = node.Next;
            }

            while (numbers.Count != 0)
            {
                var firstValue = numbers.First.Value;
                relations[firstValue].RemoveFirst();                
                numbers.RemoveFirst();

                for (int i = firstValue+1; i < firstValue+k; i++)
                {
                    if (!relations.ContainsKey(i))
                        return false;
                    var currentLinkedList = relations[i];
                    var relNode = currentLinkedList.First.Value;
                    currentLinkedList.RemoveFirst();
                    if (currentLinkedList.Count == 0)
                        relations.Remove(i);
                    numbers.Remove(relNode);
                }
            }

            return true;

        }
    }
}
