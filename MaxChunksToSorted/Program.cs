using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxChunksToSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {1, 4, 0, 2, 3, 5};
            arr = new int[] { 0, 1, 3, 5, 4, 2 };
            Solution s = new Solution();
            var aaa = s.MaxChunksToSorted(arr);
        }
    }
}
