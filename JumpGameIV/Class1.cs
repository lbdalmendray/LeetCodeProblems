using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGameIV
{
    public class Solution
    {
        public int MinJumps(int[] arr)
        {
            if (arr.Length == 1)
                return 0;

            Dictionary<int, LinkedList<int>> eqDict = new Dictionary<int, LinkedList<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if( !eqDict.TryGetValue(arr[i], out var list))
                {
                    list = new LinkedList<int>();
                    eqDict.Add(arr[i], list);
                }
                list.AddLast(i);
                int j = i + 1;
                while(j < arr.Length && arr[i]==arr[j])
                {
                    j++;
                }

                if(j-1 != i)
                {
                    list.AddLast(j - 1);
                }
                i = j - 1;
            }

            bool[] selected = new bool[arr.Length];

            LinkedList<(int,int)> queue = new LinkedList<(int,int)>();
            selected[0] = true;
            queue.AddLast((0,0));
            
            while(queue.Count != 0)
            {
                var (index,length) = queue.First.Value;
                queue.RemoveFirst();

                if (index == arr.Length - 1)
                    return length;

                foreach (int item in GetNextPositions(index, arr,selected, eqDict))
                {
                    selected[item] = true;
                    queue.AddLast((item, length + 1));
                }
            }

            return -1;
        }

        private IEnumerable<int> GetNextPositions(int index, int[] arr, bool[] selected, Dictionary<int, LinkedList<int>> eqDict)
        {
            if (index > 0 && !selected[index-1])
                yield return index - 1;
            if (index < selected.Length - 1 && !selected[index + 1])
                yield return index + 1;

            if(eqDict.TryGetValue(arr[index], out var list))
            {
                foreach (var item in list.Where(i=>i!=index).Where(i=>!selected[i]))
                {
                    yield return item;
                }
            }
        }
    }
}
