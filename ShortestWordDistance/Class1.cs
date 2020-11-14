using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestWordDistance
{
    public class Solution
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            int i = 0;
            int state = -1;
            for (; i < words.Length; i++)
            {
                if ( words[i] == word1 )
                {
                    state = 1;
                    break;
                }
                else if ( words[i] == word2)
                {
                    state = 2;
                    break;
                }
            }
            int distance = int.MaxValue;
            for (int j = i+1; j < words.Length ; j++)
            {
                if ( state == 1)
                {
                    if (words[j] == word1)
                    {
                        i = j;
                    }
                    else if (words[j] == word2)
                    {
                        distance = Math.Min(distance, j - i);
                        state = 2;
                        i = j;
                    }
                }
                else
                {
                    if (words[j] == word2)
                    {
                        i = j;
                    }
                    else if (words[j] == word1)
                    {
                        distance = Math.Min(distance, j - i);
                        state = 1;
                        i = j;
                    }
                }
            }
            return distance;
        }
    }
}
