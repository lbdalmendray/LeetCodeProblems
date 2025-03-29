using System.Runtime.CompilerServices;

namespace KokoEatingBananas;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int max = piles[0];
        for (int i = 1; i < piles.Length; i++)
        {
            if (max < piles[i])
                max = piles[i];
        }

        int result = BinarySearch(1, max, piles, h);
        return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int BinarySearch(int v1, int v2, int[] piles, long h)
    {
        //// V2 is always GOOD AND v1 is always BAD except in the case that v1 == 1,
        //// That needs to be calculated.

        while (v2 - v1 > 1)
        {
            int vMid = (v1 + v2) / 2;
            long vMidSum = CalculateHoursFor(vMid, piles);
            if (vMidSum > h)
            {
                v1 = vMid;
            }
            else
            {
                v2 = vMid;
            }
        }

        if (v1 == 1 && v1 != v2 && piles.Sum() <= h)
        {
            return v1;
        }
        else
            return v2;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private long CalculateHoursFor(int currentValue, int[] piles)
    {
        long result = 0;

        for (int i = 0; i < piles.Length; i++)
        {
            int value = piles[i];
            int cResult = Math.DivRem(value, currentValue, out int rem);
            result += cResult;
            if (rem != 0)
                result += 1;
        }

        return result;
    }
}
