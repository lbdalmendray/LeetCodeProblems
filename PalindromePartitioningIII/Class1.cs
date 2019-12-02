using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromePartitioningIII
{
    public class Solution
    {
        public int PalindromePartition(string s, int k)
        {
            ProbInfo[,] probInfos = new ProbInfo[s.Length, k + 1];
            PalindromeInfo[,] palindromeInfos = new PalindromeInfo[s.Length, s.Length];

            return PalindromePartitionAux(0, k, s, probInfos, palindromeInfos);
        }

        private int PalindromePartitionAux(int index, int k, string s, ProbInfo[,] probInfos, PalindromeInfo[,] palindromeInfos)
        {
            if (k == 0)
                return 0;

            if ( probInfos[index,k] != null)
            {
                return probInfos[index, k].Result;
            }

            probInfos[index, k] = new ProbInfo();

            int result = int.MaxValue;

            if (k == 1)
            {
                result = MiniPalindrome(index, s.Length - 1, s, palindromeInfos);
            }
            else
            {
                int maxIndex = s.Length - 1 - (k - 1);


                for (int j = index; j <= maxIndex; j++)
                {
                    var currentResult = MiniPalindrome(index, j, s, palindromeInfos);
                    currentResult += PalindromePartitionAux(j + 1, k - 1, s, probInfos, palindromeInfos);

                    if (currentResult < result)
                        result = currentResult;
                }
            }

            probInfos[index, k].Result = result;
            return result;
        }

        private int MiniPalindrome(int index, int j, string s, PalindromeInfo[,] palindromeInfos)
        {
            if ( palindromeInfos[index,j] != null )
            {
                return palindromeInfos[index, j].Result;
            }

            int result = 0;
            int indexR;
            int indexL;
            int count;
            int length = j - index + 1;
            if ( (length) % 2 == 0 )
            {
                indexR = length / 2 + index;
                indexL = length / 2 - 1 + index;
                count = length / 2;
            }
            else
            {
                indexR = length / 2+1 + index;
                indexL = length / 2 - 1 + index ;
                count = length / 2 ;
            }

            for (int i = 0; i < count; i++ )
            {
                if (s[indexR+i] != s[indexL-i])
                    result++;
            }

            palindromeInfos[index, j] = new PalindromeInfo();
            palindromeInfos[index, j].Result = result;
            return result;
        }
    }

    internal class PalindromeInfo
    {
        public int Result { get; internal set; }
    }

    internal class ProbInfo
    {
        public int Result { get; internal set; }
    }
}
