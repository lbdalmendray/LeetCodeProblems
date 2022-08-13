using System;
using System.Collections.Generic;

namespace RobotRoomCleaner
{
 /**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

    public class Solution
    {
        public void CleanRoom(Robot robot)
        {
            HashSet<(int,int)> selected = new HashSet<(int, int)>();
            LinkedList<PosInfo> posInfoList = new LinkedList<PosInfo>();
            posInfoList.AddLast(new PosInfo());
            Direction currentDirection = Direction.Up;
            selected.Add((0, 0)) ;
            robot.Clean();
            while (posInfoList.Count != 0)
            {
                var posInfo = posInfoList.Last.Value;
                if(IsPossibleToMoveSetSelected(posInfo,Direction.Up, selected))
                {
                    LookTo(robot, Direction.Up, ref currentDirection);
                    if(robot.Move())
                    {
                        PosInfo newInfo = new PosInfo { X = posInfo.X, Y = posInfo.Y + 1, ComesFrom = Direction.Down };
                        posInfoList.AddLast(newInfo);
                        robot.Clean();
                    }
                }
                else if (IsPossibleToMoveSetSelected(posInfo, Direction.Down, selected))
                {
                    LookTo(robot, Direction.Down, ref currentDirection);
                    if (robot.Move())
                    {
                        PosInfo newInfo = new PosInfo { X = posInfo.X, Y = posInfo.Y - 1, ComesFrom = Direction.Up };
                        posInfoList.AddLast(newInfo);
                        robot.Clean();
                    }
                }
                else if (IsPossibleToMoveSetSelected(posInfo, Direction.Right, selected))
                {
                    LookTo(robot, Direction.Right, ref currentDirection);
                    if (robot.Move())
                    {
                        PosInfo newInfo = new PosInfo { X = posInfo.X+1, Y = posInfo.Y , ComesFrom = Direction.Left };
                        posInfoList.AddLast(newInfo);
                        robot.Clean();
                    }
                }
                else if (IsPossibleToMoveSetSelected(posInfo, Direction.Left, selected))
                {
                    LookTo(robot, Direction.Left, ref currentDirection);
                    if (robot.Move())
                    {
                        PosInfo newInfo = new PosInfo { X = posInfo.X - 1, Y = posInfo.Y, ComesFrom = Direction.Right };
                        posInfoList.AddLast(newInfo);
                        robot.Clean();
                    }
                }
                else
                {
                    if (posInfo.ComesFrom.HasValue)
                    {
                        LookTo(robot, posInfo.ComesFrom.Value, ref currentDirection);
                        robot.Move();
                    }
                    posInfoList.RemoveLast();
                }
            }   
        }

        private bool IsPossibleToMoveSetSelected(PosInfo posInfo, Direction direction, HashSet<(int, int)> selected)
        {
            bool result;
            (int, int) newPos;
            if (direction == Direction.Up)
            {
                newPos = (posInfo.Y + 1, posInfo.X);
                result = !selected.Contains((posInfo.Y + 1, posInfo.X));
            }
            else if (direction == Direction.Right)
            {
                newPos = (posInfo.Y, posInfo.X + 1);
                result = !selected.Contains((posInfo.Y, posInfo.X + 1));
            }
            else if (direction == Direction.Down)
            {
                newPos = (posInfo.Y - 1, posInfo.X);
                result = !selected.Contains((posInfo.Y - 1, posInfo.X));
            }
            else //if (direction == Direction.Left)
            {
                newPos = (posInfo.Y, posInfo.X - 1);
                result = !selected.Contains((posInfo.Y, posInfo.X - 1));
            }
            if (result)
                selected.Add((newPos.Item1, newPos.Item2));
            return result;
        }

        public void LookTo(Robot robot, Direction goToDirection, ref Direction currentDirection)
        {
            while(goToDirection != currentDirection)
            {
                if (currentDirection == Direction.Up)
                {
                    robot.TurnRight();
                    currentDirection = Direction.Right;
                }
                else if (currentDirection == Direction.Right)
                {
                    robot.TurnRight();
                    currentDirection = Direction.Down;
                }
                else if ( currentDirection == Direction.Down)
                {
                    robot.TurnRight();
                    currentDirection = Direction.Left;
                }
                else
                {
                    robot.TurnRight();
                    currentDirection = Direction.Up;
                }
            }
        }
    }

    public class PosInfo
    {
        public Direction? ComesFrom { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}
