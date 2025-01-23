namespace Problem1267
{

  /// <summary>
  /// 1267. Count Servers that Communicate
  /// https://leetcode.com/problems/count-servers-that-communicate
  /// 
  /// Difficulty Medium
  /// Acceptance 66.4%
  /// 
  /// Array
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// Counting
  /// </summary>
  public class Solution
  {
    public int CountServers(int[][] gridRaw)
    {
      var width = gridRaw.Length;
      var length = gridRaw[0].Length;

      Span<int> rows = stackalloc int[width];
      Span<int> columns = stackalloc int[length];
      Span<int> grid = stackalloc int[length * width];

      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < length; y++)
        {
          var cell = gridRaw[x][y];
          rows[x] += cell;
          columns[y] += cell;
          grid[x * length + y] = cell;
        }
      }

      var result = 0;
      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < length; y++)
        {
          if (rows[x] > 1 || columns[y] > 1)
            result += grid[x * length + y];
        }
      }

      return result;
    }
  }
}
