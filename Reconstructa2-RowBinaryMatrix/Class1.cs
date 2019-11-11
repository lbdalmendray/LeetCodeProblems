using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstructa2_RowBinaryMatrix
{
    public class Solution
    {
        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            int[] result0 = new int[colsum.Length];
            int[] result1 = new int[colsum.Length];

            LinkedList<int> ones = new LinkedList<int>();
            for (int i = 0; i < colsum.Length; i++)
            {
                if(colsum[i] == 2)
                {
                    result0[i] = 1;
                    result1[i] = 1;
                    upper--;
                    lower--;
                }
                else if(colsum[i] == 1)
                {
                    ones.AddLast(i);
                }
            }

            if ( upper < 0 || lower < 0 )
                return new List<IList<int>>() as IList<IList<int>>;

            if (upper + lower != ones.Count)
                return new List<IList<int>>() as IList<IList<int>>;

            for (int i = 0; i < upper; i++)
            {
                result0[ones.First.Value] = 1;
                ones.RemoveFirst();
            }

            for (int i = 0; i < lower; i++)
            {
                result1[ones.First.Value] = 1;
                ones.RemoveFirst();
            }

            var result = new List<IList<int>>();
            result.Add(result0);
            result.Add(result1);

            return result as IList<IList<int>>; 
        }
    }
}
