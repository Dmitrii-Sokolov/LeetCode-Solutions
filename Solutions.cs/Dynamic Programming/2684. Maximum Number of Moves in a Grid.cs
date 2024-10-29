namespace Problem2684
{

  /// <summary>
  /// 2684. Maximum Number of Moves in a Grid
  /// https://leetcode.com/problems/maximum-number-of-moves-in-a-grid 
  /// 
  /// Difficulty Medium
  /// Acceptance 52.6%
  /// 
  /// Array
  /// Dynamic Programming
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MaxMoves(int[][] grid)
    {
      var height = grid.Length;
      var width = grid[0].Length;

      var result = 1;
      var subResults = Enumerable.Repeat(1, height).ToArray();
      for (var x = 1; x < width; x++)
      {
        var next = new int[height];

        for (var y = 0; y < height; y++)
        {
          Check(grid, subResults, next, x, y, y - 1);
          Check(grid, subResults, next, x, y, y);
          Check(grid, subResults, next, x, y, y + 1);

          if (next[y] > result)
            result = next[y];
        }

        subResults = next;
      }

      return result - 1;
    }

    private static void Check(int[][] grid, int[] subResults, int[] next, int x, int y, int yPrev)
    {
      if (0 <= yPrev &&
        yPrev < grid.Length &&
        subResults[yPrev] != 0 &&
        grid[y][x] > grid[yPrev][x - 1] &&
        subResults[yPrev] + 1 > next[y])
        next[y] = subResults[yPrev] + 1;
    }
  }
}
