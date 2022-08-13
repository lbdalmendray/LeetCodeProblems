using System;
using System.Collections.Generic;

namespace KEmptySlots
{
    public class Solution
    {
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="bulbs"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KEmptySlots(int[] bulbs, int k)
        {
            bool existResult = false;
            int result = int.MaxValue;

            LinkedList<Info> linked = new LinkedList<Info>();
            LinkedListNode<Info>[] array = new LinkedListNode<Info>[bulbs.Length];
            for (int i = 0; i < bulbs.Length; i++)
            {
                var node = linked.AddLast(new Info 
                { 
                    BulbNumber = i 
                });
                array[i] = node;
            }

            for (int day = 0; day < bulbs.Length; day++)
            {
                var pos = bulbs[day]-1;
                array[pos].Value.Day = day;
            }

            for (int day = bulbs.Length - 1 ; day > -1 ; day--)
            {
                var pos = bulbs[day]-1;
                LinkedListNode<Info> cNode = array[pos];
                var cNodePrev = cNode.Previous;
                var cNodeNext = cNode.Next;
                cNode.List.Remove(cNode);
                if( cNodePrev != null && cNodeNext !=null)
                {
                    var bulbNumber1 = cNodePrev.Value.BulbNumber;
                    var bulbNumber2 = cNodeNext.Value.BulbNumber;
                    if( bulbNumber2 - bulbNumber1-1 == k )
                    {
                        existResult = true;
                        var cResult = Math.Max(cNodePrev.Value.Day, cNodeNext.Value.Day) + 1;
                        result = Math.Min(cResult, result);
                    }
                }
            }

            if (existResult)
                return result;
            else
                return -1;
        }
    }

    public class Info
    {
        public int BulbNumber { get; internal set; }
        public int Day { get; internal set; }
    }
}
