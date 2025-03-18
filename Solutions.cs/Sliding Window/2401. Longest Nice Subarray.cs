namespace Problem2401
{

  /// <summary>
  /// 2401. Longest Nice Subarray
  /// https://leetcode.com/problems/longest-nice-subarray
  /// 
  /// Difficulty Medium
  /// Acceptance 57.6%
  /// 
  /// Array
  /// Bit Manipulation
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int LongestNiceSubarray(int[] numbers)
    {
      var left = 0;
      var right = 0;
      var bits = 0;
      var result = 1;
      while (right < numbers.Length)
      {
        if ((bits & numbers[right]) == 0)
        {
          bits ^= numbers[right++];

          if (result < right - left)
            result = right - left;
        }
        else
        {
          bits ^= numbers[left++];
        }
      }

      return result;
    }
  }
}
