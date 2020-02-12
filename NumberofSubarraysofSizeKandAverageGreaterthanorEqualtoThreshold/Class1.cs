using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofSubarraysofSizeKandAverageGreaterthanorEqualtoThreshold
{
    public class Solution
    {
        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] += arr[i - 1];
            }

            int count = 0;

            var thresholdProdK = threshold * k;

            if (arr[k - 1] >= thresholdProdK)
                count++;

            int lastIndex = arr.Length - k;
            for (int i = 1; i <= lastIndex; i++)
            {
                if (arr[i + k - 1] - arr[i - 1] >= thresholdProdK)
                    count++;
            }
            return count;
        }

        public int NumOfSubarrays1(int[] arr, int k, int threshold)
        {
            int[] sum = new int[arr.Length];
            sum[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum[i] = sum[i - 1] + arr[i];
            }

            int count = 0;

            for (int i = 0; i <= arr.Length - k ; i++)
            {
                double currentSum = sum[i + k - 1] - (i > 0 ? sum[i - 1] : 0);
                if (currentSum / k >= threshold)
                    count++;
            }
            return count;
        }
    }
}
