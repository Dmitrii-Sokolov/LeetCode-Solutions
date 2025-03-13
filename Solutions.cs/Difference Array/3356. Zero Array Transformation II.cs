namespace Problem3356
{

  /// <summary>
  /// 3356. Zero Array Transformation II
  /// https://leetcode.com/problems/zero-array-transformation-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 39.1%
  /// 
  /// Array
  /// Binary Search
  /// Prefix Sum
  /// Difference Array
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public int MinZeroArray(int[] numbers, int[][] queries)
    {
      Span<int> difference = stackalloc int[numbers.Length + 1];
      var numberIndex = 0;
      var queryIndex = 0;
      var prefix = 0;
      while (numberIndex < numbers.Length)
      {
        if (numbers[numberIndex] > prefix)
        {
          if (queryIndex == queries.Length)
            return -1;

          var query = queries[queryIndex++];
          var from = query[0];
          var to = query[1];
          var value = query[2];
          difference[from] += value;
          difference[to + 1] -= value;

          if (from <= numberIndex && numberIndex <= to)
            prefix += value;
        }
        else
        {
          prefix += difference[++numberIndex];
        }
      }

      return queryIndex;
    }
  }
}
