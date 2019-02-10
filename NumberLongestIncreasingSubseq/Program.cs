using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Number of Longest Increasing Subsequence
/// </summary>
namespace NumberLongestIncreasingSubseq
{
    class Program
    {
        static void Main(string[] args)
        {
            LongMonotonics();
            Solution s = new Solution();
            int[] into = new int[] { 1, 3, 5, 4, 7 };
            //into = new int[0] { };
            int result = s.FindNumberOfLIS(into);
        }

        static void LongMonotonics()
        {
            int[] A = new int[] { 1, 2, 4, 3, 5, 7, 6 };
            int[] B = new int[A.Length];
            List<int>[] C = new List<int>[A.Length];
             
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = int.MaxValue;
                C[i] = new List<int>(A.Length);
            }
            int L = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < B[0])
                {
                    B[0] = A[i];
                    C[0].Insert(0, A[i]);
                }
                else
                {
                    int j = 0;
                    for ( ; j < B.Length; j++)
                    {
                        if (!(B[j] < A[i]))
                        {
                            j--;
                            break;
                        }
                    }

                    B[j + 1] = A[i];
                    C[j + 1] = C[j];
                    C[j + 1].Add(A[i]);
                    if (j + 1 > L)
                        L = L + 1;
                }
            }
            var result = C[L]; 

        }


    }
}
