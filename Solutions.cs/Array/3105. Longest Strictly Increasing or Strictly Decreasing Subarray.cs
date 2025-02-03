namespace Problem3105
{

  /// <summary>
  /// 3105. Longest Strictly Increasing or Strictly Decreasing Subarray
  /// https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray
  /// 
  /// Difficulty Easy
  /// Acceptance 62.2%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public int LongestMonotonicSubarray(int[] numbers)
    {
      var result = 1;
      var currentLength = 1;
      var previous = numbers[0];
      var isIncreasing = true;
      for (var i = 0; i < numbers.Length; i++)
      {
        if (numbers[i] == previous)
        {
          currentLength = 1;
        }
        else if (numbers[i] > previous && isIncreasing || numbers[i] < previous && !isIncreasing)
        {
          currentLength++;
        }
        else if (numbers[i] < previous && isIncreasing || numbers[i] > previous && !isIncreasing)
        {
          isIncreasing = !isIncreasing;
          currentLength = 2;
        }

        previous = numbers[i];
        if (result < currentLength)
          result = currentLength;
      }

      return result;
    }
  }
}
