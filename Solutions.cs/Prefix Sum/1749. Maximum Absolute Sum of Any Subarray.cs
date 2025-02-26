namespace Problem1749
{

  /// <summary>
  /// 1749. Maximum Absolute Sum of Any Subarray
  /// https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray
  /// 
  /// Difficulty Medium
  /// Acceptance 66.8%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MaxAbsoluteSum(int[] numbers)
    {
      var result = 0;
      var prefix = 0;
      var max = 0;
      var min = 0;
      foreach (var number in numbers)
      {
        if (min > prefix)
          min = prefix;

        if (max < prefix)
          max = prefix;

        prefix += number;

        var candidate = prefix < 0 ? max - prefix : prefix - min;
        if (result < candidate)
          result = candidate;
      }

      return result;
    }
  }
}
