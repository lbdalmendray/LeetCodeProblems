using System;
using System.Collections.Generic;
using System.Linq;

namespace MostCommonWord
{
    public class Solution
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<char> symbols = new HashSet<char>("!?',;.");

            paragraph = new string(paragraph.Where(c=>!symbols.Contains(c)).ToArray());
            paragraph = paragraph.ToLower();

            HashSet<string> bannedHashSet = new HashSet<string>(banned);
            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            for (int i = 0; i < paragraph.Length; i++)
            {
                if (paragraph[i] != ' ')
                {
                    int index1 = i;
                    int index2Plus1 = index1 + 1;
                    for (; index2Plus1 < paragraph.Length; index2Plus1++)
                    {
                        if(paragraph[index2Plus1]== ' ')
                        {
                            int index2 = index2Plus1 - 1;
                            string word = paragraph.Substring(index1, index2 - index1 + 1);
                            if( !wordCounter.ContainsKey(word))
                            {
                                wordCounter[word] = 0;
                            }
                            wordCounter[word]++;
                            break;
                        }
                    }
                    if ( index2Plus1 == paragraph.Length)
                    {
                        int index2 = index2Plus1 - 1;
                        string word = paragraph.Substring(index1, index2 - index1 + 1);
                        if (!wordCounter.ContainsKey(word))
                        {
                            wordCounter[word] = 0;
                        }
                        wordCounter[word]++;
                        break;
                    }
                    else
                    {
                        i = index2Plus1 - 1;
                    }
                }
            }

            var wordCounterArray = wordCounter
                .Where(kv=>!bannedHashSet.Contains(kv.Key))
                .ToArray();
            int bestIndex = 0;
            for (int i = 1; i < wordCounterArray.Length; i++)
            {
                if( wordCounterArray[i].Value > wordCounterArray[bestIndex].Value)
                {
                    bestIndex = i;
                }
            }
            return wordCounterArray[bestIndex].Key;
        }
    }
}
