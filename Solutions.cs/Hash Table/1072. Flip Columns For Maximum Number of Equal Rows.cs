namespace Problem1072
{

  /// <summary>
  /// 1072. Flip Columns For Maximum Number of Equal Rows
  /// https://leetcode.com/problems/flip-columns-for-maximum-number-of-equal-rows
  /// 
  /// Difficulty Medium
  /// Acceptance 71.4%
  /// 
  /// Array
  /// Hash Table
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
      var counts = new Dictionary<string, int>();
      for (var i = 0; i < matrix.Length; i++)
      {
        var builder = new System.Text.StringBuilder();
        for (var j = 1; j < matrix[0].Length; j++)
          builder.Append(matrix[i][0] == 0 ? matrix[i][j] : 1 - matrix[i][j]);

        var key = builder.ToString();
        counts[key] = counts.GetValueOrDefault(key, 0) + 1;
      }

      return counts.Values.Max();
    }
  }
}
