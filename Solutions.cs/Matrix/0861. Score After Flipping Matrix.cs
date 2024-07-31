namespace Problem861
{

  /// <summary>
  /// 861. Score After Flipping Matrix
  /// https://leetcode.com/problems/score-after-flipping-matrix
  /// 
  /// Difficulty Medium
  /// Acceptance 80.4%
  /// 
  /// Array
  /// Greedy
  /// Bit Manipulation
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MatrixScore(int[][] grid)
    {
      var height = grid.Length;
      var width = grid[0].Length;

      var maxRowValue = (1 << width) - 1;
      var rowValues = new int[height];

      for (var k = 0; k < height; k++)
      {
        for (var i = 0; i < width; i++)
        {
          rowValues[k] = (2 * rowValues[k]) + grid[k][i];
        }
      }

      var columnValues = new int[width];
      for (var k = 0; k < height; k++)
      {
        rowValues[k] = Math.Max(rowValues[k], maxRowValue - rowValues[k]);
        var value = rowValues[k];

        for (var i = width - 1; i >= 0; i--)
        {
          columnValues[i] += value % 2;
          value /= 2;
        }
      }

      var result = 0;
      for (var i = 0; i < width; i++)
      {
        columnValues[i] = Math.Max(columnValues[i], height - columnValues[i]);
        result += (1 << (width - 1 - i)) * columnValues[i];
      }

      return result;
    }
  }
}
