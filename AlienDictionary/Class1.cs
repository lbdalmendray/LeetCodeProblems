using System;
using System.Collections.Generic;
using System.Linq;

namespace AlienDictionary
{
    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            /// TODO 
            Dictionary<char, HashSet<char>> graph = GenerateGraph(words);

            LinkedList<char> result = new LinkedList<char>();
            if (DFSHasCycle(graph, result))
                return "";
            return new string(result.ToArray());
        }

        private Dictionary<char, HashSet<char>> GenerateGraph(string[] words)
        {
            Dictionary<char, HashSet<char>> result = new Dictionary<char, HashSet<char>>();
            LinkedList<Group> groups = new LinkedList<Group>();
            Group group1 = new Group { Words = words, Index = 0 };
            groups.AddLast(group1);
            while (groups.Count != 0)
            {
                var group = groups.First.Value;
                groups.RemoveFirst();
                var wordsArray = group.Words.ToArray();
                int cIndex = group.Index;

                for (int i = 0; i < wordsArray.Length-1; i++)
                {
                    if (wordsArray[i][cIndex] == wordsArray[i + 1][cIndex])
                        continue;
                    var car1 = wordsArray[i][cIndex];
                    var car2 = wordsArray[i+1][cIndex];
                    if (!result.TryGetValue(car1, out var set))
                    {
                        set = new HashSet<char>();
                        result[car1] = set;
                    }
                    if (!set.Contains(car2))
                        set.Add(car2);
                }


                for (int i = 0; i < wordsArray.Length; i++)
                {
                    Group groupi = new Group();
                    LinkedList<string> list = new LinkedList<string>();
                    group.Index = cIndex + 1;
                    list.AddFirst(wordsArray[i]);
                    int j = i + 1;
                    for (; j < wordsArray.Length; j++)
                    {
                        if (wordsArray[i][cIndex] != list.First.Value[cIndex])
                            break;
                        list.AddFirst(wordsArray[j]);
                    }
                    i = j-1;
                    group.Words = list.Where(e=> group.Index < e.Length).ToArray();
                    groups.AddLast(groupi);
                }
            }

            return result;
        }

        private bool DFSHasCycle(Dictionary<char, HashSet<char>> graph, LinkedList<char> result)
        {
            HashSet<char> reachList = new HashSet<char>();
            HashSet<char> processing = new HashSet<char>();

            foreach (var letter in graph.Keys)
            {
                if (reachList.Contains(letter))
                    continue;
                if (DFSHasCycle(letter,letter, graph, reachList, processing, result))
                {
                    return true;
                }
            }

            return false;
        }

        private bool DFSHasCycle(char letter, char parent, Dictionary<char, HashSet<char>> graph, HashSet<char> reachList, HashSet<char> processing, LinkedList<char> result)
        {
            reachList.Add(letter);
            processing.Add(letter);

            foreach (var childLetter in graph[letter])
            {
                if (childLetter == letter)
                    continue;
                if (processing.Contains(letter))
                    return true;

                if (reachList.Contains(childLetter))
                    continue;

                if(DFSHasCycle(childLetter, letter, graph, reachList, processing, result))
                    return true;
            }

            result.AddLast(letter);
            processing.Remove(letter);

            return false;
        }
    }

    internal class Group
    {
        internal IEnumerable<string> Words { get; set; }
        internal int Index { get; set; }
    }
}
