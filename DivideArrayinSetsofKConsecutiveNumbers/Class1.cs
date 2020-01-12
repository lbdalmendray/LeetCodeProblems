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
            if (k == 1)
                return true;

            if (nums.Length % k != 0)
                return false;

            Dictionary<int, int[]> dic = new Dictionary<int, int[]>(nums.Length);
            foreach (var item in nums)
            {
                
                if (!dic.TryGetValue(item,out var currentArray))
                {
                    dic.Add(item, new int[] { 1 });
                }
                else
                    currentArray[0]++;
            }

            var keyValues = dic.ToArray();
            Array.Sort(keyValues.Select(e => e.Key).ToArray(), keyValues);
            int minimumIndex = 0;
            while(true)
            {
                for (; minimumIndex < keyValues.Length; minimumIndex++)
                {
                    if (keyValues[minimumIndex].Value[0] != 0)
                        break;
                }
                if (minimumIndex == keyValues.Length)
                    break;

                var currentMinimum = keyValues[minimumIndex].Key;
                keyValues[minimumIndex].Value[0]--;

                if (k > 1)
                {
                    var lastSetValue = currentMinimum + k - 1;
                    for (int i = currentMinimum + 1; i <= lastSetValue; i++)
                    {
                        if (!dic.TryGetValue(i, out var currentArray))
                            return false;
                        if (currentArray[0] == 0)
                            return false;
                        currentArray[0]--;
                    }
                }
            }

            return true;
        }
        public bool IsPossibleDivide1(int[] nums, int k)
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
