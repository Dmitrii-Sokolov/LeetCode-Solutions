namespace Problem2352
{

  /// <summary>
  /// 2352. Equal Row and Column Pairs
  /// https://leetcode.com/problems/equal-row-and-column-pairs
  /// 
  /// Difficulty Medium
  /// Acceptance 70.3%
  /// 
  /// Array
  /// Hash Table
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int EqualPairs(int[][] grid)
    {
      var n = grid.Length;
      if (n == 1)
        return 1;

      var xHashes = new int[n];
      var yHashes = new int[n];
      for (var j = 0; j < n; j++)
      {
        for (var i = 0; i < n; i++)
        {
          yHashes[j] = yHashes[j] * 7 + grid[i][j];
          xHashes[j] = xHashes[j] * 7 + grid[j][i];
        }
      }

      var result = 0;
      for (var x = 0; x < n; x++)
      {
        for (var y = 0; y < n; y++)
        {
          if (xHashes[x] == yHashes[y])
            result++;
        }
      }

      return result;
    }
  }
}
