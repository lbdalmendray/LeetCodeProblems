using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CountVowelsPermutation
{
    public class Solution
    {
        public int CountVowelPermutation(int n)
        {
            // 'aeiou'
            Dictionary<char, BigInteger>[] solutions = new Dictionary<char, BigInteger >[n];
            for (int i = 0; i < n; i++)
            {
                solutions[i] = new Dictionary<char, BigInteger >();
            }

            foreach (var item in "aeiou")
            {
                solutions[0][item] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                foreach (var item in "aeiou")
                {
                    if( item == 'a')
                    {
                        BigInteger  count = solutions[i-1]['e'];
                        solutions[i].Add('a', count);
                    }
                    else if (item == 'e')
                    {
                        BigInteger  count = solutions[i - 1]['a'] + solutions[i - 1]['i'];
                        solutions[i].Add('e', count);
                    }
                    else if (item == 'i')
                    {
                        BigInteger  count = solutions[i - 1]['a'] + solutions[i - 1]['e'] + solutions[i - 1]['o'] + solutions[i - 1]['u'];
                        solutions[i].Add('i', count);
                    }
                    else if (item == 'o')
                    {
                        BigInteger  count = solutions[i - 1]['i'] + solutions[i - 1]['u'];
                        solutions[i].Add('o', count);
                    }
                    else if(item == 'u')
                    {
                        BigInteger  count = solutions[i - 1]['a'];
                        solutions[i].Add('u', count);
                    }
                }
            }

            BigInteger  result = 0 ;
            foreach (var item in solutions[n - 1].Values)
            {
                result += item;
            }
            return (int) ( result % (1000000000 + 7) );

        }
    }
}
