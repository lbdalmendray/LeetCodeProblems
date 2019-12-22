using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumCandiesYouCanGetfromBoxes
{
    public class Solution
    {
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            bool[] selected = new bool[status.Length];
            bool[] processed = new bool[status.Length];
            HashSet<int> obtainedKeys = new HashSet<int>(status.Length);
            int index = 0;
            foreach (var item in status)
            {
                if (item == 1)
                    obtainedKeys.Add(index);
                index++;
            }

            for (int i = 0; i < initialBoxes.Length; i++)
            {
                MaxCandies( keys, containedBoxes, initialBoxes[i],selected,processed,obtainedKeys);
            }

            while(obtainedKeys.Where(e=>selected[e]).Count()!= 0)
            {
                foreach (var item in obtainedKeys.Where(e => selected[e]).ToArray())
                {
                    if(!processed[item])
                    {
                        MaxCandies(keys, containedBoxes, item, selected, processed, obtainedKeys);
                    }
                }
            }

            int result = 0;

            for (int i = 0; i < candies.Length; i++)
            {
                if (processed[i])
                    result += candies[i];
            }

            return result;
        }

        private void MaxCandies(int[][] keys, int[][] containedBoxes, int index, bool[] selected, bool[] processed, HashSet<int> obtainedKeys)
        {
            if (processed[index])
                return;

            selected[index] = true;

            if (!obtainedKeys.Contains(index))
            {
                return;
            }
            else
            {
                obtainedKeys.Remove(index);
            }

            processed[index] = true;

            foreach (var item in keys[index].Where(e=>!processed[e]))
            {
                if (!obtainedKeys.Contains(item))
                    obtainedKeys.Add(item);
            }

            foreach (var item in containedBoxes[index].Where(e=>!processed[e]))
            {
                MaxCandies(keys, containedBoxes, item, selected, processed, obtainedKeys);
            }
        }
    }
}
