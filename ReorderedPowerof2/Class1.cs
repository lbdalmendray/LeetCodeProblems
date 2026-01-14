using System.Text;

namespace ReorderedPowerof2;

public class Solution
{
    private readonly HashSet<int> hashSet;
    private readonly int[] power10List = new int[10] { 1, 10, 100, 1000, 10_000, 100_000, 1000_000, 10_000_000, 100_000_000, 1000_000_000 };
    public Solution()
    {
        //string[] power2List = new string[] { "1", "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768", "65536", "131072", "262144", "524288", "1048576", "2097152", "4194304", "8388608", "16777216", "33554432", "67108864", "134217728", "268435456", "536870912"/*, "1073741824"*/ };
        int[] power2List = new int[] {          1,   2,   4,   8,   16,   23,   46 ,  128,   256,   125,   1024 ,  2048,   4069,   1289 ,  13468 ,  23678,   35566 ,  101237 ,  122446 ,  224588 ,  1045678 ,  1022579 ,  1034449 ,  3068888 ,  11266777 ,  23334455 ,  10466788  , 112234778  , 234455668 ,  102356789 /*, "1073741824"*/ };
        hashSet = new HashSet<int>(power2List);
    }

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

        return hashSet.Contains(nOrderedInt);
    }
}
