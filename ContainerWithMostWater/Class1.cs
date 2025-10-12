namespace ContainerWithMostWater;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int?[] minXArray = new int?[10_001];
        int?[] maxXArray = new int?[10_001];

        int maxHeight = 0;
        int minHeight = 0;
        int heightLength = height.Length;

        //// INITIALIZING minXArray,maxXArray , maxHeight, minHeight 

        for (int i = 0; i < heightLength; i++)
        {
            int cHeight = height[i];
            if (maxHeight < cHeight)
                maxHeight = cHeight;

            if (minXArray[cHeight] == null)
            {
                minXArray[cHeight] = i;
                maxXArray[cHeight] = i;
            }
            else if (minXArray[cHeight] > i)
            {
                minXArray[cHeight] = i;
            }
            else if (maxXArray[cHeight] < i)
            {
                maxXArray[cHeight] = i;
            }
        }

        ////////        

        int result = 0;
        int minX = int.MaxValue;
        int maxX = int.MinValue;
        //// UPDATING minX, maxX AND UPDATING THE result

        for (int h = maxHeight; h >= minHeight; h--)
        {
            if (minXArray[h] != null)
            {
                if (minXArray[h] < minX)
                    minX = minXArray[h]!.Value;

                if (maxXArray[h] > maxX)
                    maxX = maxXArray[h]!.Value;

                int cResult = (maxX - minX) * h;
                if (result < cResult)
                {
                    result = cResult;
                    minHeight = (int)Math.Ceiling((((double)cResult) / heightLength));
                }
            }
        }

        return (int)result;
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

        for (int i = positions.Length - 3; i > -1; i--)
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
