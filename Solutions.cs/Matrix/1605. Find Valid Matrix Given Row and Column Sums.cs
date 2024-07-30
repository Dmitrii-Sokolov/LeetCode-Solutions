namespace Problem1605
{

  /// <summary>
  /// 1605. Find Valid Matrix Given Row and Column Sums
  /// https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums
  /// 
  /// Difficulty Medium
  /// Acceptance 83.1%
  /// 
  /// Array
  /// Greedy
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
      var height = rowSum.Length;
      var width = colSum.Length;
      var result = new int[height][];
      for (var i = 0; i < result.Length; i++)
        result[i] = new int[width];


      var rows = Enumerable.Range(0, height).Select(i => (i, rowSum[i])).ToList();
      rows.Sort((a, b) => a.Item2.CompareTo(b.Item2));

      var columns = Enumerable.Range(0, width).Select(i => (i, colSum[i])).ToList();
      columns.Sort((a, b) => a.Item2.CompareTo(b.Item2));

      var r = 0;
      var c = 0;
      while (r < height && c < width)
      {
        var min = Math.Min(rows[r].Item2, columns[c].Item2);

        rows[r] = (rows[r].Item1, rows[r].Item2 - min);
        columns[c] = (columns[c].Item1, columns[c].Item2 - min);

        result[rows[r].Item1][columns[c].Item1] = min;

        if (rows[r].Item2 == 0)
          r++;
        if (columns[c].Item2 == 0)
          c++;

      }

      return result;
    }
  }
}
