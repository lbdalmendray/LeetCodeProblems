namespace ContainerWithMostWater;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int?[] minXArray = new int?[ 10_001]; 
        int?[] maxXArray = new int?[ 10_001];

        for (int i = 0; i < height.Length; i++)
        {
            int cHeight = height[i];
            if ( minXArray[cHeight] == null || minXArray[cHeight] > i )
            {
                minXArray[cHeight] = i;
            }

            if (maxXArray[cHeight] == null || maxXArray[cHeight] < i)
            {
                maxXArray[cHeight] = i;
            }
        }

        int result = 0;
        int minX = int.MaxValue;
        int maxX = int.MinValue;

        for (int h = 10_000; h > -1; h--)
        {
            if (minXArray[h] == null)
                continue;
            else
            {
                if (minXArray[h] < minX)
                    minX = minXArray[h]!.Value;

                if (maxXArray[h] > maxX)
                    maxX = maxXArray[h]!.Value;

                int cResult = (maxX - minX) * h;
                if (result < cResult)
                    result = cResult;
            }
        }

        return result;
    }

    public int MaxArea1(int[] height)
    {
        int[] positions = new int[height.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = i;
        }

        Array.Sort(height, positions);

        int minX;
        int maxX;
        if (positions[positions.Length - 1] > positions[positions.Length - 2])
        {
            minX = positions[positions.Length - 2];
            maxX = positions[positions.Length - 1];
        }
        else
        {
            minX = positions[positions.Length - 1];
            maxX = positions[positions.Length - 2];
        }

        int result = (maxX - minX) * height[positions.Length - 2];

        for (int i = positions.Length - 3; i > -1 ; i--)
        {
            int X = positions[i];

            if (X < minX)
                minX = X;
            if (X > maxX)
                maxX = X;
            int cResult = (maxX - minX) * height[i];
            if (result < cResult)
                result = cResult;
        }

        return result;
    }
}
