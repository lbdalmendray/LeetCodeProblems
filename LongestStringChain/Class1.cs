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
                var solValue = Solve(word, solutions, wordSet);
                result = Math.Max(result, solValue);
            }

            return result;
        }

        private int Solve(string word, Dictionary<string, int> solutions, HashSet<string> wordSet)
        {
            if (solutions.TryGetValue(word, out var solValue))
            {
                return solValue;
            }
            else if (word.Length < 2)
            {
                solValue = word.Length;
            }
            else
            {
                solValue = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    var predecesor = word.Remove(i, 1);
                    if (wordSet.Contains(predecesor))
                    {
                        int cResult = Solve(predecesor, solutions, wordSet);
                        solValue = Math.Max(solValue, cResult);
                    }
                }

                solValue++;                
            }

            solutions[word] = solValue;
            return solValue;
        }
    }
}
