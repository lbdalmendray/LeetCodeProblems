using RobotRoomCleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotRoomCleanerTest
{
    public class RobotTester : Robot
    {
        private readonly int[,] world;
        private (int, int) currentPos;
        private Direction direction;

        public RobotTester(int [,] world, (int x,int y) pos)
        {
            this.world = world;
            this.currentPos = pos;
            this.direction = Direction.Up;
        }

        public void Clean()
        {
            world[currentPos.Item2, currentPos.Item1] = 2;
        }

        public bool Move()
        {
            (int x, int y) nextPos;
            if( direction == Direction.Up )
            {
                nextPos = (currentPos.Item1, currentPos.Item2+1);
            }
            else if (direction == Direction.Down)
            {
                nextPos = (currentPos.Item1, currentPos.Item2 - 1);
            }
            else if (direction == Direction.Right)
            {
                nextPos = (currentPos.Item1 + 1, currentPos.Item2 );
            }
            else // if (direction == Direction.Left)
            {
                nextPos = (currentPos.Item1 - 1, currentPos.Item2);
            }
            if( nextPos.x > -1 && nextPos.x < world.GetLength(1)
                && nextPos.y > -1 && nextPos.y < world.GetLength(0)
                && world[nextPos.y, nextPos.x] != 0)
            {
                currentPos = nextPos;
                return true;
            }
            else
            {
                return false;
            }            
        }

        public void TurnLeft()
        {
            if ( direction == Direction.Up )
            {
                direction = Direction.Left;
            }
            else if (direction == Direction.Left)
            {
                direction = Direction.Down;
            }
            else if (direction == Direction.Down)
            {
                direction = Direction.Right;
            }
            else //if (direction == Direction.Right)
            {
                direction = Direction.Up;
            }
        }

        public void TurnRight()
        {
            if (direction == Direction.Up)
            {
                direction = Direction.Right;
            }
            else if (direction == Direction.Left)
            {
                direction = Direction.Up;
            }
            else if (direction == Direction.Down)
            {
                direction = Direction.Left;
            }
            else //if (direction == Direction.Right)
            {
                direction = Direction.Down;
            }
        }
    }
}
