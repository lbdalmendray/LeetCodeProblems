using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubstringwithConcatenationofAllWords
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            if( s== null || s.Length == 0 || words == null || words.Length == 0)
            {
                return new List<int>();
            }

            Dictionary<string, Info> compactInfo = new Dictionary<string, Info>(words.Length);
            int wordIntValue = 0;
            foreach (var item in words)
            {
                if( !compactInfo.ContainsKey(item))
                {
                    compactInfo.Add(item, new Info { Count = 1 , WordIntValue  = wordIntValue++});
                }
                else
                    compactInfo[item].Count++;
            }

            SortedDictionary<int, Info> sortedDic = new SortedDictionary<int, Info>();
            foreach (var keyInfo in compactInfo)
            {
                foreach (var matchIndex in KMP_Matcher(s, keyInfo.Key))
                {
                        sortedDic.Add(matchIndex, keyInfo.Value);
                }
            }

            int wordLength = words[0].Length;
            LinkedList<KeyValuePair<int, Info>>[] lists = Enumerable.Range(0, wordLength).Select(e => new LinkedList<KeyValuePair<int, Info>>()).ToArray();

            foreach (var item in sortedDic)
            {
                lists[item.Key % wordLength].AddLast(item);
            }

            LinkedList<int> result = new LinkedList<int>();

            ulong [] compactInfoByWordIntValue = new ulong [wordIntValue];

            foreach (var item in compactInfo)
            {
                compactInfoByWordIntValue[item.Value.WordIntValue] = item.Value.Count;
            }

            foreach (var list in lists.Where(e=>e.Count>0))
            {
                LinkedList<LinkedList<KeyValuePair<int, Info>>> subLists = new LinkedList<LinkedList<KeyValuePair<int, Info>>>();
                var currentSubList = new LinkedList<KeyValuePair<int, Info>>();
                subLists.AddLast(currentSubList);
                currentSubList.AddLast(list.First.Value);
                var currentNode = list.First.Next;
                while(currentNode != null)
                {
                    if(  currentNode.Value.Key - wordLength == currentNode.Previous.Value.Key )
                    {
                        currentSubList.AddLast(currentNode.Value);
                    }
                    else
                    {
                        currentSubList = new LinkedList<KeyValuePair<int, Info>>();
                        subLists.AddLast(currentSubList);
                        currentSubList.AddLast(currentNode.Value);
                    }
                    currentNode = currentNode.Next;
                }

                foreach (var subList in subLists)
                {
                    int wordCount = 0;
                    ulong[] infoCounter = new ulong[compactInfoByWordIntValue.Length];

                    LinkedList<LinkedListNode<KeyValuePair<int, Info>>>[] myLists = Enumerable.Range(0, wordIntValue).Select(e => new LinkedList<LinkedListNode<KeyValuePair<int, Info>>>()).ToArray();

                    currentNode = subList.Last;
                    while (currentNode != null)
                    {
                        var item = currentNode.Value;

                        int currentWordIntValue = item.Value.WordIntValue;
                        infoCounter[currentWordIntValue]++;
                        myLists[currentWordIntValue].AddFirst(currentNode);
                        wordCount++;
                        if (infoCounter[currentWordIntValue] > compactInfoByWordIntValue[currentWordIntValue])
                        {
                            var node = myLists[currentWordIntValue].Last.Value;
                            var currentNodeRemove = subList.Last;
                            while(currentNodeRemove != node)
                            {
                                infoCounter[currentNodeRemove.Value.Value.WordIntValue]--;                                
                                myLists[currentNodeRemove.Value.Value.WordIntValue].RemoveLast();
                                subList.RemoveLast();
                                wordCount--;
                                currentNodeRemove = subList.Last;
                            }

                            infoCounter[node.Value.Value.WordIntValue]--;
                            myLists[node.Value.Value.WordIntValue].RemoveLast();
                            subList.RemoveLast();
                            wordCount--;
                        }
                        
                        if( wordCount == words.Length)
                        {
                            result.AddLast(currentNode.Value.Key);
                        }

                        currentNode = currentNode.Previous;
                    }
                }
                
            }

            return result.ToList();

        }

        
        static public int[] KMP_Matcher(string text, string pattern)
        {
            LinkedList<int> matchIndexes = new LinkedList<int>();
            var pi = Compute_Prefix_Function(pattern);
            var q = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (q > 0 && pattern[q] != text[i])
                {
                    q = pi[q - 1];  
                }

                if (pattern[q] == text[i])
                {
                    q++;
                }

                if (q == pattern.Length)
                {
                    matchIndexes.AddLast(i - pattern.Length + 1);
                    q = pi[q - 1];
                }
            }

            return matchIndexes.ToArray();
        }

        static public int[] Compute_Prefix_Function(string pattern)
        {
            int[] pi = new int[pattern.Length];
            int k = 0;
            pi[0] = 0;  

            for (int q = 2; q <= pattern.Length; q++)
            {
                while (k > 0 && pattern[k] != pattern[q - 1])
                {
                    k = pi[k - 1];
                }

                if (pattern[k] == pattern[q - 1])
                {
                    k++;
                }

                pi[q - 1] = k;
            }

            return pi;
        }
    }

    internal class Info
    {
        public ulong Count { get; set; }
        public int WordIntValue { get; internal set; }
    }
}
