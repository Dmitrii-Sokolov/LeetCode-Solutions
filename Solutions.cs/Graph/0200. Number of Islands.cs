﻿namespace Problem200
{

  /// <summary>
  /// 200. Number of Islands
  /// https://leetcode.com/problems/number-of-islands
  /// 
  /// Difficulty Medium
  /// Acceptance 60.0%
  /// 
  /// Array
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    private int len0;
    private int len1;

    public int NumIslands(char[][] grid)
    {
      len0 = grid.Length;
      len1 = grid[0].Length;

      var result = 0;

      for (var i = 0; i < len0; i++)
      {
        for (var n = 0; n < len1; n++)
        {
          if (grid[i][n] == '1')
          {
            result++;
            Check(grid, i, n);
          }
        }
      }

      return result;
    }

    private void Check(char[][] grid, int i, int n)
    {
      if (grid[i][n] != '1')
        return;

      grid[i][n] = '0';

      if (i > 0)
        Check(grid, i - 1, n);

      if (i < len0 - 1)
        Check(grid, i + 1, n);

      if (n > 0)
        Check(grid, i, n - 1);

      if (n < len1 - 1)
        Check(grid, i, n + 1);
    }
  }
}
