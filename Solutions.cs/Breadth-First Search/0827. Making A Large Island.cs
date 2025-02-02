namespace Problem827
{

  /// <summary>
  /// 827. Making A Large Island
  /// https://leetcode.com/problems/making-a-large-island
  /// 
  /// Difficulty Hard
  /// Acceptance 50.8%
  /// 
  /// Array
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int LargestIsland(int[][] grid)
    {
      var n = grid.Length;
      var islandNumber = 1;
      var islandSizes = new List<int>();
      var queue = new Queue<int>();
      for (var x = 0; x < n; x++)
      {
        for (var y = 0; y < n; y++)
        {
          if (grid[x][y] == 1)
          {
            islandNumber++;
            queue.Enqueue(x * n + y);
            var area = 0;
            while (queue.TryDequeue(out var cell))
            {
              var i = cell / n;
              var j = cell % n;

              if (grid[i][j] == 1)
              {
                grid[i][j] = islandNumber;
                area++;

                if (i > 0)
                  queue.Enqueue((i - 1) * n + j);

                if (i < n - 1)
                  queue.Enqueue((i + 1) * n + j);

                if (j > 0)
                  queue.Enqueue(i * n + j - 1);

                if (j < n - 1)
                  queue.Enqueue(i * n + j + 1);
              }
            }

            islandSizes.Add(area);
          }
        }
      }

      if (islandSizes.Count == 1)
        return Math.Min(n * n, islandSizes[0] + 1);

      var result = 0;
      for (var x = 0; x < n; x++)
      {
        for (var y = 0; y < n; y++)
        {
          if (grid[x][y] == 0)
          {
            var candidate = 0;
            var neighbor0 = x > 0 ? grid[x - 1][y] : 0;
            var neighbor1 = x < n - 1 ? grid[x + 1][y] : 0;
            var neighbor2 = y > 0 ? grid[x][y - 1] : 0;
            var neighbor3 = y < n - 1 ? grid[x][y + 1] : 0;

            if (neighbor0 > 1)
              candidate += islandSizes[neighbor0 - 2];

            if (neighbor1 > 1 && neighbor1 != neighbor0)
              candidate += islandSizes[neighbor1 - 2];

            if (neighbor2 > 1 && neighbor2 != neighbor1 && neighbor2 != neighbor0)
              candidate += islandSizes[neighbor2 - 2];

            if (neighbor3 > 1 && neighbor3 != neighbor2 && neighbor3 != neighbor1 && neighbor3 != neighbor0)
              candidate += islandSizes[neighbor3 - 2];

            if (result < candidate)
              result = candidate;
          }
        }
      }

      return result + 1;
    }
  }
}
