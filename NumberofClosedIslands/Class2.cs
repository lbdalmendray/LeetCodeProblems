using System.Linq;
using System.Collections.Generic;

namespace NumberofClosedIslands
{
    public class Solution2
    {
        public int ClosedIsland(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return 0;

            int result = 0;

            bool[,] selected = new bool[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1 )
                        continue;
                    if (selected[i, j])
                        continue;

                    IEnumerable<int[]> allland = GetAllLandAndRemove(i, j, grid, selected);
                    bool isIsland = IsLand(allland, selected.GetLength(0), selected.GetLength(1));
                    if (isIsland)
                        result++;
                }
            }

            return result;
        }

        IEnumerable<int[]> GetAllLandAndRemove(int i, int j, int[][] grid, bool [,] selected)
        {
            LinkedList<int[]> queue = new LinkedList<int[]>();
            LinkedList<int[]> result = new LinkedList<int[]>();

            selected[i, j] = true;
            var pos = new int[] { i, j };
            queue.AddLast(pos);
            result.AddLast(pos);

            while(queue.Count != 0)
            {
                var first = queue.First.Value;
                queue.RemoveFirst();

                IEnumerable<int []> siblings = GetSiblings(first, selected.GetLength(0), selected.GetLength(1));
                foreach (var sibling in siblings
                    .Where(s => grid[s[0]][s[1]] == 0)
                    .Where(s => !selected[s[0], s[1]])
                    )
                {
                    selected[sibling[0], sibling[1]] = true;
                    queue.AddFirst(sibling);
                    result.AddLast(sibling);
                }
            }

            return result;
        }

        IEnumerable<int[]>  GetSiblings(int [] first, int rows , int columns)
        {
            LinkedList<int[]> result = new LinkedList<int[]>();

            if (first[0] > 0)
                result.AddFirst(new int[] { first[0] - 1, first[1] });
            if (first[0] < rows-1 )
                result.AddFirst(new int[] { first[0] + 1, first[1] });
            if (first[1] > 0)
                result.AddFirst(new int[] { first[0] , first[1] -1});
            if (first[1] < columns - 1)
                result.AddFirst(new int[] { first[0] , first[1] + 1 });
            return result;
        }


        bool IsLand(IEnumerable<int[]> allland, int rows , int colums )
        {
            foreach( var item in allland )
            {
                if (item[0] == 0)
                    return false;
                if (item[0] == rows - 1)
                    return false;
                if (item[1] == 0)
                    return false;
                if (item[1] == colums - 1)
                    return false;
            }
            return true;
        }
    }
}
