namespace Problem1289
{

  /// <summary>
  /// 1289. Minimum Falling Path Sum II
  /// https://leetcode.com/problems/minimum-falling-path-sum-ii
  /// 
  /// Difficulty Hard 64.3%
  /// 
  /// Array
  /// Dynamic Programming
  /// Matrix
  /// </summary>
  class Solution
  {
    public int minFallingPathSum(int[][] grid)
    {
      var n = grid[0].length;
      if (n == 1)
        return grid[0][0];

      var mins = new int[n];

      for (var r = 0; r < n; r++)
      {
        var min0Index = 0;
        var min1 = mins[1];

        for (var i = 1; i < n; i++)
        {
          if (mins[min0Index] >= mins[i])
          {
            min1 = mins[min0Index];
            min0Index = i;
          }
          else if (min1 >= mins[i])
          {
            min1 = mins[i];
          }
        }

        var row = grid[r];
        var min0 = mins[min0Index];

        for (var i = 0; i < n; i++)
        {
          if (i == min0Index)
          {
            mins[i] = row[i] + min1;
          }
          else
          {
            mins[i] = row[i] + min0;
          }
        }
      }

      var result = mins[0];
      for (var i = 1; i < n; i++)
      {
        result = Math.min(result, mins[i]);
      }

      return result;
    }
  }
}
