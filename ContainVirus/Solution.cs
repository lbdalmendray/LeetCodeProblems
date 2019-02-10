using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainVirus
{
    public class Solution
    {
        public int ContainVirus(int[,] grid)
        {

            bool[,,] bounds = new bool[grid.GetLength(0), grid.GetLength(1), 4];
            int crow = grid.GetLength(0);
            int ccolumn = grid.GetLength(1);

            bounds[0, 0, 0] = bounds[0, 0, 3] = true;
            bounds[0, ccolumn - 1, 0] = bounds[0, ccolumn - 1, 1] = true;
            bounds[crow - 1, 0, 2] = bounds[crow - 1, 0, 3] = true;
            bounds[crow - 1, ccolumn - 1, 1] = bounds[crow - 1, ccolumn - 1, 2] = true;

            for (int i = 1; i < crow - 1; i++)
            {
                bounds[i, 0, 3] = bounds[i, ccolumn - 1, 1] = true;
            }

            for (int i = 1; i < ccolumn - 1; i++)
            {
                bounds[0, i, 0] = bounds[crow - 1, i, 2] = true;
            }

            return ContainVirus(grid, bounds);

        }
        public int ContainVirus(int[,] grid, bool[,,] bounds)
        {
            int result = 0;

            var regions = GetRegions(grid, bounds);
            while (regions != null)
            {
                Print(grid);
                var currentRegion = regions;
                int maxCount = 0;
                LinkedNode<Tuple<int, int, int>> maxBounds = null;
                LinkedNode<Tuple<int, int>> maxRegion = null;
                LinkedNode<LinkedNode<Tuple<int, int, int>>> allBounds = null;
                LinkedNode<LinkedNode<Tuple<int, int, int>>> exceptionAllBounds = null;
                      int maxBoundsIndex = -1; 
                while (currentRegion.Value != null)
                {
                    int count = 0;
                    LinkedNode<Tuple<int, int, int>> boundsRegion = FindBoundsRegion(currentRegion.Value, grid, bounds, out count);
                    if (allBounds == null)
                    {
                        allBounds = new LinkedNode<LinkedNode<Tuple<int, int, int>>> { Value = boundsRegion };
                    }
                    else
                    {
                        var newNode = new LinkedNode<LinkedNode<Tuple<int, int, int>>> { Value = boundsRegion };
                        newNode.Next = allBounds;
                        allBounds = newNode;
                    }
                    currentRegion = currentRegion.Next;
                    if (count >= maxCount)
                    {
                        maxCount = count;
                        maxBounds = boundsRegion;
                        exceptionAllBounds = allBounds;
                    }
                }
                if (maxCount == 0)
                    break;
                result += maxCount;
                UpdateVirus(allBounds,exceptionAllBounds, grid);
                UpdateBounds(maxBounds, bounds, grid);
                regions = GetRegions(grid, bounds);
            }
            return result;
        }

        public void Print(int[,] grid)
        {
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //Console.Write(grid[i, j]==1?"1":" "+ " ");
                    Console.Write(grid[i, j]+ "  ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private void UpdateVirus(LinkedNode<LinkedNode<Tuple<int, int, int>>> allBounds, LinkedNode<LinkedNode<Tuple<int, int, int>>> exceptionAllBounds, int[,] grid)
        {
            while (allBounds != null)
            {
                if (allBounds != exceptionAllBounds)
                {
                    var currentRegion = allBounds.Value;
                    while (currentRegion != null)
                    {
                        grid[currentRegion.Value.Item1, currentRegion.Value.Item2] = 1;
                        currentRegion = currentRegion.Next;
                    }
                }

                allBounds = allBounds.Next;
            }
        }

        private void UpdateBounds(LinkedNode<Tuple<int, int, int>> maxBounds, bool[,,] bounds, int[,] grid)
        {
            while (maxBounds != null)
            {
                var currentValue = maxBounds.Value;
                bounds[currentValue.Item1, currentValue.Item2, currentValue.Item3] = true;
                //grid[currentValue.Item1, currentValue.Item2] = 0;
                maxBounds = maxBounds.Next;
            }
        }

        public LinkedNode<Tuple<int, int, int>> FindBoundsRegion(LinkedNode<Tuple<int, int>> region, int[,] grid, bool[,,] bounds, out int count)
        {
            LinkedNode<Tuple<int, int, int>> result = null;
            count = 0;

            while (region != null)
            {
                int countFreePart = 0;
                LinkedNode<Tuple<int, int, int>> lastNode;
                var freeParts = FindFreePart(region.Value.Item1, region.Value.Item2,grid,bounds, out countFreePart, out lastNode);
                count += countFreePart;

                if (lastNode != null)
                {
                    lastNode.Next = result;
                    result = freeParts;
                }
                region = region.Next;
            }
            return result;
        }

        LinkedNode<Tuple<int, int, int>> FindFreePart(int i, int j, int[,] grid, bool[,,] bounds, out int count, out LinkedNode<Tuple<int, int, int>> lastNode)
        {
            count = 0;
            LinkedNode<Tuple<int, int, int>> result = null;
            lastNode = null;

            if (!IsBounded(i, j, 0, bounds) && i - 1 > -1 && grid[i - 1, j] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i-1, j, 2) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 2, bounds) && i + 1 < bounds.GetLength(0) && grid[i + 1, j] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i+1, j, 0) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 1, bounds) && j+1 < bounds.GetLength(1) && grid[i, j+1] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j+1, 3) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 3, bounds) && j - 1 > -1 && grid[i, j - 1] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j-1, 1) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }
            return result;
        }

        LinkedNode<Tuple<int, int, int>> FindFreePartV1(int i, int j, int[,] grid, bool[,,] bounds, out int count, out LinkedNode<Tuple<int, int, int>> lastNode)
        {
            count = 0;
            LinkedNode<Tuple<int, int, int>> result = null;
            lastNode = null;

            if (!IsBounded(i, j, 0, bounds) && i - 1 > -1 && grid[i - 1, j] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j, 0) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 2, bounds) && i + 1 < bounds.GetLength(0) && grid[i + 1, j] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j, 2) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 1, bounds) && j + 1 < bounds.GetLength(1) && grid[i, j + 1] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j, 1) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }

            if (!IsBounded(i, j, 3, bounds) && j - 1 > -1 && grid[i, j - 1] == 0)
            {
                LinkedNode<Tuple<int, int, int>> newNode = new LinkedNode<Tuple<int, int, int>> { Value = new Tuple<int, int, int>(i, j, 3) };
                newNode.Next = result;
                result = newNode;
                if (newNode.Next == null)
                    lastNode = newNode;
                count++;
            }
            return result;
        }




        public LinkedNode<LinkedNode<Tuple<int, int>>> GetRegions(int[,] grid, bool[,,] bounds)
        {
            int crow = grid.GetLength(0);
            int ccolumn = grid.GetLength(1);

            LinkedNode<LinkedNode<Tuple<int, int>>> result = new LinkedNode<LinkedNode<Tuple<int, int>>>();
            LinkedNode<LinkedNode<Tuple<int, int>>> resultLastNode = result;

            bool[,] gridChecked = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < crow; i++)
                for (int j = 0; j < ccolumn; j++)
                {
                    if (grid[i, j] == 1 && !gridChecked[i,j])
                    {
                        LinkedNode<Tuple<int, int>> lastNode;
                        LinkedNode<Tuple<int, int>> region = GetRegion(i, j, grid, gridChecked, bounds, out lastNode);
                        resultLastNode.Value = region;
                        resultLastNode.Next = new LinkedNode<LinkedNode<Tuple<int, int>>>();
                        resultLastNode = resultLastNode.Next;
                    }
                }

            return result;
        }

        public LinkedNode<Tuple<int, int>> GetRegion(int i, int j, int[,] grid, bool[,] gridChecked, bool[,,] bounds, out LinkedNode<Tuple<int, int>> lastNode)
        {
            int crow = grid.GetLength(0);
            int ccolumn = grid.GetLength(1);
            lastNode = null;
            if (i < 0 || j < 0 || i > crow - 1 || j > ccolumn - 1 || grid[i, j] != 1)
                return null;

            LinkedNode<Tuple<int, int>> result = null;
            if (!gridChecked[i, j])
            {
                gridChecked[i, j] = true;
                result = new LinkedNode<Tuple<int, int>> { Value = new Tuple<int, int>(i, j) };
                lastNode = result;

                if (!IsBounded(i, j, 0,bounds))
                {
                    LinkedNode<Tuple<int, int>> lastNode2;
                    var region = GetRegion(i - 1, j, grid, gridChecked, bounds, out lastNode2);
                    if (region != null)
                    {
                        lastNode.Next = region;
                        lastNode = lastNode2;
                    }
                }
                if (!IsBounded(i, j, 3, bounds))
                {
                    LinkedNode<Tuple<int, int>> lastNode2;
                    var region = GetRegion(i, j - 1, grid, gridChecked, bounds, out lastNode2);
                    if (region != null)
                    {
                        lastNode.Next = region;
                        lastNode = lastNode2;
                    }
                }
                if (!IsBounded(i, j, 1, bounds))
                {
                    LinkedNode<Tuple<int, int>> lastNode2;
                    var region = GetRegion(i, j + 1, grid, gridChecked, bounds, out lastNode2);
                    if (region != null)
                    {
                        lastNode.Next = region;
                        lastNode = lastNode2;
                    }
                }
                if (!IsBounded(i, j, 2, bounds))
                {
                    LinkedNode<Tuple<int, int>> lastNode2;
                    var region = GetRegion(i + 1, j, grid, gridChecked, bounds, out lastNode2);
                    if (region != null)
                    {
                        lastNode.Next = region;
                        lastNode = lastNode2;
                    }
                }
            }

            return result;
        }
        
        public bool IsBounded(int i, int j, int side, bool[,,] bounds)
        {

            if (bounds[i, j, side])
                return true;
            else if (side == 0)
            {
                return i - 1 > -1 ? bounds[i - 1, j, 2] : true;
            }
            else if (side == 3)
            {
                return j - 1 > -1 ? bounds[i, j - 1, 1] : true;
            }
            else if (side == 1)
            {
                return j + 1 < bounds.GetLength(1) ? bounds[i, j + 1, 3] : true;
            }
            else if (side == 2)
            {
                return i + 1 < bounds.GetLength(0) ? bounds[i + 1, j, 0] : true;
            }

            return false;
        }
    }

    /// Solution class end



    public class LinkedNode<T>
    {

        public T Value;
        public LinkedNode<T> Next;

    }
}
