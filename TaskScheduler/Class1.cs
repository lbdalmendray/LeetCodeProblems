using System.Runtime.CompilerServices;

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
            LinkedListNode<Info> nextInfoNode = GetNextAvailableInfoNode(sortedDict, time, n);
            if(nextInfoNode == null)
            {
                nextInfoNode = GetFirstFromSortedDict(sortedDict);
                time = n + nextInfoNode.Value.lastTimeExecuted + 1 ;
            }
            
            RemoveInfoFrom(nextInfoNode, sortedDict);
            
            var info = nextInfoNode.Value;
            info.lastTimeExecuted = time;
            info.count--;
            if (info.count > 0)
                AddInfoTo(info, sortedDict);

            time++;
        }

        return time;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private LinkedListNode<Info> GetFirstFromSortedDict(SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        return sortedDict.First().Value.First!;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddInfoTo(Info nextInfo, SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        if( !sortedDict.TryGetValue(nextInfo.count, out var list))
        {
            list = new LinkedList<Info>();
            sortedDict[nextInfo.count] = list;
        }
        list.AddLast(nextInfo);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void RemoveInfoFrom(LinkedListNode<Info> nextInfoNode, SortedDictionary<int, LinkedList<Info>> sortedDict)
    {
        var list = nextInfoNode.List;
        list.Remove(nextInfoNode);
        if (list.Count == 0)
            sortedDict.Remove(nextInfoNode.Value.count);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private LinkedListNode<Info> GetNextAvailableInfoNode(SortedDictionary<int, LinkedList<Info>> sortedDict, int time, int n)
    {
        foreach (var keyValue in sortedDict)
        {
            var infoNode = keyValue.Value.First;
            if (time - infoNode.Value.lastTimeExecuted > n)
                return infoNode;
            else
                continue;
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
