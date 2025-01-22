namespace Problem2661
{

  /// <summary>
  /// 2661. First Completely Painted Row or Column
  /// https://leetcode.com/problems/first-completely-painted-row-or-column
  /// 
  /// Difficulty Medium
  /// Acceptance 58.5%
  /// 
  /// Array
  /// Hash Table
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
      var rows = new int[mat[0].Length];
      var indexes = new int[arr.Length];
      for (var i = 0; i < arr.Length; i++)
        indexes[arr[i] - 1] = i;

      var bestColumn = int.MaxValue;
      for (var i = 0; i < mat.Length; i++)
      {
        var currentColumn = 0;
        for (var j = 0; j < mat[i].Length; j++)
        {
          var index = indexes[mat[i][j] - 1];

          if (currentColumn < index)
            currentColumn = index;

          if (rows[j] < index)
            rows[j] = index;
        }

        if (bestColumn > currentColumn)
          bestColumn = currentColumn;
      }

      var b = rows.Min();
      return bestColumn < b ? bestColumn : b;
    }
  }
}
