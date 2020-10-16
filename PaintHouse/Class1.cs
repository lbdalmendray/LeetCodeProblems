using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintHouse
{
    public class Solution
    {
        public int MinCost(int[][] costs)
        {
            if (costs == null || costs.Length == 0)
                return 0;
            int?[,] infos = new int?[costs.Length, 3];
            for (int i = costs.Length -1 ; i > 0 ; i--)
            {
                new int[] { 0, 1, 2 }.Select(e => Calculate(i, e, infos, costs)).Min();
            }
            var result = new int[] { 0, 1, 2 }.Select(e => Calculate(0, e, infos, costs)).Min();
            return result;
        }

        private int Calculate(int index, int color, int?[,] infos , int[][] costs)
        {
            if (infos[index, color].HasValue)
                return infos[index, color].Value;

            var result = costs[index][color];
            if (index < infos.GetLength(0) - 1)
            {
                var indexPlus1 = index + 1;
                var branches = new int[] { 0, 1, 2 }.Where(e => e != color);
                var minValue =branches.Select(e => Calculate(indexPlus1, e, infos, costs)).Min();
                result += minValue;
            }

            infos[index, color] = result;
            return result;
        }
    }
}
