namespace Problem1572
{

  /// <summary>
  /// 1572. Matrix Diagonal Sum
  /// https://leetcode.com/problems/matrix-diagonal-sum
  /// 
  /// Difficulty Easy
  /// Acceptance 83.1%
  /// 
  /// Array
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int DiagonalSum(int[][] mat)
    {
      var n = mat.Length;
      var result = n % 2 > 0 ? -mat[n / 2][n / 2] : 0;

      for (var i = 0; i < mat.Length; i++)
        result += mat[i][i];

      for (var i = 0; i < mat.Length; i++)
        result += mat[i][mat.Length - 1 - i];

      return result;
    }
  }
}
