namespace Problem840
{

  /// <summary>
  /// 840. Magic Squares In Grid
  /// https://leetcode.com/problems/magic-squares-in-grid
  /// 
  /// Difficulty Medium
  /// Acceptance 44.6%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Matrix
  /// </summary>
  public class Solution
  {
    private const int Sum = 15;
    private const int Min = 1;
    private const int Max = 9;

    public int NumMagicSquaresInside(int[][] grid)
    {
      var xMax = grid.Length;
      var yMax = grid[0].Length;
      if (xMax < 3 || yMax < 3)
        return 0;

      var verticals = new bool[xMax, yMax - 2];
      for (var x = 0; x < xMax; x++)
      {
        for (var y = 0; y < yMax - 2; y++)
          verticals[x, y] = grid[x][y] + grid[x][y + 1] + grid[x][y + 2] == Sum;
      }

      var horizontals = new bool[xMax - 2, yMax];
      for (var x = 0; x < xMax - 2; x++)
      {
        for (var y = 0; y < yMax; y++)
          horizontals[x, y] = grid[x][y] + grid[x + 1][y] + grid[x + 2][y] == Sum;
      }

      var diagonals = new bool[xMax - 2, yMax - 2];
      for (var x = 0; x < xMax - 2; x++)
      {
        for (var y = 0; y < yMax - 2; y++)
          diagonals[x, y] = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2] == Sum &&
            grid[x + 2][y] + grid[x + 1][y + 1] + grid[x][y + 2] == Sum;
      }

      var result = 0;
      var numbers = new HashSet<int>();
      for (var x = 0; x < xMax - 2; x++)
      {
        for (var y = 0; y < yMax - 2; y++)
        {
          if (Check(grid, verticals, horizontals, diagonals, numbers, x, y))
            result++;
        }
      }

      return result;
    }

    private static bool Check(
      int[][] grid,
      bool[,] verticals,
      bool[,] horizontals,
      bool[,] diagonals,
      HashSet<int> numbers,
      int x,
      int y)
    {
      if (!diagonals[x, y])
        return false;

      for (var d = 0; d < 3; d++)
      {
        if (!verticals[x + d, y] || !horizontals[x, y + d])
          return false;
      }

      numbers.Clear();
      for (var dx = 0; dx < 3; dx++)
      {
        for (var dy = 0; dy < 3; dy++)
        {
          var number = grid[x + dx][y + dy];
          if (number < Min || number > Max || !numbers.Add(number))
            return false;
        }
      }

      return true;
    }
  }
}
