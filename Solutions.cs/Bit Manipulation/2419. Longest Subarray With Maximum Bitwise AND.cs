namespace Problem2419
{

  /// <summary>
  /// 2419. Longest Subarray With Maximum Bitwise AND
  /// https://leetcode.com/problems/longest-subarray-with-maximum-bitwise-and
  /// 
  /// Difficulty Medium
  /// Acceptance 56.6%
  /// 
  /// Array
  /// Bit Manipulation
  /// Brainteaser
  /// </summary>
  public class Solution
  {
    public int LongestSubarray(int[] nums)
    {
      var max = nums[0];
      var previous = nums[0];
      var result = 1;
      var currentSequence = 1;

      for (var i = 1; i < nums.Length; i++)
      {
        var current = nums[i];
        if (current > max)
        {
          max = current;
          result = 1;
          currentSequence = 1;
        }
        else if (current == max && previous == max)
        {
          currentSequence++;
          if (currentSequence > result)
            result = currentSequence;
        }
        else
        {
          currentSequence = 1;
        }

        previous = current;
      }

      return result;
    }
  }
}
