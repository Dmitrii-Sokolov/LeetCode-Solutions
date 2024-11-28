namespace Problem2290
{

  /// <summary>
  /// 2290. Minimum Obstacle Removal to Reach Corner
  /// https://leetcode.com/problems/minimum-obstacle-removal-to-reach-corner
  /// 
  /// Difficulty Hard
  /// Acceptance 61.5%
  /// 
  /// Array
  /// Breadth-First Search
  /// Graph
  /// Heap (Priority Queue)
  /// Matrix
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    private static int[] Directions = { 0, 1, 0, -1, 0 };

    public int MinimumObstacles(int[][] grid)
    {
      var maxX = grid.Length - 1;
      var maxY = grid[0].Length - 1;
      var queue = new LinkedList<(int X, int Y)>();
      queue.AddFirst((maxX, maxY));
      grid[maxX][maxY] = -1;
      while (true)
      {
        var (x, y) = queue.First.Value;
        if (x == 0 && y == 0)
          return -1 - grid[x][y];

        queue.RemoveFirst();
        for (var i = 0; i < 4; i++)
        {
          var (x0, y0) = (x + Directions[i], y + Directions[i + 1]);
          if (0 <= x0 && x0 <= maxX && 0 <= y0 && y0 <= maxY)
          {
            var cellCost = grid[x0][y0];
            if (cellCost == 0)
            {
              queue.AddFirst((x0, y0));
              grid[x0][y0] = grid[x][y];
            }
            else if (cellCost == 1)
            {
              queue.AddLast((x0, y0));
              grid[x0][y0] = grid[x][y] - 1;
            }
          }
        }
      }
    }
  }
}
