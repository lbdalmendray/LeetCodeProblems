using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Solution
    {
        public int CalculateMinimumHP(int[,] dungeon)
        {
            int[,] dungeonMin =  new int[dungeon.GetLength(0),dungeon.GetLength(1)];
            bool[,] dungeonCalculated = new bool[dungeon.GetLength(0), dungeon.GetLength(1)];
            dungeonCalculated[dungeon.GetLength(0) - 1, dungeon.GetLength(1) - 1] = true;

            var value = dungeon[dungeon.GetLength(0) - 1, dungeon.GetLength(1) - 1];
            dungeonMin[dungeon.GetLength(0) - 1, dungeon.GetLength(1) - 1] = value < 0 ? value*(-1) + 1 : 1;

            CalculateMinimumRecursive(dungeon, dungeonMin, dungeonCalculated, 0, 0);

            return dungeonMin[0,0];
        }

        public void CalculateMinimumRecursive(int [,] dungeon, int [,] dungeonMin, bool [,] dungeonCalculated ,  int x , int y )
        {
            if (dungeonCalculated[x, y])
                return;
            var currentValue = dungeon[x, y];

            var downValuePlusCurrent = 0;
            int downValue = int.MaxValue;

            if ( x + 1 < dungeon.GetLength(0))
            {
                if ( !dungeonCalculated[x+1,y])
                {
                    CalculateMinimumRecursive(dungeon, dungeonMin, dungeonCalculated, x + 1, y);
                }

                downValue = dungeonMin[x + 1, y];
                downValuePlusCurrent = currentValue > 0 ? Math.Max(downValue - currentValue, 1) : currentValue * (-1) + downValue;
            }

            int rightValue = int.MaxValue;
            var rightValuePlusCurrent = 0;
            if (y + 1 < dungeon.GetLength(1))
            {
                if (!dungeonCalculated[x, y + 1])
                {
                    CalculateMinimumRecursive(dungeon, dungeonMin, dungeonCalculated, x, y + 1);
                }

                rightValue = dungeonMin[x, y + 1];
                rightValuePlusCurrent = currentValue > 0 ? Math.Max(rightValue - currentValue, 1) : currentValue * (-1) + rightValue;
            }            

            if (x + 1 < dungeon.GetLength(0) && y + 1 < dungeon.GetLength(1))
                dungeonMin[x, y] = Math.Min(rightValuePlusCurrent, downValuePlusCurrent);
            else if(x + 1 < dungeon.GetLength(0))
                dungeonMin[x, y] = downValuePlusCurrent;
            else
                dungeonMin[x, y] = rightValuePlusCurrent;

            dungeonCalculated[x, y] = true;
        }
    }
}
