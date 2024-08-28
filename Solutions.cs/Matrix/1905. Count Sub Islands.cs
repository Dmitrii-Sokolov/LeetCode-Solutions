namespace Problem1905
{

  /// <summary>
  /// 1905. Count Sub Islands
  /// https://leetcode.com/problems/count-sub-islands
  /// 
  /// Difficulty Medium
  /// Acceptance 69.1%
  /// 
  /// Array
  /// Depth - First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int CountSubIslands(int[][] mask, int[][] grid)
    {
      var length = mask.Length;
      var width = mask[0].Length;

      var result = 0;

      for (var i = 0; i < length; i++)
      {
        for (var n = 0; n < width; n++)
        {
          if (grid[i][n] > 0 && IsPartOfSubIsland(mask, grid, i, n, length, width))
            result++;
        }
      }

      return result;
    }

    private bool IsPartOfSubIsland(int[][] mask, int[][] grid, int i, int n, int length, int width)
    {
      if (grid[i][n] == 0)
        return true;

      grid[i][n] = 0;

      var result = mask[i][n] > 0;
      result &= i <= 0 || IsPartOfSubIsland(mask, grid, i - 1, n, length, width);
      result &= i >= length - 1 || IsPartOfSubIsland(mask, grid, i + 1, n, length, width);
      result &= n <= 0 || IsPartOfSubIsland(mask, grid, i, n - 1, length, width);
      result &= n >= width - 1 || IsPartOfSubIsland(mask, grid, i, n + 1, length, width);

      return result;
    }
  }
}
