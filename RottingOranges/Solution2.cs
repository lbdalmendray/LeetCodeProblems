using System;
using System.Linq;
using System.Collections.Generic;

namespace RottingOranges
{
    public class Solution2
    {
        /*
         0 representing an empty cell,
         1 representing a fresh orange, or
         2 representing a rotten orange.
         */
        public int OrangesRotting(int[][] grid)
        {
            int result = 0;
            if (grid == null || grid[0] == null || grid[0].Length == 0)
                return 0;
            /// position and minutes 
            LinkedList<(int,int,int)> rottenList = GetRottenList(grid);
            while(rottenList.Count != 0)
            {
                var ( x,y,minutes ) = rottenList.First.Value ;
                rottenList.RemoveFirst();
                result = Math.Max(result, minutes);
                var minutesPlus1 = minutes + 1;
                LinkedList<(int,int)> freshOrangeChildren = GetFreshOrangeChildren(x,y, grid);
                foreach ( var (cX,cY) in freshOrangeChildren )
                {
                    grid[cX][cY] = 2;
                    rottenList.AddLast((cX,cY,minutesPlus1));
                }
            }
            return result;
        }
        LinkedList<(int,int,int)> GetRottenList(int[][] grid)
        {
            LinkedList<(int,int,int)> result = new LinkedList<(int,int,int)>();
            
            for(int i = 0 ; i < grid.Length ; i++)
                for( int j = 0 ; j < grid[0].Length ; j++)
                    if( grid[i][j] == 2)
                        result.AddFirst((i,j,0));
            return result;
        }

        LinkedList<(int,int)> GetFreshOrangeChildren(int x, int y, int[][] grid)
        {
            LinkedList<(int,int)> preResult = new LinkedList<(int,int)>();
            LinkedList<(int,int)> result = new LinkedList<(int,int)>();
            if ( x > 0 )
                preResult.AddLast((x-1,y));
            if ( y > 0)    
                preResult.AddLast((x,y-1));
            if ( x < grid.Length - 1)    
                preResult.AddLast((x+1,y));
            if ( y < grid[0].Length - 1)    
                preResult.AddLast((x,y+1));
            foreach ( var ( x1,y1 ) in preResult.ToArray())
            {
                if(grid[x1][y1] == 1)
                    result.AddFirst((x1,y1));
            }    
            return result;
        }
    }
}
