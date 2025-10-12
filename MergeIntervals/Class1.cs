namespace MergeIntervals;

public class Solution
{
    public int[][] Merge2(int[][] intervals)
    {
        int?[] arrayFirstIndexList = new int?[10_001];

        for (int i = 0; i < intervals.Length; i++)
        {
            var interval = intervals[i];
            var arrayFirstIndexListValue = arrayFirstIndexList[interval[0]];
            if (arrayFirstIndexListValue == null || arrayFirstIndexListValue < interval[1])
                arrayFirstIndexList[interval[0]] = interval[1];
        }

        List<int[]> result = new List<int[]>();
        for (int i = 0; i < 10_001; i++)
        {
            if (arrayFirstIndexList[i] == null)
                continue;

            int intervalIndex2 = arrayFirstIndexList[i]!.Value;

            for (int j = i+1; j <= intervalIndex2; j++)
            {
                if (arrayFirstIndexList[j] == null)
                    continue;
                else
                {
                    if (intervalIndex2 < arrayFirstIndexList[j])
                        intervalIndex2 = arrayFirstIndexList[j]!.Value;
                }
            }

            result.Add(new int[] { i, intervalIndex2 });
            i = intervalIndex2;
        }

        return result.ToArray();
    }
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals.Select(e => e[0]).ToArray(), intervals);
        int[][] uniqueIntervals = new int[intervals.Length][];
        int uniqueIntervalsLength = 0;

        for (int i = 0; i < intervals.Length; i++)
        {
            int intervalIndex1 = i;
            int intervalIndex2 = i;
            int maxIndex2 = intervals[i][1];
            for (int j = i+1; j < intervals.Length; j++)
            {
                if (intervals[intervalIndex1][0] == intervals[j][0])
                {
                    intervalIndex2 = j;
                    if (maxIndex2 < intervals[j][1])
                        maxIndex2 = intervals[j][1];
                }
                else
                    break;
            }

            uniqueIntervals[uniqueIntervalsLength++] = new int[] { intervals[intervalIndex1][0], maxIndex2 };
            i = intervalIndex2;
        }
        List<int[]> result = new List<int[]>(uniqueIntervals.Length);
        for (int i = 0; i < uniqueIntervalsLength; i++)
        {
            int index2 = uniqueIntervals[i][1];
            int j = i + 1;
            for (; j < uniqueIntervalsLength; j++)
            {
                if (index2 >= uniqueIntervals[j][0])
                {
                    if (uniqueIntervals[j][1] > index2)
                        index2 = uniqueIntervals[j][1];
                }
                else
                {
                    break;
                }
            }

            result.Add(new int[] { uniqueIntervals[i][0], index2 });
            i = j - 1;
        }

        return result.ToArray();
    }
}
