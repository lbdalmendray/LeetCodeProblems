using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionofTwoArrays
{
    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            foreach (var item in nums1)
            {
                if( !dict.ContainsKey(item))
                {
                    dict.Add(item, false);
                }
            }

            foreach (var item in nums2)
            {
                if (dict.ContainsKey(item))
                    dict[item] = true;
            }

            return dict.Where(kv => kv.Value).Select(e=>e.Key).ToArray();
        }
    }
}
