namespace Problem1568
{

  /// <summary>
  /// 1568. Minimum Number of Days to Disconnect Island
  /// https://leetcode.com/problems/minimum-number-of-days-to-disconnect-island
  /// 
  /// Difficulty Hard
  /// Acceptance 50.4%
  /// 
  /// Array
  /// Depth - First Search
  /// Breadth-First Search
  /// Matrix
  /// Strongly Connected Component
  /// </summary>
  public class Solution
  {
    public int MinDays(int[][] grid)
    {
      var xSize = grid.Length;
      var ySize = grid[0].Length;
      //var count = 0;

      //for (var x = 0; x < xSize; x++)
      //{
      //  for (var y = 0; y < ySize; y++)
      //  {
      //    if (grid[x][y] > 0)
      //      grid[x][y] = ++count;
      //  }
      //}

      //if (count == 0)
      //  return 0;

      if (CountIslands(grid, xSize, ySize) != 1)
        return 0;

      for (var x = 0; x < xSize; x++)
      {
        for (var y = 0; y < ySize; y++)
        {
          if (grid[x][y] > 0)
          {
            grid[x][y] = 0;

            if (CountIslands(grid, xSize, ySize) != 1)
              return 1;

            grid[x][y] = 1;
          }
        }
      }

      return 2;
    }

    public static int CountIslands(int[][] grid, int xSize, int ySize)
    {
      var visited = new bool[xSize, ySize];
      var result = 0;
      for (var x = 0; x < xSize; x++)
      {
        for (var y = 0; y < ySize; y++)
        {
          if (grid[x][y] > 0 && !visited[x, y])
          {
            CheckNeighbours(grid, visited, x, y, xSize, ySize);
            result++;

            if (result == 2)
              return 2;
          }
        }
      }

      return result;
    }

    private static void CheckNeighbours(int[][] grid, bool[,] visited, int x, int y, int xSize, int ySize)
    {
      if (visited[x, y] || grid[x][y] == 0)
        return;

      visited[x, y] = true;

      if (x + 1 < xSize)
        CheckNeighbours(grid, visited, x + 1, y, xSize, ySize);

      if (x - 1 >= 0)
        CheckNeighbours(grid, visited, x - 1, y, xSize, ySize);

      if (y + 1 < ySize)
        CheckNeighbours(grid, visited, x, y + 1, xSize, ySize);

      if (y - 1 >= 0)
        CheckNeighbours(grid, visited, x, y - 1, xSize, ySize);
    }
  }
}
