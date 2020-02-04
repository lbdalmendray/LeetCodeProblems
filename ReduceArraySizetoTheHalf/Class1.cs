using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceArraySizetoTheHalf
{
    public class Solution
    {
        public int MinSetSize(int[] arr)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!counter.ContainsKey(item))
                    counter.Add(item, 1);
                else
                    counter[item]++;
            }

            var keyValues = counter.ToArray();
            Array.Sort(keyValues.Select(kv => kv.Value).ToArray(), keyValues);

            int result = 0;
            int sum = 0;
            int half = arr.Length / 2 ; 
            for (int i = keyValues.Length-1 ; i >= 0; i--)
            {
                sum += keyValues[i].Value;
                result++;
                if (sum >= half)
                    break;
            }

            return result;
        }
    }
}
