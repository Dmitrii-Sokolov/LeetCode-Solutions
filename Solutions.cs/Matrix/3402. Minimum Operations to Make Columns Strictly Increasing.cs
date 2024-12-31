namespace Problem3402
{

  /// <summary>
  /// 3402. Minimum Operations to Make Columns Strictly Increasing
  /// https://leetcode.com/problems/minimum-operations-to-make-columns-strictly-increasing
  /// 
  /// Difficulty Easy
  /// Acceptance 72.7%
  /// 
  /// </summary>
  public class Solution
  {
    public int MinimumOperations(int[][] grid)
    {
      var result = 0;
      for (var i = 0; i < grid[0].Length; i++)
      {
        var lastValue = grid[0][i];
        for (var j = 1; j < grid.Length; j++)
        {
          if (grid[j][i] <= lastValue)
          {
            result += lastValue - grid[j][i] + 1;
            lastValue++;
          }
          else
          {
            lastValue = grid[j][i];
          }
        }
      }

      return result;
    }
  }
}
