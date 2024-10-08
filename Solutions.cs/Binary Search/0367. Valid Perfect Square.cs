﻿namespace Problem367
{

  /// <summary>
  /// 367. Valid Perfect Square
  /// https://leetcode.com/problems/valid-perfect-square
  /// 
  /// Difficulty Easy
  /// Acceptance 43.8%
  /// 
  /// Math
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public bool IsPerfectSquare(int num)
    {
      var min = 0;
      var max = 1;
      var test = num;
      while (test > 0)
      {
        test >>= 2;
        max <<= 1;
      }

      while (min < max)
      {
        var middle = (max + min) >> 1;
        var middle2 = middle * (long)middle;

        if (middle2 < num)
        {
          if (max - min == 1)
            return max * max == num;

          min = middle;
        }
        else if (middle2 > num)
        {
          max = middle - 1;
        }
        else
        {
          return true;
        }
      }

      return false;
    }
  }
}
