namespace AnalyzeUserWebsiteVisitPattern;

public class Solution
{
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {
        int[] userNameInt = ConvertToIntArray(username,false, out _);
        int[] websiteInt = ConvertToIntArray(website,true, out var reverseDict);
        var websiteIntList = MostVisitedPatterns(userNameInt, timestamp, websiteInt);
        var orderByTuples = websiteIntList.Select(e => (List: new List<string> { reverseDict[e.Item1], reverseDict[e.Item2], reverseDict[e.Item3] }
        , StringValue: $"{reverseDict[e.Item1]}_{reverseDict[e.Item2]}_{reverseDict[e.Item3]}"))
            .OrderBy(e => e.StringValue);
            return orderByTuples.First()
                                .List;
        /// THE WAY TO COMPARE lexicographically THE DIFFERENT TUPLES IS NOT VERY WELL EXPLAINED
        /// MY FIRST APPROACH WAS THE CONCATENATION OF THE WEBSITES IN THE TUPLE BUT IT IS NOT THAT WAY.
        /// IT SEEMS THAT IT IS COMPARING FIRST THE FIRST WEBSITE IN THE TUPLES , THEN THE SECOND AND THEN 
        /// THE THIRD ONE. 
    }

    private List<(int,int,int)> MostVisitedPatterns(int[] userNameInt, int[] timestamp, int[] websiteInt)
    {
        int[] indexes = Enumerable.Range(0, timestamp.Length).ToArray();
        Array.Sort(timestamp, indexes);

        Dictionary<int, List<int>> userWebsitesDict = new Dictionary<int, List<int>>();

        for (int i = 0; i < indexes.Length; i++)
        {
            var userName = userNameInt[indexes[i]];
            if (!userWebsitesDict.TryGetValue(userName, out var list))
            {
                list = new List<int>();
                userWebsitesDict[userName] = list;
            }

            list.Add(websiteInt[indexes[i]]);
        }

        Dictionary<(int, int, int), int> website3Counter = new Dictionary<(int, int, int), int>();

        foreach (var list in userWebsitesDict.Values)
        {
            HashSet<(int, int, int)> hashSet = new HashSet<(int, int, int)>();

            for (int i = 0; i < list.Count-2; i++)
            {
                for (int j = i+1; j < list.Count - 1; j++)
                {
                    for (int k = j+1; k < list.Count; k++)
                    {
                        hashSet.Add((list[i], list[j], list[k]));
                    }
                }
            }

            foreach (var item in hashSet)
            {
                if (!website3Counter.TryGetValue(item, out var count))
                    website3Counter[item] = 1;
                else
                    website3Counter[item] = count + 1;
            }
        }

        int maxCounter = website3Counter.Values.Max();
        return website3Counter.Where(kv => kv.Value == maxCounter)
            .Select(e => e.Key).ToList();
    }

    private int[] ConvertToIntArray(string[] stringArray, bool getReverse, out Dictionary<int,string>? reverseDict)
    {
        var distStringValue =  stringArray
                                    .Distinct()
                                    .Select((e,i)=>(e,i));
        var dict = distStringValue.ToDictionary(e => e.e, e => e.i);
        if (getReverse)
            reverseDict = distStringValue.ToDictionary(e => e.i, e => e.e);
        else
            reverseDict = null;
        return stringArray.Select(e=> dict[e]).ToArray();
    }
}
