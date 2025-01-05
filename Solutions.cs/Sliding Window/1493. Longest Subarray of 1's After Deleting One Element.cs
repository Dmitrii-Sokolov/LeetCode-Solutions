namespace Problem1493
{

  /// <summary>
  /// 1493. Longest Subarray of 1's After Deleting One Element
  /// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element
  /// 
  /// Difficulty Medium
  /// Acceptance 68.4%
  /// 
  /// Array
  /// Dynamic Programming
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int LongestSubarray(int[] numbers)
    {
      var right = 0;
      var left = 1;
      var zeroPosition = -1;
      var result = 0;
      while (right < numbers.Length)
      {
        if (numbers[right] == 0)
        {
          if (result < right - left)
            result = right - left;

          left = zeroPosition + 2;
          zeroPosition = right;
        }

        right++;
      }

      if (result < right - left)
        result = right - left;

      return result;
    }
  }
}
