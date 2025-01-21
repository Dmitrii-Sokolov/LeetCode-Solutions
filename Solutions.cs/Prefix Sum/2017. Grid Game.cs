namespace Problem2017
{

  /// <summary>
  /// 2017. Grid Game
  /// https://leetcode.com/problems/grid-game
  /// 
  /// Difficulty Medium
  /// Acceptance 53.3%
  /// 
  /// Array
  /// Matrix
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public long GridGame(int[][] grid)
    {
      var result = long.MaxValue;
      var prefixTop = 0L;
      var prefixBottom = 0L;
      for (var i = 0; i < grid[0].Length; i++)
        prefixTop += grid[0][i];

      for (var i = 0; i < grid[0].Length; i++)
      {
        prefixTop -= grid[0][i];

        var prefix = Math.Max(prefixTop, prefixBottom);
        if (result > prefix)
          result = prefix;

        prefixBottom += grid[1][i];
      }

      return result;
    }
  }
}
