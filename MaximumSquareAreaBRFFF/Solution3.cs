
namespace MaximumSquareAreaBRFFF;

/// <summary>
/// Maximum Square Area by Removing Fences From a Field
/// </summary>
public class Solution3
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        long? result = null;

        /// I COULD NOT FIND A PLACE THAT SAYS THAT THE FANCES ARE SORTED.
        Array.Sort(hFences);
        Array.Sort(vFences);
        /////

        long[] hSums = new long[hFences.Length + 1];
        long[] vSums = new long[vFences.Length + 1];
        hSums[0] = hFences[0] - 1;
        vSums[0] = vFences[0] - 1;

        int i = 1;
        for (; i < hFences.Length; i++)
        {
            hSums[i] = hSums[i - 1] + (hFences[i] - hFences[i - 1]);
        }

        for (int j = 1; j < vFences.Length; j++)
        {
            vSums[j] = vSums[j - 1] + (vFences[j] - vFences[j - 1]);
        }

        hSums[hFences.Length] = hSums[hFences.Length - 1] + (m - hFences[hFences.Length - 1]);
        vSums[vFences.Length] = vSums[vFences.Length - 1] + (n - vFences[vFences.Length - 1]);

        long[] maxSums;
        long[] minSums;

        if (hSums.Length > vSums.Length)
        {
            maxSums = hSums;
            minSums = vSums;
        }
        else
        {
            maxSums = vSums;
            minSums = hSums;
        }

        HashSet<long> minSides = new HashSet<long>((minSums.Length) * (minSums.Length + 1) / 2);

        i = 0;
        for (int j = i; j < minSums.Length; j++)
        {
            long side = minSums[j];
            minSides.Add(side);
        }

        for (i = 1; i < minSums.Length; i++)
        {
            for (int j = i; j < minSums.Length; j++)
            {
                long side = minSums[j] - minSums[i - 1];
                minSides.Add(side);
            }
        }
        i = 0;
        for (int j = i; j < maxSums.Length; j++)
        {
            long side = maxSums[j];

            if (minSides.Contains(side))
            {
                if (result.HasValue)
                {
                    result = Math.Max(result.Value, side);
                }
                else
                {
                    result = side;
                }
            }
        }

        for (i = 1; i < maxSums.Length; i++)
        {
            for (int j = i; j < maxSums.Length; j++)
            {
                long side = maxSums[j] - maxSums[i - 1];

                if (minSides.Contains(side))
                {
                    if (result.HasValue)
                    {
                        result = Math.Max(result.Value, side);
                    }
                    else
                    {
                        result = side;
                    }
                }
            }
        }

        if (result == null)
            return -1;
        else
        {
            return (int)(result.Value * result.Value % 1000_000_007);
        }
    }
}
