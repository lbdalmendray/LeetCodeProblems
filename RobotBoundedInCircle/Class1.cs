using System;

namespace RobotBoundedInCircle
{
    public class Solution
    {
        public bool IsRobotBounded(string instructions)
        {
            if( instructions == null || instructions.Length == 0 )
                return true;

            Tuple<int[], Direction> newState =  GetNewState( instructions) ;
            int [] newPosition = newState.Item1;
            Direction direction = newState.Item2;
            if( newPosition[0] == 0 && newPosition[1] == 0)
                return true ;
            if ( direction == Direction.Up )
                return false;
            else //  if ( direction == Direction.Down || direction == Direction.Right || direction == Direction.Left )
                return true;
        }

        Tuple<int[],Direction> GetNewState(string instructions)
        {
            int [] position = new int[]{0,0};
            Direction dir = Direction.Up;

            for(int i = 0; i < instructions.Length ; i++)
            {
                if ( instructions[i] == 'G')
                {
                    if ( dir == Direction.Up)
                        position[1] ++;
                    else if ( dir == Direction.Right)
                        position[0]++;
                    else if ( dir == Direction.Down)
                        position[1]--;
                    else // if ( dir == Direction.Left)
                        position[0]--;    
                }
                else if ( instructions[i] == 'L')
                {
                    if ( dir == Direction.Up)
                        dir = Direction.Left;
                    else if ( dir == Direction.Right)
                        dir = Direction.Up;
                    else if ( dir == Direction.Down)
                        dir = Direction.Right;
                    else // if ( dir == Direction.Left)
                        dir = Direction.Down;
                }
                else // if ( instructions[i] == 'R')
                {
                    if ( dir == Direction.Up)
                        dir = Direction.Right;
                    else if ( dir == Direction.Right)
                        dir = Direction.Down;
                    else if ( dir == Direction.Down)
                        dir = Direction.Left;
                    else // if ( dir == Direction.Left)
                        dir = Direction.Up;
                }
            }

            return new Tuple<int[],  Direction> ( position , dir ) ;
        }
    }

    internal enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

}
