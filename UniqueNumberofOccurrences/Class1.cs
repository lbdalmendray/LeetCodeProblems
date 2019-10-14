using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueNumberofOccurrences
{
    public class Solution
    {
        public bool UniqueOccurrences(int[] arr)
        {

            if (arr.Length == 0)
                return true;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 0);
                }
                dict[arr[i]]++;
               
            }
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (var key in dict.Keys)
            {
                if (result.ContainsKey(dict[key]))
                    return false;
                result.Add(dict[key], 1);
            }

            return true;
        }
    }
}
