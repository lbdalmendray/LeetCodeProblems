using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TrappingRainWater
{
    /// <summary>
    /// Complexity Time = O(N)
    /// Complexity Space = O(N)
    /// My explanation is FIND the highest Height = Hh.
    /// This Hh will split the height array in two sides = right and left side.
    /// Then the idea is to do the same going in to one direction , then do the equivalent 
    /// to the other direction .
    /// If we get the Right : The idea is to find the first location where we can trap water .
    /// That first location is where as a function we find a minimum of that function . 
    /// In other words the first location that we obtain a change from a value to a greater value,
    /// because we at first we came from the highest value in that section . 
    /// If that locationn does not exist then we cannot trap any water then in that section the 
    /// result is 0
    /// If that location exists then we need to find to the right the highest height after the Hh.
    /// Lets call this additional height Hh2
    /// With this two height we find a water trap zone and we can calculate that water in O(subN)
    /// with subN = the amount of element between the two heights . 
    /// This subResult will be added to the total result . 
    /// Then we have the same problem from Hh2 to the right and repeated just when we get the end 
    /// or find that the next section is not a trap water . 
    /// We need to do the equivalent to the Left . 
    /// </summary>
    public class Solution3
    {
        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int[] maxRight = GetMaxRight(height);
            int[] maxLeft = GetMaxLeft(height);

            int maxIndex = maxRight[0];

            int result = TrapRight(maxIndex, maxRight, height);

            result += TrapLeft(maxIndex, maxLeft, height);

            return result;
        }
        int TrapLeft(int maxIndex, int[] maxLeft, int[] height)
        {
            int result = 0;

            while (maxIndex > 0)
            {
                int[] resultMaxIndex = TrapLeftAux(maxIndex, maxLeft, height);
                result += resultMaxIndex[0];
                maxIndex = resultMaxIndex[1];
            }

            return result;
        }

        int TrapRight(int maxIndex, int[] maxRight, int[] height)
        {
            int result = 0;

            while (maxIndex < height.Length - 1)
            {
                int[] resultMaxIndex = TrapRightAux(maxIndex, maxRight, height);
                result += resultMaxIndex[0];
                maxIndex = resultMaxIndex[1];
            }

            return result;
        }

        int[]  TrapLeftAux(int maxIndex, int [] maxLeft, int [] height)
        {
            int result = 0;

            int changeIndex = maxIndex;
            for (; changeIndex > 0 ; changeIndex -- )
            {
                if (height[changeIndex] < height[changeIndex - 1])
                    break;
            }

            if (changeIndex == 0)
            {
                maxIndex = 0;
                return new int[] { result, maxIndex };
            }
            else
            {
                int maxIndex2 = maxLeft[changeIndex - 1];
                var rectangle = height[maxIndex2] * (maxIndex - maxIndex2  + 1);

                int sum = Sum(maxIndex2, maxIndex, height, height[maxIndex2]);
                result = rectangle - sum;
                return new int[] { result, maxIndex2 };
            }
        }

        int [] TrapRightAux(int maxIndex, int[] maxRight, int[] height)
        {
            int result = 0;

            int changeIndex = maxIndex;
            for (; changeIndex < height.Length-1; changeIndex++)
            {
                if (height[changeIndex] < height[changeIndex + 1])
                    break;
            }

            if ( changeIndex == height.Length-1)
            {
                maxIndex = height.Length - 1;
                return new int[] { result, maxIndex };
            }
            else
            {
                int maxIndex2 = maxRight[changeIndex + 1];
                var rectangle = height[maxIndex2] * (maxIndex2 - maxIndex + 1);
                
                int sum = Sum(maxIndex, maxIndex2, height, height[maxIndex2]);
                result = rectangle - sum;
                return new int[] { result, maxIndex2 };
            }
        }

        int Sum(int maxIndex, int maxIndex2, int [] height, int maxValue )
        {
            int result = 0;

            for(;maxIndex <= maxIndex2; maxIndex++)
            {
                result += Math.Min(maxValue, height[maxIndex]);
            }
            return result;
        }

        int []  GetMaxRight(int [] height)
        {
            int[] result = new int[height.Length];
            result[height.Length - 1] = height.Length - 1;
            for ( int i = height .Length -2; i > -1; i--)
            {
                if (height[result[i + 1]] > height[i])
                    result[i] = result[i + 1];
                else
                    result[i] = i;
            }

            return result;
        }

        int[] GetMaxLeft(int[] height)
        {
            int[] result = new int[height.Length];
            for( int i = 1; i < height.Length; i++)
            {
                if (height[result[i - 1]] > height[i])
                    result[i] = result[i - 1];
                else
                    result[i] = i;
            }

            return result;
        }
    }
}
