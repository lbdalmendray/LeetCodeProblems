namespace ContainerWithMostWater;

public class Solution
{
    public int MaxArea(int[] height)
    {
        (int X, int Y)[] positions = new (int X, int Y)[height.Length];

        for (int i = 0; i < height.Length; i++)
        {
            positions[i] = (i, height[i]);
        }

        Array.Sort(height, positions);

        int minX;
        int maxX;
        if (positions[positions.Length - 1].X > positions[positions.Length - 2].X)
        {
            minX = positions[positions.Length - 2].X;
            maxX = positions[positions.Length - 1].X;
        }
        else
        {
            minX = positions[positions.Length - 1].X;
            maxX = positions[positions.Length - 2].X;
        }

        int result = (maxX - minX) * positions[positions.Length - 2].Y;

        for (int i = positions.Length - 3; i > -1 ; i--)
        {
            (int X, int Y) = positions[i];
            if (X < minX)
                minX = X;
            if (X > maxX)
                maxX = X;
            int cResult = (maxX - minX) * Y;
            if (result < cResult)
                result = cResult;
        }

        return result;
    }
}
