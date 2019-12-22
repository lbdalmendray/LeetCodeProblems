    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumNumberofOccurrencesofaSubstring
{
    public class Solution
    {
        public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
        {
            int result = 0;

            for (int i = minSize; i <= maxSize; i++)
            {
                Dictionary<string, int> dictWords = new Dictionary<string, int>();
                Dictionary<char, int> dicChar = new Dictionary<char, int>();

                for (int j = 0; j < s.Length ; j++)
                {
                    if (!dicChar.ContainsKey(s[j]))
                        dicChar.Add(s[j], 0);
                    dicChar[s[j]]++;
                    if (j >= i - 1)
                    {
                        if (dicChar.Count() <= maxLetters)
                        {
                            var substring = s.Substring(j - i + 1, i);
                            if (!dictWords.ContainsKey(substring))
                            {
                                dictWords.Add(substring, 0);
                            }
                            dictWords[substring]++;
                        }

                        dicChar[s[j - i + 1]]--;
                        if (dicChar[s[j - i + 1]] == 0)
                            dicChar.Remove(s[j - i + 1]);
                    }                  
                }
                if (dictWords.Count > 0)
                    result = Math.Max(result, dictWords.Max(e => e.Value));
            }

            return result;
        }
    }
}
