namespace TaskScheduler;

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        //// SORTING ///////////////////////////////////
        
        int[] taskCounter = new int[26];
        for (int i = 0; i < tasks.Length; i++)
        {
            taskCounter[(tasks[i] - 'A')]++;
        }

        Array.Sort(taskCounter);

        ///////////////////////////////////////////////
        /// CREATING INFO LIST
        /// 

        SortedDictionary<int, LinkedList<Info>> sortedDict 
            = new SortedDictionary<int, LinkedList<Info>>(Comparer<int>.Create((a, b) => b - a));

        for (int i = taskCounter.Length - 1; i > -1 ; i--)
        {
            if (taskCounter[i] > 0)
            {
                if (!sortedDict.TryGetValue(taskCounter[i], out var infoList))
                {
                    infoList = new LinkedList<Info>();
                    sortedDict[taskCounter[i]] = infoList;
                }
                infoList.AddLast(new Info(taskCounter[i], -(n + 1)));
            }
            else
                break;
        }

        ////////////////////////////////////////////////
        ///

        int time = 0;
        while(sortedDict.Count > 0)
        {
            LinkedListNode<Info> nextInfo = GetNextAvailableInfo(sortedDict, time, n);
            if ( nextInfo != null)
            {
                RemoveInfoFrom(nextInfo, sortedDict);
                nextInfo.Value.lastTimeExecuted = time;
                nextInfo.Value.count--;
                if (nextInfo.Value.count > 0)
                    AddInfoTo(nextInfo, sortedDict);
            }
            else
            {
                nextInfo = GetFirstFromSortedDict(sortedDict);
                RemoveInfoFrom(nextInfo, sortedDict);
                
                time = n + nextInfo.Value.lastTimeExecuted + 1 ;
                
                nextInfo.Value.lastTimeExecuted = time;
                nextInfo.Value.count--;
                if (nextInfo.Value.count > 0)
                    AddInfoTo(nextInfo, sortedDict);
            }

            time++;
        }

        return time;
    }

    private LinkedListNode<Info> GetFirstFromSortedDict(SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        return sortedDict.First().Value.First!;
    }

    private void AddInfoTo(LinkedListNode<Info> nextInfo, SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        if( !sortedDict.TryGetValue(nextInfo.Value.count, out var list))
        {
            list = new LinkedList<Info>();
            sortedDict[nextInfo.Value.count] = list;
        }
        list.AddLast(nextInfo.Value);
    }

    private void RemoveInfoFrom(LinkedListNode<Info> nextInfo, SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        if (sortedDict.TryGetValue(nextInfo.Value.count, out var list))
        {
            list.Remove(nextInfo);
            if (list.Count == 0)
                sortedDict.Remove(nextInfo.Value.count);
        }       
    }

    private LinkedListNode<Info> GetNextAvailableInfo(SortedDictionary<int, LinkedList<Info>> sortedDict, int time, int n)
    {
        foreach (var keyValue in sortedDict)
        {
            var infoNode = keyValue.Value.First;
            while( infoNode != null)
            {
                if (time - infoNode.Value.lastTimeExecuted > n)
                    return infoNode;
                else
                    infoNode = infoNode.Next;
            }
        }
        return null;
    }

    private class Info
    {
        public int count;
        public int lastTimeExecuted;
        public Info( int count, int lastTimeExecuted)
        {
            this.count = count;
            this.lastTimeExecuted = lastTimeExecuted;
        }
    }
}
