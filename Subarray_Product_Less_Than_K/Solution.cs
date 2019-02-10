using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_Product_Less_Than_K
{
    public class Solution
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            return AuxMet5( nums, k);
        }

        public int AuxMet5(int[] nums, int k)
        {
            int result = 0;

            int countIndex1 = nums.Length;
            int countIndex2 = nums.Length-1;
            int product = k;

            for (int i = nums.Length-1; i > -1 ; i--)
            {
                if (countIndex1 > countIndex2)
                {
                    if (nums[i] < k)
                    {
                        countIndex1 = countIndex2 = i;
                        product = nums[i];
                        result++;
                    }
                    else
                    {
                        countIndex2--;
                    }
                }
                else
                {
                    int value = nums[i] * product;
                    if (value < k)
                    {
                        result += countIndex2 - countIndex1 + 1 + 1;
                        product = value;
                        countIndex1 = i;
                    }
                    else
                    {
                        while (countIndex2 >= countIndex1)
                        {
                            value /= nums[countIndex2];
                            countIndex2--;
                            if (value < k)
                            {
                                result += countIndex2 - countIndex1 + 1 + 1;
                                countIndex1 = i;
                                product = value;
                                break;
                            }
                        }

                        if (countIndex1 > countIndex2)
                        {
                            if (nums[i] < k)
                            {
                                countIndex1 = countIndex2 = i;
                                product = nums[i];
                                result++;
                            }
                        }
                    }
                }
            }

            return result; 
        }

        public int AuxMet4(int[] nums, int k)
        {
            int result = 0;

            //List<int> resultArraySub = null;
            int[] resultArraySub = null;
            int resultArraySubCount = 0;
            if (nums[nums.Length - 1] < k)
            {
                resultArraySub = new int[] { nums[nums.Length - 1] };
                resultArraySubCount++;
                result++;
            }
            else
            {
                resultArraySub = new int[0];
                resultArraySubCount = 0;
            }

            for (int i = nums.Length - 2; i > -1; i--)
            {
                if (nums[i] >= k)
                {
                    resultArraySub = new int[0];
                    resultArraySubCount = 0;
                    continue;
                }
                int[] listArray = new int[resultArraySubCount + 1];
                int listArrayCount = 0;
                listArray[listArrayCount++] = nums[i];
                result++;
                if (resultArraySubCount > 0)
                {
                    int maxIndex = MaxLessBicotomicSearchProduct(resultArraySub, resultArraySubCount, k, nums[i]);
                    for (int j = 0; j < maxIndex + 1; j++)
                    {
                        int val = resultArraySub[j] * nums[i];
                        listArray[listArrayCount++] = val;
                        result++;
                    }
                }
                resultArraySub = listArray;
                resultArraySubCount = listArrayCount;
            }

            return result;
        }

        private int MaxLessBicotomicSearchProduct(int[] resultArraySub, int resultArraySubCount, int k, int numsi)
        {
            int minIndex = 0;
            int maxIndex = resultArraySubCount-1;
            if (resultArraySub[maxIndex] * numsi < k)
                return maxIndex;
            int midleIndex = (maxIndex + minIndex) / 2; 
            while ( maxIndex - minIndex > 1 )
            {
                midleIndex = (maxIndex + minIndex) / 2;
                if (resultArraySub[midleIndex] * numsi < k)
                {
                    minIndex = midleIndex;
                }
                else
                {
                    maxIndex = midleIndex - 1;
                }   
            }
            if (resultArraySub[maxIndex] * numsi < k)
                return maxIndex;
            if (resultArraySub[minIndex] * numsi < k)
                return minIndex;

            return -1;
        }

        public int AuxMet3(int[] nums, int k)
        {
            int result = 0;

            //List<int> resultArraySub = null;
            int [] resultArraySub = null;
            int resultArraySubCount = 0;
            if (nums[nums.Length - 1] < k)
            {
                resultArraySub = new int[] { nums[nums.Length - 1] };
                resultArraySubCount++;
                result++;
            }
            else
            {
                resultArraySub = new int[0];
                resultArraySubCount = 0;
            }

            for (int i = nums.Length - 2; i > -1; i--)
            {
                if (nums[i] >= k)
                {
                    resultArraySub = new int[0];
                    resultArraySubCount = 0;
                    continue;
                }
                int[] listArray = new int[resultArraySub.Length + 1];
                int listArrayCount = 0;
                listArray[listArrayCount++] = nums[i];
                result++;
                for (int j = 0 ; j < resultArraySubCount; j++)
                    {
                    int val = resultArraySub[j] * nums[i];
                    if (val < k)
                    {
                        listArray[listArrayCount++]= val;
                        result++;
                    }
                    else
                        break;                    
                }
                resultArraySub = listArray;
                resultArraySubCount = listArrayCount;
            }

            return result;
        }

        public int AuxMet2(int[] nums, int k, int index, out int[] resultArray)
        {
            int result = 0;
            resultArray = new int[0];
            if (index == nums.Length - 1)
            {
                if (nums[index] < k)
                {
                    result += 1;
                    resultArray = new int[] { nums[index] };
                }
            }

            else
            {
                if (nums[index] < k)
                {

                    int[] resultArraySub;
                    result += AuxMet2(nums, k, index + 1, out resultArraySub);
                    List<int> listArray = new List<int>(resultArraySub.Length + 1);
                    listArray.Add(nums[index]);
                    result++;

                    for (int i = 0; i < resultArraySub.Length; i++)
                    {
                        int val = resultArraySub[i] * nums[index];
                        if (val < k)
                        {
                            listArray.Add(val);
                            result++;
                        }
                        else
                            break;
                    }
                    resultArray = listArray.ToArray();
                }
            }

            return result;
        }
    }
}
