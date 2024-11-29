namespace Problem2577
{

  /// <summary>
  /// 2577. Minimum Time to Visit a Cell In a Grid
  /// https://leetcode.com/problems/minimum-time-to-visit-a-cell-in-a-grid
  /// 
  /// Difficulty Hard
  /// Acceptance 45.2%
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

    public int MinimumTime(int[][] grid)
    {
      if (grid[0][1] > 1 && grid[1][0] > 1)
        return -1;

      var maxX = grid.Length - 1;
      var maxY = grid[0].Length - 1;

      var queue = new PriorityQueue<(int X, int Y, int time), int>();
      queue.Enqueue((0, 0, 0), 0);
      grid[0][0] = -1;

      while (true)
      {
        var (x, y, time) = queue.Dequeue();
        if (x == maxX && y == maxY)
          return -1 - grid[x][y];

        for (var d = 0; d < 4; d++)
        {
          var (x0, y0) = (x + Directions[d], y + Directions[d + 1]);
          if (0 <= x0 && x0 <= maxX && 0 <= y0 && y0 <= maxY)
          {
            var cellTime = grid[x0][y0];
            if (cellTime >= 0)
            {
              cellTime = Math.Max(cellTime + (cellTime + x0 + y0) % 2, time + 1);
              queue.Enqueue((x0, y0, cellTime), cellTime);
              grid[x0][y0] = -1 - cellTime;
            }
          }
        }
      }
    }
  }
}
