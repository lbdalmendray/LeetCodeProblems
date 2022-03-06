using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBoundedInCircle
{
    public class Solution2
    {
        public bool IsRobotBounded(string instructions)
        {
            var currentDirection = Direction2.Up;
            var currentPosition = new Point(0, 0);
            ( currentDirection , currentPosition ) =  CalculateNewStateFrom(currentDirection, currentPosition, instructions);

            if (currentPosition == new Point(0,0))
                return true;
            else
            {
                if (currentDirection == Direction2.Up)
                    return false;
                else return true;
            }
        }

        private (Direction2 , Point) CalculateNewStateFrom(Direction2 direction , Point position
            , string instructions)
        {
            var result = (direction, position);

            foreach (var instruction in instructions)
            {
                //// GO STRAIGHT 1 UNIT
                if( instruction == 'G')
                {
                    if (result.direction == Direction2.Up)
                        result = (result.direction, new Point(result.position.X, result.position.Y + 1));
                    else if (result.direction == Direction2.Down)
                        result = (result.direction, new Point(result.position.X, result.position.Y - 1));
                    else if (result.direction == Direction2.Right)
                        result = (result.direction, new Point(result.position.X + 1, result.position.Y ));
                    else //if (result.direction == Direction2.Left)
                        result = (result.direction, new Point(result.position.X - 1, result.position.Y));
                }
                //// TURN LEFT 90 DEGREES
                else if ( instruction =='L')
                {
                    if (result.direction == Direction2.Up)
                        result = (Direction2.Left, result.position);
                    else if (result.direction == Direction2.Left)
                        result = (Direction2.Down, result.position);
                    else if (result.direction == Direction2.Down)
                        result = (Direction2.Right, result.position);
                    else // if (result.direction == Direction2.Up)
                        result = (Direction2.Up, result.position);
                }
                //// TURN RIGHT 90 DEGREES
                else // if ( instruction =='R')
                {
                    if (result.direction == Direction2.Up)
                        result = (Direction2.Left, result.position);
                    else if (result.direction == Direction2.Left)
                        result = (Direction2.Down, result.position);
                    else if (result.direction == Direction2.Down)
                        result = (Direction2.Right, result.position);
                    else // if (result.direction == Direction2.Up)
                        result = (Direction2.Up, result.position);
                }
            }

            return result;
        }
    }


    public enum Direction2
    {
        Up,
        Down,
        Right,
        Left
    }
}
