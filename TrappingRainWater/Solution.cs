using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length == 0)
                return 0;

            return Trap(height, 0);
        }

        public int Trap(int[] height, int i)
        {
            if (i == height.Length - 1)
            {
                return 0;
            }

            if (height[i] <= height[i + 1])
            {
                return Trap(height, i + 1);
            }
            else
            {
                int lastWaterIndexSide = -1;
                if (ExistWaterZone(height, i, out lastWaterIndexSide))
                {
                    return CalculateWater(height, i, lastWaterIndexSide) + Trap(height, lastWaterIndexSide);
                }
                else
                {
                    return Trap(height, i + 1);
                }
            }
        }

        public int CalculateWater(int[] height, int i, int lastWaterIndexSide)
        {
            int sum = 0;
            int maxHeigth = Math.Min(height[i], height[lastWaterIndexSide]);

            for (int j= i+1 ;  j<= lastWaterIndexSide-1; j++)
            {
                sum += height[j];
            }
            sum += 2*maxHeigth;

            int result = maxHeigth * (lastWaterIndexSide - i + 1);
            result -= sum;

            return result;
        }

        private bool ExistWaterZone(int[] height, int i, out int lastIndexSide)
        {
            lastIndexSide = i+1;
            if (i == height.Length - 2) // Three indexes at least 
                return false;

            for (int k = i+2; k < height.Length; k++)
            {
                if ( height[k]>= height[i])
                {
                    lastIndexSide = k;
                    return true;
                }
                else if ( height[k] > height[lastIndexSide] )
                {
                    lastIndexSide = k;
                }
            }

            if (height[lastIndexSide] > height[i + 1])
                return true;
            
            return false;
        }
    }
}
