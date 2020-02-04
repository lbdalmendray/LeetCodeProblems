using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheKWeakestRowsinaMatrix
{
    public class Solution
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            int[][] infos = new int[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                infos[i] = new int[] { i, 0 };

                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                        infos[i][1]++;
                    else
                        break;
                }
            }

            LinkedList<int>[] sortedList = new LinkedList<int>[100];
            for (int i = 0; i < mat.Length; i++)
            {
               if( sortedList[infos[i][1]] == null)
                {
                    sortedList[infos[i][1]] = new LinkedList<int>();
                }

                sortedList[infos[i][1]].AddLast(infos[i][0]);
            }

            var result = new int[k];

            int kIndex = 0;

            for (int i = 0; i < 100; i++)
            {
                if (sortedList[i] == null)
                    continue;
                var list = sortedList[i];
                while (kIndex < k)
                {
                    if (list.Count == 0)
                        break;
                    var first = list.First.Value;
                    list.RemoveFirst();
                    result[kIndex] = first;
                    kIndex++;
                }
            }

            return result;
        }
    }
}
