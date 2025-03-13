namespace Problem3355
{

  /// <summary>
  /// 3355. Zero Array Transformation I
  /// https://leetcode.com/problems/zero-array-transformation-i/description/
  /// 
  /// Difficulty Medium
  /// Acceptance 43.3%
  /// 
  /// Array
  /// Prefix Sum
  /// Difference Array
  /// </summary>
  public class Solution
  {
    public bool IsZeroArray(int[] numbers, int[][] queries)
    {
      var difference = new int[numbers.Length + 1];
      foreach (var query in queries)
      {
        difference[query[0]]++;
        difference[query[1] + 1]--;
      }

      var prefix = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        prefix += difference[i];
        if (numbers[i] > prefix)
          return false;
      }

      return true;
    }
  }
}
