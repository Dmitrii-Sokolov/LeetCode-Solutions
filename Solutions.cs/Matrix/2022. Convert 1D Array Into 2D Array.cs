namespace Problem2022
{

  /// <summary>
  /// 2022. Convert 1D Array Into 2D Array
  /// https://leetcode.com/problems/convert-1d-array-into-2d-array
  /// 
  /// Difficulty Easy
  /// Acceptance 65.9%
  /// 
  /// Array
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
      if (original.Length != m * n)
        return [];

      var result = new int[m][];
      for (var x = 0; x < m; x++)
      {
        result[x] = new int[n];
        for (var y = 0; y < n; y++)
          result[x][y] = original[x * n + y];
      }

      return result;
    }
  }
}
