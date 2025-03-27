namespace KokoEatingBananas;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        if (piles.Select(e => (long)e)
                 .Sum() <= h)
            return 1;
        else
        {
            int result = BinarySearch(1, 1000_000_000, piles, h);
            return result;
        }
    }

    private int BinarySearch(int v1, int v2, int[] piles, long h)
    {
        //// V2 is always GOOD AND v1 is always BAD 

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

        return v2;
    }

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
