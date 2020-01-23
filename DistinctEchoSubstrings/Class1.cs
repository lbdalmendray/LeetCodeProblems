using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctEchoSubstrings
{
    public class Solution
    {
        /// <summary>
        /// Version 2 . That is better to understand . 
        /// Complexity Time = O(N*N*N)
        /// The Leetcode Discuss has many solutions using Hash Function . The order is O(N*N)
        /// but in my opinion this solution are not correct because 2 different substrings of text
        /// could have the same Hash Code ( a collision ) . It seems that the test set of Leetcode is 
        /// not as big as it should be to show this kind of collision ( it is difficult to implent that) .
        /// The Hashcode used has "long" type : with a 9,223,372,036,854,775,807 of positive values.
        /// If we think about two different strings with each one has length 1000, then each string 
        /// could have 9.4047654906449552630730711540332e+1414‬ possibilities of values that are by far 
        /// greater than the "long" type posibilities . That could never ensure that the Hash code could not 
        /// have a collision . 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int DistinctEchoSubstrings(string text)
        {
            short?[,] infos = new short?[text.Length, text.Length];
            HashSet<string> container = new HashSet<string>();
            for (int i = 0; i < text.Length - 1 ; i++)
            {
                for (int j = i+1; j < text.Length; j++)
                {
                    if (text[i] != text[j])
                        continue;
                    var res = Calculate(text, i, j, infos);
                    if (i + res >= j)
                    {
                        var subString = text.Substring(i, 2*(j - i) );
                        container.Add(subString);
                    }
                }
            }
                        
            return container.Count;
            //return result;
        }



        private short Calculate(string text, int i, int j, short?[,] infos)
        {
            if (infos[i, j].HasValue)
                return infos[i, j].Value;

            short result = 1;

            if (j < text.Length - 1 && text[i + 1] == text[j + 1])
                result += Calculate(text, i + 1, j + 1, infos);

            infos[i, j] = result;
            return result;
        }

        /// <summary>
        /// Version 1
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int DistinctEchoSubstringsVersion1(string text)
        {
            int?[,] infos = new int?[text.Length, text.Length];
            LinkedList<int>[] dict = new LinkedList<int>[26];
            LinkedList<int>[] linkedList = new LinkedList<int>[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (dict[text[i] - 'a'] != null)
                {
                    dict[text[i] - 'a'].AddLast(i);
                }
                else
                {
                    var list = new LinkedList<int>();
                    list.AddLast(i);
                    dict[text[i] - 'a'] = list;
                }
            }
            HashSet<string> container = new HashSet<string>();
            int result = 0;

            foreach (var list in dict.Where(e => e != null))
            {
                var firstNode = list.First;

                while (firstNode.Next != null)
                {
                    int i = firstNode.Value;
                    var nextNode = firstNode.Next;

                    while (nextNode != null)
                    {
                        var nextIndex = nextNode.Value;
                        var res = CalculateVersion1(text, i, nextIndex, infos, linkedList);
                        if (i + res >= nextIndex)
                        {
                            var lastIndex = nextIndex + (nextIndex - i) - 1;
                            var subString = text.Substring(i, lastIndex - i + 1);
                            if (!container.Contains(subString))
                            {
                                container.Add(subString);
                                result++;
                            }
                        }
                        nextNode = nextNode.Next;
                    }
                    firstNode = firstNode.Next;
                }
            }
            return result;
        }

        private int CalculateVersion1(string text, int i, int j, int?[,] infos, LinkedList<int>[] linkedList)
        {
            if (infos[i, j].HasValue)
                return infos[i, j].Value;

            int result = 1;

            if (j < text.Length - 1 && text[i + 1] == text[j + 1])
                result += CalculateVersion1(text, i + 1, j + 1, infos, linkedList);

            infos[i, j] = result;
            return infos[i, j].Value;
        }
    }    
}
