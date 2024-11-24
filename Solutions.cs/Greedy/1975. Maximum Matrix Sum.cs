namespace Problem1975
{

  /// <summary>
  /// 1975. Maximum Matrix Sum
  /// https://leetcode.com/problems/maximum-matrix-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 58.2%
  /// 
  /// Array
  /// Greedy
  /// Matrix
  /// </summary>
  public class Solution
  {
    public long MaxMatrixSum(int[][] matrix)
    {
      var result = 0L;
      var min = int.MaxValue;
      var signs = 0;
      foreach (var row in matrix)
      {
        foreach (var cell in row)
        {
          var value = Math.Abs(cell);
          if (cell < 0)
            signs++;

          result += value;
          if (min > value)
            min = value;
        }
      }

      return signs % 2 == 0
        ? result
        : result - 2 * min;
    }
  }
}
