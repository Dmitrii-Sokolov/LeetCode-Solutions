namespace Problem1368
{

  /// <summary>
  /// 1368. Minimum Cost to Make at Least One Valid Path in a Grid
  /// https://leetcode.com/problems/minimum-cost-to-make-at-least-one-valid-path-in-a-grid
  /// 
  /// Difficulty Hard
  /// Acceptance 65.6%
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
    public int MinCost(int[][] gridRaw)
    {
      var width = gridRaw.Length;
      var height = gridRaw[0].Length;
      var last = width * height - 1;
      Span<int> grid = stackalloc int[width * height];
      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < height; y++)
          grid[x * height + y] = gridRaw[x][y];
      }

      var current = new Queue<int>();
      current.Enqueue(0);
      var cost = 0;

      while (true)
      {
        var next = new Queue<int>();
        while (current.TryDequeue(out var cell))
        {
          if (grid[cell] == 0)
            continue;

          if (cell == last)
            return cost;

          var x = cell / height;
          var y = cell % height;

          if (x > 0)
          {
            var queue = grid[cell] == 4 ? current : next;
            queue.Enqueue(cell - height);
          }

          if (x < width - 1)
          {
            var queue = grid[cell] == 3 ? current : next;
            queue.Enqueue(cell + height);
          }

          if (y > 0)
          {
            var queue = grid[cell] == 2 ? current : next;
            queue.Enqueue(cell - 1);
          }

          if (y < height - 1)
          {
            var queue = grid[cell] == 1 ? current : next;
            queue.Enqueue(cell + 1);
          }

          grid[cell] = 0;
        }

        cost++;
        current = next;
      }
    }
  }
}
