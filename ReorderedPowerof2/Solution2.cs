using System.Buffers.Text;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReorderedPowerof2;

/// <summary>
/// Solution2 
/// 
// The idea here is that each power of 2, P, (between[1, 1000_000_000],
// P = d0 d2...dL-1) can be transformed to any other number N where its digits are a permutation of
// the digits of P(d0, d2,..., dL-1) with no leadign Zeros.
// So, based on this idea P and N also can be transformed to the minimum permutation M that is the minimum
// permutation of the digits of P (d0, d2,...., dL-1) with no leadign Zeros and it is the
// 
// So if we precalculate each M for each P (let's call it SetM), so we have them in code, then the only
// thing that we need to do in ReorderedPowerOf2 is to calculate the minimum nOrderedInt related to n(input),
// and look for nOrderedInt in the SetM related to all the Ps precalculated. If nOrderedInt is in SetM, then
// the answer is TRUE, other case it is FALSE.
// 
// BTW, you can check that each power of 2 between[1, 1000_000_000], it has a unique Minimum permutation
// different from the rest of Minimum Permutations related to the rest of power of 2 between[1, 1000_000_000].
/// 
/// </summary>
public class Solution2
{
    private readonly int[] power10List = new int[10] { 1, 10, 100, 1000, 10_000, 100_000, 1000_000, 10_000_000, 100_000_000, 1000_000_000 };

    public bool ReorderedPowerOf2(int n)
    {
        /// SORTING 
        int[] counter = new int[10];
        int count = 0;
        while ( n > 0 )
        {
            (n, var reminder) = Math.DivRem(n, 10);
            counter[reminder]++;
            count++;
        }

        int[] nOrdered = new int[count];
        for (int i = 0, j = 0; i< 10; i++)
        {
            while (counter[i] >0 )
            {
                nOrdered[j++] = i;
                counter[i]--;
            }
        }

        //////

        if (nOrdered[0] == 0)
        {
            int i = 0;
            while (nOrdered[i] == 0 )
            {
                i++;
            }
            nOrdered[0] = nOrdered[i];
            nOrdered[i] = 0;
        }

        int nOrderedInt = 0;
        int countLess1 = count - 1;
        for (int i = 0; i < count; i++)
        {
            nOrderedInt += nOrdered[i] * power10List[countLess1 - i];
        }


        if (count == 1)
        {
            // 1, 2, 4, 8,
            return nOrderedInt == 1 || nOrderedInt == 2 || nOrderedInt == 4 || nOrderedInt == 8;
        }
        else if (count == 2)
        {
            // 16, 23, 46
            return nOrderedInt == 16 || nOrderedInt == 23 || nOrderedInt == 46;
        }
        else if (count == 3)
        {
            // 128, 256, 125
            return nOrderedInt == 128 || nOrderedInt == 256 || nOrderedInt == 125;
        }
        else if (count == 4)
        {
            // 1024, 2048, 4069, 1289
            return nOrderedInt == 1024 || nOrderedInt == 2048 || nOrderedInt == 4069 || nOrderedInt == 1289;
        }
        else if (count == 5)
        {
            // 13468, 23678, 35566
            return nOrderedInt == 13468 || nOrderedInt == 23678 || nOrderedInt == 35566;
        }
        else if (count == 6)
        {
            // 101237, 122446, 224588
            return nOrderedInt == 101237 || nOrderedInt == 122446 || nOrderedInt == 224588;
        }
        else if (count == 7)
        {
            // , 11266777, 23334455, 10466788, 112234778, 234455668, 102356789 /*, "1073741824"*/ };


            // , 1045678, 1022579, 1034449, 3068888
            return nOrderedInt == 1045678 || nOrderedInt == 1022579 || nOrderedInt == 1034449 || nOrderedInt == 3068888;
        }
        else if (count == 8)
        {
            // ,, 112234778, 234455668, 102356789 /*, "1073741824"*/ };


            // , 11266777, 23334455, 10466788
            return nOrderedInt == 11266777 || nOrderedInt == 23334455 || nOrderedInt == 10466788;
        }
        else if (count == 9)
        {
            // ,, 112234778, 234455668, 102356789 /*, "1073741824"*/ };


            // ,, 112234778, 234455668, 102356789
            return nOrderedInt == 112234778 || nOrderedInt == 234455668 || nOrderedInt == 102356789;
        }
        else
            return false;
    }
}
