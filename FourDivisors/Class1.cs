using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDivisors
{
    public class Solution
    {
        public int SumFourDivisors(int[] nums)
        {
            if (nums == null)
                return 0;

            int result = 0;

            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers.Add(nums[i], 1);
                }
                else
                    numbers[nums[i]]++;
            }

            foreach (var keyValue in numbers)
            {
                HashSet<int> primes = GetPrimes(keyValue.Key);
                var currentSum = 0;
                foreach (var item in primes)
                {
                    currentSum += item;
                }
                if (primes.Count != 0)
                {
                    currentSum += keyValue.Key;
                    currentSum += 1;
                }
                result += currentSum * keyValue.Value;
            }

            return result;
        }

        private HashSet<int> GetPrimes(int v)
        {
            HashSet<int> result = new HashSet<int>();

            var sqrt = Math.Sqrt(v);
            for (int i = 2; i <= sqrt ; i++)
            {
                if (v % i == 0)
                {
                    int vdivi = v / i;
                    if (vdivi == i)
                        result.Add(i);
                    else if (!result.Contains(i))
                    {
                        result.Add(i);
                        result.Add(vdivi);
                    }
                }
                if (result.Count > 2)
                    return new HashSet<int>() ;
            }
            if (result.Count < 2)
                return new HashSet<int>();
            return result;
        }
    }
}
