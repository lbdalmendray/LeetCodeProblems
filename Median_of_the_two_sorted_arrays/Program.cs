using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_of_the_two_sorted_arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution s = new Solution();
            //int[] a1 = new int[] { 2, 3, 5, 9 };
            //int[] a2 = new int[] { 3, 4, 5, 7 };

            int[] a2 = new int[] { 0 };
            int[] a1 = new int[] { 4, };

            var aa = s.FindLowerMedianSortedArraysSameLength(new ArrayNew(a1), 0, a1.Length - 1, new ArrayNew(a2), 0, a2.Length - 1);
            aa = s.FindBiggerMedianSortedArraysSameLength(new ArrayNew(a1), 0, a1.Length - 1, new ArrayNew(a2), 0, a2.Length - 1);


            
            a2 = new int[] { 2,2, 3,8 };
            a1 = new int[] { 4 , 7 };

            aa = s.FindMedianSortedArrays(a1, a2);


        }
    }
}
