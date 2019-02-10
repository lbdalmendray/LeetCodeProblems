using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    public enum PatternType
    {
        Normal,
        Aster
    }

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            string text = s;
            string pattern = p;

            if ( p == "" )
            {
                if (s == "")
                    return true;
                return false;

            }

            var patternParsed = Parser(pattern);            

            int index1 = 0;

            if (patternParsed.First.Value.Item1 == PatternType.Normal)
            {
                if (text == "" || ! StringEquals( patternParsed.First.Value.Item2 , MySubString( text, 0, patternParsed.First.Value.Item2.Length) ))
                    return false;
                index1 = patternParsed.First.Value.Item2.Length;
                patternParsed.RemoveFirst();
            }
            int index2 = text.Length - 1;

            if (patternParsed.Count > 0 && patternParsed.Last.Value.Item1 == PatternType.Normal && index1<= index2)
            {
                if (text == "" || !StringEquals(patternParsed.Last.Value.Item2, MySubString(text,text.Length - patternParsed.Last.Value.Item2.Length, patternParsed.Last.Value.Item2.Length)))
                    return false;
                index2 = text.Length - 1 - patternParsed.Last.Value.Item2.Length;
                patternParsed.RemoveLast();
            }

            if (index1 > index2)
            {
                if (patternParsed.Count== 0 )
                    return true;
            }
            else if (patternParsed.Count == 0)
            {
                return false;
            }

            LinkedList<int>[] KMPResults = patternParsed.Select(pp => pp.Item1 == PatternType.Normal ? StringMatching(pp.Item2, text, index1, index2) : null).ToArray();

            LinkedList<int> normalIndexes = new LinkedList<int>();

            for (int i = 0; i < KMPResults.Length; i++)
                if (KMPResults[i] != null)
                    normalIndexes.AddLast(i);
            
            if (normalIndexes.Count > 0)
                return IsNormalMatch(patternParsed.ToArray(), 0, normalIndexes.ToArray(), KMPResults, text, index1, index2);
            else
                return IsAsterMatch(patternParsed.ToArray(), 0, patternParsed.Count - 1, index1, index2, text);

        }

        public bool StringEquals ( string sPattern, string s2 )
        {
            if (sPattern.Length != s2.Length)
                return false;
            for (int i = 0; i < sPattern.Length; i++)
            {
                if ( sPattern[i] != s2[i] && sPattern[i] != '.' )
                {
                    return false;
                }
            }

            return true;
        }

        public string MySubString(string s1 , int index1 , int length)
        {
            if (index1 < 0)
                index1 = 0;
            if (length + index1 - 1 > s1.Length - 1)
                length = s1.Length - 1 - index1 + 1;
            return s1.Substring(index1, length);
        }

        public bool IsNormalMatch(Tuple<PatternType, string>[] patternParsedArray, int normalIndex, int[] normalIndexes, LinkedList<int>[] KMPResults, string text, int index1, int index2)
        {
            int currentIndex = normalIndexes[normalIndex];

            for (int i = 0; i < KMPResults[currentIndex].Count; i++)
            {
                foreach (var matchIndex in KMPResults[currentIndex])
                {
                    if (matchIndex < index1 || matchIndex > index2)
                        continue;

                    var previousNormalIndexPlus1 = normalIndex > 0 ? normalIndexes[normalIndex - 1] + 1 : 0;
                    if (normalIndex < normalIndexes.Length - 1)
                    {
                        if (IsAsterMatch(patternParsedArray, previousNormalIndexPlus1, currentIndex - 1, index1, matchIndex - 1, text)
                        && IsNormalMatch(patternParsedArray, normalIndex + 1, normalIndexes, KMPResults, text, matchIndex + patternParsedArray[currentIndex].Item2.Length, index2))
                            return true;
                    }
                    else
                    {
                        var result = IsAsterMatch(patternParsedArray, previousNormalIndexPlus1, currentIndex - 1, index1, matchIndex - 1, text);
                        if (!result)
                            continue;

                        if (currentIndex < patternParsedArray.Length - 1)
                            if (!(IsAsterMatch(patternParsedArray, currentIndex + 1, patternParsedArray.Length - 1, matchIndex + patternParsedArray[currentIndex].Item2.Length, index2, text)))
                                continue;
                        if (result)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool IsAsterMatch(Tuple<PatternType, string>[] patternParsedArray, int index1Pattern, int index2Pattern, int index1Text, int index2Text, string text)
        {
            if (index1Text > index2Text)
                return true;

            for (int i = index1Pattern; i <= index2Pattern; i++)
            {
                while (patternParsedArray[i].Item2[0] == '.' || patternParsedArray[i].Item2[0] == text[index1Text])
                {
                    index1Text++;
                    if (index1Text > index2Text)
                        return true;
                }

            }
            return false;
        }

        public LinkedList<Tuple<PatternType, string>> Parser(string pattern)
        {
            LinkedList<Tuple<PatternType, string>> result = new LinkedList<Tuple<PatternType, string>>();

            if (pattern == "")
                return result;

            var patternSplit = pattern.Split('*');

            if (pattern[pattern.Length - 1] == '*')
            {
                patternSplit = patternSplit.Take(patternSplit.Length - 1).ToArray();
            }
            else
            {
                result.AddLast(new Tuple<PatternType, string>(PatternType.Normal, patternSplit[patternSplit.Length - 1]));
                patternSplit = patternSplit.Take(patternSplit.Length - 1).ToArray();
            }

            for (int i = patternSplit.Length - 1; i >= 0; i--)
            {
                result.AddFirst(new Tuple<PatternType, string>(PatternType.Aster, patternSplit[i][patternSplit[i].Length - 1].ToString()));
                var normalValue = patternSplit[i].Substring(0, patternSplit[i].Length - 1);
                if (normalValue != "")
                {
                    result.AddFirst(new Tuple<PatternType, string>(PatternType.Normal, normalValue));
                }                
            }

            return result;
        }

        public LinkedList<int> KMP(string pattern, string text, int index1, int index2)
        {
            LinkedList<int> result = new LinkedList<int>();
            int[] PI = KMP_PI(pattern);

            int q = -1;

            for (int index = index1; index <= index2; index++)
            {
                while (q > -1 && ( text[index] != pattern[q + 1]))
                {
                    q = PI[q];
                }

                if ( text[index] == pattern[q + 1])
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
            
            result[0] = -1;

            int q = 1;
            int k = -1;

            for (; q < pattern.Length; q++)
            {
                while (k > -1 && ( pattern[q] != pattern[k + 1]))
                {
                    k = result[k];
                }
                if (pattern[q] == pattern[k + 1])
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

        public LinkedList<int> StringMatching(string pattern, string text, int index1, int index2)
        {
            bool KMPType = true;

            for (int i = 0; i < pattern.Length; i++)
            {
                if ( pattern[i] == '.')
                {
                    KMPType = false;
                    break;
                }
            }

            if (KMPType)
                return KMP(pattern, text, index1, index2);
            return StringMatchingSimple(pattern, text, index1, index2);
        }

        public LinkedList<int> StringMatchingSimple(string pattern, string text, int index1, int index2)
        {
            LinkedList<int> result = new LinkedList<int>();
            for (int i = 0; i < text.Length - pattern.Length + 1 ; i++)
            {
                if (StringEquals(pattern, text.Substring(i, pattern.Length)))
                    result.AddLast(i);
            }
            return result;
        }
    }

    

}
