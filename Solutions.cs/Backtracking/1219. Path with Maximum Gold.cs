namespace Problem1219
{

  /// <summary>
  /// 1219. Path with Maximum Gold
  /// https://leetcode.com/problems/path-with-maximum-gold
  /// 
  /// Difficulty Medium
  /// Acceptance 68.0%
  /// 
  /// Array
  /// Backtracking
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int GetMaximumGold(int[][] grid)
    {
      Height = grid.Length;
      Width = grid[0].Length;
      Mine = grid;

      for (var x = 0; x < Width; x++)
      {
        for (var y = 0; y < Height; y++)
        {
          Try(x, y, 0);
        }
      }

      return Result;
    }

    private int Width = 0;
    private int Height = 0;
    private int Result = 0;
    private int[][] Mine;

    private void Try(int x, int y, int initial)
    {
      if (x < 0 || Width <= x ||
          y < 0 || Height <= y ||
          Mine[y][x] <= 0)
      {
        Result = Math.Max(Result, initial);
        return;
      }

      initial += Mine[y][x];
      Mine[y][x] *= -1;

      Try(x + 1, y, initial);
      Try(x - 1, y, initial);
      Try(x, y + 1, initial);
      Try(x, y - 1, initial);

      Mine[y][x] *= -1;
    }
  }
}
