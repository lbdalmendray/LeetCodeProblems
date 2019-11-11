using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumScoreWordsFormedbyLetters
{
    public class Solution
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            var wordLetterCounts = words.Select(word => GetLetterCount(word));
            var lettersLetterCount = GetLetterCount(new string(letters));
            int result = 0;
            foreach (var item in GetAllSelections(words.Length))
            {
                var wordLetterCountsFilter = wordLetterCounts.Where((w, i) => item[i]);
                var sum = Sum(wordLetterCountsFilter);
                if ( NotExceed(sum,lettersLetterCount))
                {
                    var value = GetValue(sum, score);
                    if (value > result)
                        result = value ;
                }
            }

            return result;
        }

        private int  GetValue(int[] sum, int[] score)
        {
            int result = 0;

            for (int i = 0; i < sum.Length; i++)
            {
                result += score[i] * sum[i];
            }

            return result ;  
        }

        private bool NotExceed(int[] sum, int[] lettersLetterCount)
        {

            for (int i = 0; i < sum.Length; i++)
            {
                if (sum[i] > lettersLetterCount[i])
                    return false;
            }

            return true;
        }

        private int[] Sum(IEnumerable<int[]> wordLetterCountsFilter)
        {
            if ( wordLetterCountsFilter.Count() > 0)
            {
                int[] result = new int[wordLetterCountsFilter.First().Length];

                foreach (var item in wordLetterCountsFilter)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        result[i] += item[i];
                    }
                }

                return result;
            }

            return new int[0];
        }

        private IEnumerable<bool[]> GetAllSelections(int length)
        {
            bool[] selection = new bool[length];
            return GetAllSelections(selection, 0);
        }

        private IEnumerable<bool[]> GetAllSelections(bool[] selection, int index)
        {
            if (index == selection.Length)
            {
                yield return selection.Select(v => v).ToArray();
            }
            else
            {
                selection[index] = true;
                foreach (var item in GetAllSelections(selection, index + 1))
                {
                    yield return item;
                }

                selection[index] = false;
                foreach (var item in GetAllSelections(selection, index + 1))
                {
                    yield return item;
                }
            }
        }

        private int[] GetLetterCount(string word)
        {
            int[] result = new int[26];
            foreach (var item in word)
            {
                result[item - 'a']++;
            }
            return result;
        }
    }

}
