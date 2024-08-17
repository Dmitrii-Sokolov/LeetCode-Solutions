namespace Problem931
{

  /// <summary>
  /// 931. Minimum Falling Path Sum
  /// https://leetcode.com/problems/minimum-falling-path-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 63.1 %
  /// 
  /// Array
  /// Dynamic Programming
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MinFallingPathSum(int[][] matrix)
    {
      var row = matrix[0];
      for (var rowIndex = 1; rowIndex < matrix.Length; rowIndex++)
      {
        var rowScore = matrix[rowIndex];
        var newRow = new int[rowScore.Length];

        for (var i = 0; i < rowScore.Length; i++)
        {
          var step = row[i];

          if (i < rowScore.Length - 1 && step > row[i + 1])
            step = row[i + 1];

          if (i > 0 && step > row[i - 1])
            step = row[i - 1];

          newRow[i] = rowScore[i] + step;
        }

        row = newRow;
      }

      return row.Min();
    }
  }
}
