namespace KokoEatingBananas;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        if (piles.Select(e=>(long)e)
                 .Sum() <= h)
            return 1;
        else
        {
            Array.Sort(piles);
            List<(int value, int counter)> valueList = new List<(int, int)>(piles.Length);
            for (int i = 0; i < piles.Length; i++)
            {
                int firstIndex = i;
                int lastIndex = i;
                for (int j = i + 1; j < piles.Length; j++)
                {
                    if (piles[firstIndex] == piles[j])
                        lastIndex = j;
                    else
                        break;
                }
                valueList.Add((piles[firstIndex], lastIndex - firstIndex + 1));
                i = lastIndex;
            }

            int result = BinarySearch(1, piles[piles.Length - 1], valueList, h);
            return result;
        }
    }

    private int BinarySearch( int v1, int v2, List<(int value, int counter)> valueList, long h)
    {
        //// V2 is always GOOD AND v1 is always BAD 
        
        while ( v2 - v1 > 1)
        {
            int vMid = (v1 + v2) / 2;
            long vMidSum = CalculateHoursFor(vMid, valueList);
            if ( vMidSum > h)
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

    private long CalculateHoursFor(int currentValue, List<(int value, int counter)> valueList)
    {
        long result = 0;

        for (int i = 0; i < valueList.Count; i++)
        {
            (int value, int counter) = valueList[i];
            int cResult = value / currentValue;
            if (value % currentValue != 0)
                cResult += 1;
            result += cResult*counter;
        }

        return result;
    }
}
