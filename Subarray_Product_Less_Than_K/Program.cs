using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_Product_Less_Than_K
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[50000];
            //nums[1000] = 1000;
            //nums = new int[]{ 0,0,0,0 };
            //nums = GetArray();
            Solution s = new Solution();
            int a = s.NumSubarrayProductLessThanK(nums, 100);
        }

        static int[] GetArray()
        {
            using (StreamReader s = new StreamReader("array.txt"))
            {
                return s.ReadToEnd().Split(',').Select(c => int.Parse(c)).ToArray();
            }

        }
    }
}
