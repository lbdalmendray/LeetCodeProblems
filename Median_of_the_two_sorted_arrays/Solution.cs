using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_of_the_two_sorted_arrays
{
    public class Solution
    {
        /// <summary>
        ///  Este es el método principal 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null 
                ||  ( nums1 != null && nums1.Length == 0 && nums2 != null && nums2.Length == 0 ) 
                || ( nums1 == null && nums2 != null && nums2.Length == 0  )
                || ( nums2 == null && nums1 != null && nums1.Length == 0 )
                )
                return -1;
            if (nums1 == null || nums1.Length == 0)
            {

                if (nums2.Length % 2 == 1)
                    return nums2[(int)Math.Floor(((double)(nums2.Length)) / 2)];
                else
                {
                    return  ((double)( nums2[nums2.Length / 2] + nums2[(nums2.Length / 2) - 1] )) /2 ;
                }
            }

            if (nums2 == null || nums2.Length == 0)
            {
                if (nums1.Length % 2 == 1)
                    return nums1[(int)Math.Floor(((double)(nums1.Length)) / 2)];
                else
                {
                    return ((double)(nums1[nums1.Length / 2] + nums1[(nums1.Length / 2) - 1])) / 2;
                }
            }
            
            if (nums1.Length == nums2.Length)
            {
                ArrayNew nums1new = new ArrayNew(nums1);
                ArrayNew nums2new = new ArrayNew(nums2);

                double result1 = FindLowerMedianSortedArraysSameLength(nums1new, 0, nums1new.Length-1, nums2new, 0, nums2new.Length-1);
                double result2 = FindBiggerMedianSortedArraysSameLength(nums1new, 0, nums1new.Length-1, nums2new, 0, nums2new.Length-1);

                return (result1 + result2) / 2;
            }
            else
            {
                int minValue = nums1[0] < nums2[0] ? nums1[0] : nums2[0];
                int maxValue = nums1[nums1.Length-1] > nums2[nums2.Length - 1] ? nums1[nums1.Length - 1] : nums2[nums2.Length - 1];
                ArrayNew nums1new = null;
                ArrayNew nums2new = null;

                if (nums1.Length > nums2.Length)
                {
                    nums1new = new ArrayNew(nums1);
                    nums2new = new ArrayNew(nums2);
                }
                else
                {
                    nums1new = new ArrayNew(nums2);
                    nums2new = new ArrayNew(nums1);
                }

                if ((nums1new.Length + nums2new.Length) % 2 == 0)
                {
                    var halfDif = (nums1new.Length - nums2new.Length) / 2;

                    nums2new.MaxValue = maxValue;
                    nums2new.MinValue = minValue;
                    nums2new.AddOver = halfDif;
                    nums2new.AddUnder = halfDif;

                    double result1 = FindLowerMedianSortedArraysSameLength(nums1new, 0, nums1new.Length-1, nums2new, 0, nums2new.Length-1);
                    double result2 = FindBiggerMedianSortedArraysSameLength(nums1new, 0, nums1new.Length-1, nums2new, 0, nums2new.Length-1);

                    return (result1 + result2) / 2;
                }

                else
                {
                    var halfDif = ((nums1new.Length - nums2new.Length)-1) / 2;

                    nums2new.MaxValue = maxValue;
                    nums2new.MinValue = minValue;
                    nums2new.AddOver = halfDif + 1 ;
                    nums2new.AddUnder = halfDif;

                    return FindLowerMedianSortedArraysSameLength(nums1new, 0, nums1new.Length-1, nums2new, 0, nums2new.Length-1);

                }
            }
        }

        public double FindLowerMedianSortedArraysSameLength(ArrayNew nums1, int index11, int index12, ArrayNew nums2, int index21, int index22)
        {
            int subLength = index12 - index11 + 1;
            
            if (subLength == 1)
                return Math.Min(nums1[index11], nums2[index21]);

            ArrayNew numsLower;
            ArrayNew numsBigger;
            int lowerIndex1;
            int lowerIndex2;
            int biggerIndex1;
            int biggerIndex2;

            var medianLowerIndex = (int)Math.Ceiling(((double)(subLength)) / 2) - 1;

            if (nums1[index11 + medianLowerIndex] < nums2[index21 + medianLowerIndex])
            {
                numsLower = nums1;
                numsBigger = nums2;
                lowerIndex1 = index11;
                lowerIndex2 = index12;
                biggerIndex1 = index21;
                biggerIndex2 = index22;
            }
            else
            {
                numsLower = nums2;
                numsBigger = nums1;
                lowerIndex1 = index21;
                lowerIndex2 = index22;
                biggerIndex1 = index11;
                biggerIndex2 = index12;
            }


            if (subLength % 2 == 1)
            {
                // variant 1
                return FindLowerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianLowerIndex, lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianLowerIndex);
                
                // variant 2
                //var result = FindLowerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianLowerIndex+1, lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianLowerIndex-1);
                //if (result < numsLower[lowerIndex1 + medianLowerIndex])
                //    return numsLower[lowerIndex1 + medianLowerIndex];
                //return result;
            }
            else
            {
                return FindLowerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianLowerIndex + 1 , lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianLowerIndex);
            }

        }

        public double FindBiggerMedianSortedArraysSameLength(ArrayNew nums1, int index11, int index12, ArrayNew nums2, int index21, int index22)
        {
            int subLength = index12 - index11 + 1;

            if (subLength == 1)
                return Math.Max(nums1[index11], nums2[index21]);

            ArrayNew numsLower;
            ArrayNew numsBigger;
            int lowerIndex1;
            int lowerIndex2;
            int biggerIndex1;
            int biggerIndex2;

            var medianBiggerIndex = (int)Math.Floor(((double)(subLength)) / 2) ;

            if (nums1[index11 + medianBiggerIndex] < nums2[index21 + medianBiggerIndex])
            {
                numsLower = nums1;
                numsBigger = nums2;
                lowerIndex1 = index11;
                lowerIndex2 = index12;
                biggerIndex1 = index21;
                biggerIndex2 = index22;
            }
            else
            {
                numsLower = nums2;
                numsBigger = nums1;
                lowerIndex1 = index21;
                lowerIndex2 = index22;
                biggerIndex1 = index11;
                biggerIndex2 = index12;
            }

            if (subLength % 2 == 1)
            {
                // Variant 1
                return FindBiggerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianBiggerIndex, lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianBiggerIndex);

                // Variant 2
                //var result = FindBiggerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianBiggerIndex + 1, lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianBiggerIndex - 1 );
                //if (result > numsBigger[biggerIndex1 + medianBiggerIndex])
                //    return numsBigger[biggerIndex1 + medianBiggerIndex];
                //return result;
            }
            else
            {
                return FindBiggerMedianSortedArraysSameLength(numsLower, lowerIndex1 + medianBiggerIndex, lowerIndex2, numsBigger, biggerIndex1, biggerIndex1 + medianBiggerIndex - 1);
            }

        }
    }

    public class ArrayNew
    {
        public int MaxValue { get; set; }
        public int MinValue { get; set; }

        public int AddOver { get; set; }
        public int AddUnder { get; set; }


        int[] values;

        public ArrayNew(int[] values)
        {
            this.values = values;
        }

        public int this[int index]
        {
            get
            {
                if (index < AddUnder)
                    return MinValue;
                else if (index < AddUnder + values.Length)
                    return values[index - AddUnder];
                return MaxValue;
            }
        }

        public int Length { get { return AddUnder + AddOver + values.Length; } }

        public override string ToString()
        {
            String result = "";
            for (int i  = 0; i  < AddUnder; i ++)
            {
                result += MinValue +" ";
            }
            foreach (var item in values)
            {
                result += item + " ";
            }
            for (int i = 0; i < AddOver; i++)
            {
                result += MaxValue + " ";
            }

            return result;
            
        }

    }

}
