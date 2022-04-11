using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotRoomCleaner
{
    public interface Robot
    {
      // Returns true if the cell in front is open and robot moves into the cell.
      // Returns false if the cell in front is blocked and robot stays in the current cell.
      public bool Move();
 
      // Robot will stay in the same cell after calling turnLeft/turnRight.
      // Each turn will be 90 degrees.
      public void TurnLeft();
      public void TurnRight();
 
      // Clean the current cell.
      public void Clean();
  }
}
