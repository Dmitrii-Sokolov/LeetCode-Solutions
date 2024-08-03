﻿namespace Problem1041
{

  /// <summary>
  /// 1041. Robot Bounded In Circle
  /// https://leetcode.com/problems/robot-bounded-in-circle
  /// 
  /// Difficulty Medium
  /// Acceptance 55.8%
  /// 
  /// Math
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    public bool IsRobotBounded(string instructions)
    {
      var direction = 0;
      var x = 0;
      var y = 0;

      for (var i = 0; i < instructions.Length; i++)
      {
        var c = instructions[i];
        if (c == 'G')
        {
          if (direction == 0)
            y++;
          else if (direction == 1)
          {
            x++;
          }
          else if (direction == 2)
          {
            y--;
          }
          else if (direction == 3)
          {
            x--;
          }
        }
        else if (c == 'L')
        {
          direction = (direction + 3) % 4;
        }
        else if (c == 'R')
        {
          direction = (direction + 1) % 4;
        }
      }

      return direction != 0 || (x == 0 && y == 0);
    }
  }
}