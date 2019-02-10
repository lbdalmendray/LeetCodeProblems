using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    /// <summary>
    ///  Esta solución es una mala interpretación que hice 
    /// </summary>
    public class WrongSolution
    {
        public bool IsMatch(string s, string p)
        {
            if (p.Length == 0)
            {
                if (s.Length == 0)
                    return true;
                else
                    return false;
            }

            LinkedList<char> listPattern = new LinkedList<char>();
            if (p.Length > 0)
                listPattern.AddLast(p[0]);

            for (int i = 1; i < p.Length; i++)
            {
                if (listPattern.Last.Value == '*')
                {
                    if (p[i] != '*')
                        listPattern.AddLast(p[i]);
                }
                else
                    listPattern.AddLast(p[i]);
            }

            var pattern = new string(listPattern.ToArray());
            var patternSplit = pattern.Split('*');
            int textIndex = 0;
            int patternSplitIndex = 0;
            if (patternSplit[0] != "")
            {
                if (patternSplit[0].Length <= s.Length)
                {
                    var subString = s.Substring(0, patternSplit[0].Length);
                    for (int i = 0; i < patternSplit[0].Length; i++)
                    {
                        if (patternSplit[0][i] == '.')
                            continue;
                        else if (patternSplit[0][i] != subString[i])
                            return false;

                    }
                }
                else
                    return false;

                textIndex += patternSplit[0].Length;
                patternSplitIndex++;
            }
            else
            {
                patternSplitIndex++;
            }

            if (patternSplit[patternSplit.Length - 1] != "")
            {
                if (patternSplit[patternSplit.Length - 1].Length <= s.Length)
                {
                    var subString = s.Substring(s.Length - 1 - patternSplit[patternSplit.Length - 1].Length + 1);
                    for (int i = 0; i < patternSplit[patternSplit.Length - 1].Length; i++)
                    {
                        if (patternSplit[patternSplit.Length - 1][i] == '.')
                            continue;
                        else if (patternSplit[patternSplit.Length - 1][i] != subString[i])
                            return false;
                    }
                }
                else
                    return false;

                patternSplit = patternSplit.Take(patternSplit.Length - 1).ToArray();
            }
            else
                patternSplit = patternSplit.Take(patternSplit.Length - 1).ToArray();

            return IsMatchBetweenAsters(patternSplit, patternSplitIndex, s, textIndex);

        }

        public bool IsMatchBetweenAsters(string[] patternSplit, int patternSplitIndex, string text, int textIndex)
        {
            if (patternSplit.Length == 0 && textIndex < text.Length)
                return false;

            for (; patternSplitIndex < patternSplit.Length; patternSplitIndex++)
            {
                var result = KMPJustFirst(patternSplit[patternSplitIndex], text, textIndex, text.Length - 1);
                if (result.Count != 0)
                {
                    textIndex = result.First.Value + patternSplit[patternSplitIndex].Length - 1;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public LinkedList<int> KMPJustFirst(string pattern, string text, int index1, int index2)
        {
            LinkedList<int> result = new LinkedList<int>();
            int[] PI = KMP_PI(pattern);

            int q = -1;

            for (int index = index1; index <= index2; index++)
            {
                while (q > -1 && (text[index] != '.' && pattern[q + 1] != '.' && text[index] != pattern[q + 1]))
                {
                    q = PI[q];
                }

                if (text[index] == '.' || pattern[q + 1] == '.' || text[index] == pattern[q + 1])
                {
                    q = q + 1;
                }

                if (q == pattern.Length - 1)
                {
                    result.AddLast(index - q);
                    return result;
                    /*
                  q = PI[q]; */
                }
            }

            return result;
        }


        public LinkedList<int> KMP(string pattern, string text)
        {
            LinkedList<int> result = new LinkedList<int>();
            int[] PI = KMP_PI(pattern);

            int q = -1;

            for (int index = 0; index < text.Length; index++)
            {
                while (q > -1 && (text[index] != '.' && pattern[q + 1] != '.' && text[index] != pattern[q + 1]))
                {
                    q = PI[q];
                }

                if (text[index] == '.' || pattern[q + 1] == '.' || text[index] == pattern[q + 1])
                {
                    q = q + 1;
                }

                if (q == pattern.Length - 1)
                {
                    result.AddLast(index - q);
                    q = PI[q];
                }
            }

            return result;
        }

        public int[] KMP_PI(string pattern)
        {
            int[] result = new int[pattern.Length];
            //if (pattern[0] == '.')
            //{
            //    result[0] = -1;
            //}
            //else
            //    result[0] = -1;

            result[0] = -1;

            int q = 1;
            int k = -1;

            for (; q < pattern.Length; q++)
            {
                while (k > -1 && (pattern[q] != '.' && pattern[k + 1] != '.' && pattern[q] != pattern[k + 1]))
                {
                    k = result[k];
                }
                if (pattern[q] == '.' || pattern[k + 1] == '.' || pattern[q] == pattern[k + 1])
                {
                    result[q] = k + 1;
                    k++;
                }
                else
                {
                    result[q] = -1;
                }
            }

            return result;
        }
    }
}
