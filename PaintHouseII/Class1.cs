using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintHouseII
{
    public class Solution
    {
        public int MinCostII(int[][] costs)
        {
            if (costs == null || costs.Length == 0)
                return 0;

            int n = costs.Length;
            int k = costs[0].Length;

            int?[,] infos = new int?[n, k];
            var branches = Enumerable.Range(0, k);
            for (int i = n - 1; i > 0; i--)
            {
                branches.Select(e => Calculate(i, e, infos, costs)).Min();
            }
            var result = branches.Select(e => Calculate(0, e, infos, costs)).Min();
            return result;
        }

        private int Calculate(int index, int color, int?[,] infos, int[][] costs)
        {
            if (infos[index, color].HasValue)
                return infos[index, color].Value;

            var result = costs[index][color];
            if (index < infos.GetLength(0) - 1)
            {
                var indexPlus1 = index + 1;
                var branches = Enumerable.Range(0, costs[0].Length).Where(e => e != color);
                var minValue = branches.Select(e => Calculate(indexPlus1, e, infos, costs)).Min();
                result += minValue;
            }

            infos[index, color] = result;
            return result;
        }
    }
}
