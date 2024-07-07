namespace MaximalNetworkRank;

public class Solution
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        int[] counter = new int[n];
        HashSet<(int, int)> relationships = new HashSet<(int, int)>();

        foreach (var road in roads)
        {
            counter[road[0]]++;
            counter[road[1]]++;
            relationships.Add((road[0], road[1]));
            relationships.Add((road[1], road[0]));
        }

        int result = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                var current = counter[i] + counter[j] + (relationships.Contains((i, j)) ? -1 : 0);
                result = Math.Max(result, current);
            }
        }

        return result;
    }
}
