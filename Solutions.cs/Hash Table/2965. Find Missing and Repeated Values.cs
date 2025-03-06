namespace Problem2965
{

  /// <summary>
  /// 2965. Find Missing and Repeated Values
  /// https://leetcode.com/problems/find-missing-and-repeated-values
  /// 
  /// Difficulty Easy
  /// Acceptance 81.0%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
      var n = grid.Length;
      var count = n * n;
      var sum = (1 + count) * count / 2;
      Span<bool> presented = stackalloc bool[count];
      var result = new int[2];
      foreach (var row in grid)
      {
        foreach (var number in row)
        {
          if (presented[number - 1])
            result[0] = number;

          presented[number - 1] = true;
          sum -= number;
        }
      }

      result[1] = result[0] + sum;
      return result;
    }
  }
}
