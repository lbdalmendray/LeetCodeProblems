
namespace MaximumSquareAreaBRFFF;

/// <summary>
/// Maximum Square Area by Removing Fences From a Field
/// </summary>
public class Solution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        long? result = null;
        
        /// I COULD NOT FIND A PLACE THAT SAYS THAT THE FANCES ARE SORTED.
        Array.Sort(hFences);
        Array.Sort(vFences);
        /////

        long[] hSums = new long[hFences.Length+1];
        long[] vSums = new long[vFences.Length+1];
        hSums[0] = hFences[0]-1;
        vSums[0] = vFences[0]-1;

        for (int i = 1; i < hFences.Length; i++)
        {
            hSums[i] = hSums[i - 1] + (hFences[i]- hFences[i-1]);
        }

        for (int j = 1; j < vFences.Length; j++)
        {
            vSums[j] = vSums[j - 1] + (vFences[j] - vFences[j-1]);
        }

        hSums[hFences.Length] = hSums[hFences.Length - 1] + (m - hFences[hFences.Length - 1]);
        vSums[vFences.Length] = vSums[vFences.Length - 1] + (n - vFences[vFences.Length - 1]);

        for (int i = 0; i < hSums.Length; i++)
        {
            for (int j = 0; j < vSums.Length; j++)
            {
                long? cResult = Solve(i, j, hSums, vSums);
                if ( cResult.HasValue)
                {
                    result = result.HasValue ? Math.Max(result.Value, cResult.Value) : cResult;
                }
            }
        }

        if (result != null)
            return (int)(result.Value% 1000_000_007) ;
        else
            return -1;
    }

    private long? Solve(int hIndex, int vIndex , long[] hSums, long[] vSums)
    {
        return Solve(hIndex, hSums.Length - 1, vIndex, vSums.Length - 1, hSums, vSums);
    }

    private long? Solve(int hIndex1, int hIndex2, int vIndex1, int vIndex2, long[] hSums, long[] vSums)
    {
        long hSmallSum = hIndex1 > 0 ? hSums[hIndex1 - 1] : 0;
        long hSideLength = hSums[hIndex2] - hSmallSum;

        long vSmallSum = vIndex1 > 0 ? vSums[vIndex1 - 1] : 0;
        long vSideLength = vSums[vIndex2] - vSmallSum;

        if (hSideLength == vSideLength)
            return hSideLength * vSideLength;
        else if (hSideLength > vSideLength)
        {
            int? newhIndex2 = BinarySearch(vSideLength + hSmallSum, hIndex1, hIndex2-1, hSums);
            if (!newhIndex2.HasValue)
                return null;
            else
                return Solve(hIndex1, newhIndex2.Value, vIndex1, vIndex2, hSums, vSums); 
        }
        else
        {
            int? newvIndex2 = BinarySearch(hSideLength + vSmallSum, vIndex1, vIndex2-1, vSums);
            if (!newvIndex2.HasValue)
                return null;
            else
                return Solve(hIndex1, hIndex2, vIndex1, newvIndex2.Value, hSums, vSums);
        }
    }

    private int? BinarySearch(long value, int index1, int index2, long[] sums)
    {
        while( index2 - index1 > 2)
        {
            int midIndex = (index2 + index1) / 2;

            if (value >= sums[midIndex])
            {
                index1 = midIndex;
            }
            else //if ( value < sums[midIndex])
            {
                index2 = midIndex-1;
            }
        }

        for (int i = index2; i >= index1; i--)
        {
            if (value >= sums[i])
                return i;
        }

        return null;
    }
}
