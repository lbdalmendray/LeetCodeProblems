using System;

namespace MaximumDistanceBetweenaPairofValues
{
    public class Solution
    {
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            int result = 0;
            int nums2LengthL1 = nums2.Length - 1;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (i == nums2.Length)
                    break;

                int jmax = FindMin(i, nums2LengthL1, nums1[i], nums2);
                if (jmax > -1)
                {
                    int distance = jmax - i;
                    if (distance > result)
                        result = distance;
                }
            }

            return result;
        }

        private int FindMin(int i1, int i2, int v, int[] array)
        {
            while( i2 - i1 > 3)
            {
                int m = (i2 + i1) / 2;
                if ( v <= array[m] )
                {
                    i1 = m;
                }
                else
                {
                    i2 = m - 1;
                }
            }

            for (int i = i2; i >= i1 ; i--)
            {
                if (v <= array[i])
                    return i;
            }
            return -1;
        }
    }
}
