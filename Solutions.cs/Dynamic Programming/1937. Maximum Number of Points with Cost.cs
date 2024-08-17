namespace Problem1937
{

  /// <summary>
  /// 1937. Maximum Number of Points with Cost
  /// https://leetcode.com/problems/maximum-number-of-points-with-cost
  /// 
  /// Difficulty Medium
  /// Acceptance 36.8%  
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public long MaxPoints(int[][] points)
    {
      var result = points[0].Select(rowScore => (long)rowScore).ToArray();
      var width = points[0].Length;
      var lefts = new long[width];
      var rights = new long[width];
      for (var rowIndex = 1; rowIndex < points.Length; rowIndex++)
      {
        var row = points[rowIndex];

        var max = 0L;
        for (var i = 0; i < width; i++)
        {
          max--;
          if (result[i] > max)
            max = result[i];

          lefts[i] = max;
        }

        max = 0;
        for (var i = width - 1; i >= 0; i--)
        {
          max--;
          if (result[i] > max)
            max = result[i];

          rights[i] = max;
        }

        for (var i = 0; i < width; i++)
          result[i] = row[i] + Math.Max(lefts[i], rights[i]);
      }

      return result.Max();
    }
  }
}
