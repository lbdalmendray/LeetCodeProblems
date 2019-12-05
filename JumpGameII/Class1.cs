using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGameII
{
    public class Solution
    {
        public int Jump(int[] nums)
        {
            int[] infos = new int[nums.Length];

            for (int i = nums.Length - 2 ; i >= 0; i--)
            {
                if (nums[i] == 0)
                    infos[i] = int.MaxValue;
                else
                {
                    var min = Min(infos, i + 1, Math.Min(i + nums[i], nums.Length - 1));
                    if (min == int.MaxValue)
                        infos[i] = int.MaxValue;
                    else
                        infos[i] = 1 + min; ;
                }
            }

            return infos[0];
        }

        private int Min(int[] infos, int index1, int index2)
        {
            var result = infos[index1];

            for (int i = index1+1; i <= index2; i++)
            {
                if (infos[i] < result)
                    result = infos[i];
            }

            return result;
        }
    }
}
