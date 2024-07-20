namespace MaximalNetworkRank;

public class Solution
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        int[] counter = new int[n];

        foreach (var road in roads)
        {
            counter[road[0]]++;
            counter[road[1]]++;
        }

        int best = 0;

        for (int i = best+1; i < n; i++)
        {
            if (counter[i] > counter[best])
                best = i;
        }
        var bestCounter = counter[best];

        int secondBest = best == 0 ? 1 : 0;
        if (counter[secondBest] != bestCounter)
        {
            for (int i = secondBest + 1; i < n; i++)
            {
                if (i != best && counter[i] > counter[secondBest])
                {
                    secondBest = i;
                    if (counter[secondBest] == bestCounter)
                        break;
                }
            }
        }

        var secondBestCounter = counter[secondBest];

        if (bestCounter == secondBestCounter)
        {
            HashSet<(int, int)> relationships = new HashSet<(int, int)>();

            foreach (var road in roads)
            {
                if (counter[road[0]] == bestCounter 
                    && counter[road[1]] == bestCounter )
                {
                    relationships.Add((road[0], road[1]));
                    relationships.Add((road[1], road[0]));
                }
            }

            var bests = counter.Select((e, i) => (Count: e, Element: i))
                .Where(e => e.Count == bestCounter)
                .Select(e => e.Element)
                .ToArray();

            int result = 0;

            for (int i = 0; i < bests.Length; i++)
            {
                var besti = bests[i];

                for (int j = i+1; j < bests.Length; j++)
                {
                    var bestj = bests[j];

                    if (relationships.Contains((besti, bestj)))
                    {
                        if (result == 0)
                            result = bestCounter + bestCounter - 1;
                    }
                    else
                    {
                        return bestCounter + bestCounter;
                    }
                }
            }

            return result;
        }
        else
        {            
            HashSet<(int, int)> relationships = new HashSet<(int, int)>();

            foreach (var road in roads)
            {
                if (road[0] == best && counter[road[1]] == secondBestCounter 
                    || road[1] == best && counter[road[0]] == secondBestCounter)
                {
                    relationships.Add((road[0], road[1]));
                    relationships.Add((road[1], road[0]));
                }
            }

            int result = 0;

            var seconds = counter.Select((e, i) => (Count: e, Element: i))
                .Where(e => e.Count == secondBestCounter)
                .Select(e=>e.Element);

            foreach (var second in seconds)
            {
                if ( relationships.Contains((best,second)))
                {
                    if (result == 0)
                        result = bestCounter + secondBestCounter - 1;
                }
                else
                {
                    return bestCounter + secondBestCounter;
                }
            }

            return result;
        }
    }

    public int MaximalNetworkRank1(int n, int[][] roads)
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
            for (int j = i + 1; j < n; j++)
            {
                var current = counter[i] + counter[j];
                if (relationships.Contains((i, j)))
                {
                    current--;
                }
                if (result < current)
                    result = current;
            }
        }

        return result;
    }
}
