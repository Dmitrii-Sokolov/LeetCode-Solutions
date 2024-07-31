namespace Problem2812
{

  /// <summary>
  /// 2812. Find the Safest Path in a Grid
  /// https://leetcode.com/problems/find-the-safest-path-in-a-grid
  /// 
  /// Difficulty Medium
  /// Acceptance 49.1%
  /// 
  /// Array
  /// Binary Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
      var n = grid.Count;
      var current = new HashSet<Cell>();

      for (var x = 0; x < n; x++)
      {
        for (var y = 0; y < n; y++)
        {
          var c = grid[x][y];
          if (c == 1)
            current.Add(new Cell(x, y));

          grid[x][y] = 2 * n;
        }
      }

      var d = 0;
      while (current.Count > 0)
      {
        var next = new HashSet<Cell>();
        foreach (var cell in current)
        {
          var x = cell.x;
          var y = cell.y;
          var c = grid[x][y];

          if (c > d)
          {
            grid[x][y] = d;
            Set(next, x, y, n);
          }
        }

        d++;
        current = next;
      }

      var safetyMax = Math.Min(grid[0][0], grid[n - 1][n - 1]);
      var safetyMin = 1;
      var result = 0;

      while (safetyMin <= safetyMax)
      {
        var safety = (safetyMin + safetyMax) / 2;
        if (Check(grid, safety))
        {
          result = safety;
          safetyMin = safety + 1;
        }
        else
        {
          safetyMax = safety - 1;
        }
      }

      return result;
    }

    private bool Check(IList<IList<int>> grid, int safety)
    {
      var n = grid.Count;
      var end = new Cell(n - 1, n - 1);
      var start = new Cell(0, 0);
      var visited = new bool[n, n];
      var current = new HashSet<Cell>();
      current.Add(end);

      while (current.Count > 0)
      {
        var next = new HashSet<Cell>();
        foreach (var cell in current)
        {
          var x = cell.x;
          var y = cell.y;
          var s = grid[x][y];

          if (!visited[x, y])
          {
            visited[x, y] = true;

            if (cell.Equals(start))
              return true;

            if (s >= safety)
              Set(next, x, y, n);
          }
        }

        current = next;
      }

      return false;
    }

    private void Set(HashSet<Cell> next, int x, int y, int n)
    {
      if (x + 1 < n)
        next.Add(new Cell(x + 1, y));
      if (x - 1 >= 0)
        next.Add(new Cell(x - 1, y));
      if (y + 1 < n)
        next.Add(new Cell(x, y + 1));
      if (y - 1 >= 0)
        next.Add(new Cell(x, y - 1));
    }

    private record Cell(int x, int y) { }
  }
}
