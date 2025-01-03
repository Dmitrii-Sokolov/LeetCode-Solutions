namespace Problem2270
{

  /// <summary>
  /// 2270. Number of Ways to Split Array
  /// https://leetcode.com/problems/number-of-ways-to-split-array
  /// 
  /// Difficulty Medium
  /// Acceptance 53.1%
  /// 
  /// Array
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int WaysToSplitArray(int[] numbers)
    {
      var forwardSum = 0L;
      for (var i = 0; i < numbers.Length; i++)
        forwardSum += numbers[i];

      var backwardSum = 0L;
      var result = 0;
      for (var i = 0; i < numbers.Length - 1; i++)
      {
        forwardSum -= numbers[i];
        backwardSum += numbers[i];
        if (backwardSum >= forwardSum)
          result++;
      }

      return result;
    }
  }
}
