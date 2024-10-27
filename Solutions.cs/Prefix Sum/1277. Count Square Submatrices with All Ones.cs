namespace Problem1277
{

  /// <summary>
  /// 1277. Count Square Submatrices with All Ones
  /// https://leetcode.com/problems/count-square-submatrices-with-all-ones
  /// 
  /// Difficulty Medium
  /// Acceptance 76.0%
  /// 
  /// Array
  /// Dynamic Programming
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int CountSquares(int[][] matrix)
    {
      var width = matrix.Length;
      var height = matrix[0].Length;

      var prefixes = new int[width + 1, height + 1];
      for (var x = 0; x < width + 1; x++)
        prefixes[x, 0] = 0;

      for (var y = 1; y < height + 1; y++)
        prefixes[0, y] = 0;

      for (var x = 1; x < width + 1; x++)
      {
        for (var y = 1; y < height + 1; y++)
          prefixes[x, y] = prefixes[x, y - 1] + prefixes[x - 1, y] - prefixes[x - 1, y - 1] + matrix[x - 1][y - 1];
      }

      var result = 0;
      var maxSize = Math.Min(width, height);
      for (var size = 1; size <= maxSize; size++)
      {
        var desiredArea = size * size;
        for (var x = 0; x <= width - size; x++)
        {
          for (var y = 0; y <= height - size; y++)
          {
            var area = prefixes[x + size, y + size] + prefixes[x, y] - prefixes[x + size, y] - prefixes[x, y + size];
            if (area == desiredArea)
              result++;
          }
        }
      }

      return result;
    }
  }
}
