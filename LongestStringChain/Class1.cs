using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestStringChain
{
    public class Solution
    {
        public int LongestStrChain(string[] words)
        {
            //HashSet<string> wordSet = new HashSet<string>(words.Where(w => w != null));
            HashSet<string> wordSet = new HashSet<string>(words);

            Dictionary<string, int> solutions = new Dictionary<string, int>();

            int result = 1;

            foreach (var word in wordSet)
            {
                if (!solutions.TryGetValue(word, out var solValue))
                {
                    solValue = Solve(word, solutions, wordSet);
                    solutions[word] = solValue;
                }

                result = Math.Max(result, solValue);
            }


            return result;

        }

        private int Solve(string word, Dictionary<string, int> solutions, HashSet<string> wordSet)
        {
            if (word.Length < 2)
            {
                solutions[word] = word.Length;
                return word.Length;
            }
            else
            {
                int result = 1;
                for (int i = 0; i < word.Length; i++)
                {
                    var predecesor = word.Remove(i, 1);
                    if (wordSet.Contains(predecesor))
                    {
                        int cResult = Solve(predecesor, solutions, wordSet);
                        cResult++;
                        result = Math.Max(result, cResult);
                    }
                }

                return result;
            }
        }
    }
}
