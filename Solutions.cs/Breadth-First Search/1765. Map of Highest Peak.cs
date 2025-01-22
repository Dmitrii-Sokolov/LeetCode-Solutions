namespace Problem1765
{

  /// <summary>
  /// 1765. Map of Highest Peak
  /// https://leetcode.com/problems/map-of-highest-peak
  /// 
  /// Difficulty Medium
  /// Acceptance 69.7%
  /// 
  /// Array
  /// Breadth-First Search
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[][] HighestPeak(int[][] isWater)
    {
      var queue = new Queue<(int x, int y)>();
      var result = new int[isWater.Length][];
      for (var x = 0; x < isWater.Length; x++)
      {
        result[x] = new int[isWater[x].Length];
        for (var y = 0; y < isWater[x].Length; y++)
        {
          if (isWater[x][y] == 1)
          {
            queue.Enqueue((x, y));
            result[x][y] = 0;
          }
          else
          {
            result[x][y] = -1;
          }
        }
      }

      var height = 0;
      while (queue.Count > 0)
      {
        height++;
        var remain = queue.Count;
        while (remain-- > 0)
        {
          var (x, y) = queue.Dequeue();

          if (x > 0 && result[x - 1][y] == -1)
          {
            result[x - 1][y] = height;
            queue.Enqueue((x - 1, y));
          }

          if (x < isWater.Length - 1 && result[x + 1][y] == -1)
          {
            result[x + 1][y] = height;
            queue.Enqueue((x + 1, y));
          }

          if (y > 0 && result[x][y - 1] == -1)
          {
            result[x][y - 1] = height;
            queue.Enqueue((x, y - 1));
          }

          if (y < isWater[0].Length - 1 && result[x][y + 1] == -1)
          {
            result[x][y + 1] = height;
            queue.Enqueue((x, y + 1));
          }
        }
      }

      return result;
    }
  }
}
