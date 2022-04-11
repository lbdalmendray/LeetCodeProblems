using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedStringMatch
{
    public class Solution
    {
        public int RepeatedStringMatch(string a, string b)
        {
            if (a.Length >= b.Length)
            {
                if (b.Length == 1)
                {
                    return a.Contains(b[0]) ? 1 : -1;
                }
                else
                {
                    int index = StringMath(b, $"{a}{a}");
                    if (index == -1)
                        return -1;
                    else if (index < a.Length)
                        return 1;
                    else
                        return 2;
                }
            }
            else
            {
                int div = (b.Length - 1) / a.Length;
                int rest = (b.Length - 1) % a.Length;
                StringBuilder stringBuilder = new StringBuilder();
                int count = 1 + div + (rest != 0 ? 1 : 0);
                for (int i = 0; i < count; i++)
                {
                    stringBuilder.Append(a);
                }
                int index = StringMath(b, stringBuilder.ToString());
                if (index == -1)
                    return -1;
                else
                {
                    div = (index + b.Length) / a.Length;
                    rest = (index + b.Length) % a.Length;

                    return div + (rest != 0 ? 1 : 0);
                }
            }
        }

        private int StringMath(string pattern, string text)
        {
            int [] next = GenerateNextArray(pattern);
            for (int i = 0, pIndex = 0; i < text.Length; i++, pIndex++)
            {
                if(text[i] == pattern[pIndex])
                {
                    if( pIndex == pattern.Length-1)
                    {
                        return i - pattern.Length + 1; 
                    }
                }
                else
                {
                    pIndex = next[pIndex];
                }
            }
            return -1;
        }

        private int[] GenerateNextArray(string pattern)
        {
            int[] result = new int[pattern.Length];

            result[0] = -1;

            for (int i = 1; i < result.Length; i++)
            {
                int level = i - 1;

                for ( ; level> -1; level--)
                {
                    if ( pattern[result[level]+1] == pattern[i])
                    {
                        result[i] = result[level] + 1;
                        break;
                    }
                }

                if (level == -1)
                    result[i] = -1;
            }
            return result;
        }
    }
}
