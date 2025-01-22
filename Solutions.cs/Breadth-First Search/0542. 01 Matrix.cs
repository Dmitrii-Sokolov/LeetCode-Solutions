namespace Problem542
{

  /// <summary>
  /// 542. 01 Matrix
  /// https://leetcode.com/problems/01-matrix
  /// 
  /// Difficulty Medium
  /// Acceptance 50.3%
  /// 
  /// Array
  /// Dynamic Programming
  /// Breadth-First Search
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[][] UpdateMatrix(int[][] matrix)
    {
      var queue = new Queue<(int x, int y)>();
      var result = new int[matrix.Length][];
      for (var x = 0; x < matrix.Length; x++)
      {
        result[x] = new int[matrix[x].Length];
        for (var y = 0; y < matrix[x].Length; y++)
        {
          if (matrix[x][y] == 0)
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

          if (x < matrix.Length - 1 && result[x + 1][y] == -1)
          {
            result[x + 1][y] = height;
            queue.Enqueue((x + 1, y));
          }

          if (y > 0 && result[x][y - 1] == -1)
          {
            result[x][y - 1] = height;
            queue.Enqueue((x, y - 1));
          }

          if (y < matrix[0].Length - 1 && result[x][y + 1] == -1)
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
