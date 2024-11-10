namespace Problem3097
{

  /// <summary>
  /// 3097. Shortest Subarray With OR at Least K II
  /// https://leetcode.com/problems/shortest-subarray-with-or-at-least-k-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 40.3%
  /// 
  /// Array
  /// Bit Manipulation
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MinimumSubarrayLength(int[] nums, int k)
    {
      if (k == 0)
        return 1;

      var result = int.MaxValue;
      var start = 0;
      while (start < nums.Length)
      {
        var window = 0;
        var end = start;
        while (window < k && end < nums.Length)
        {
          window |= nums[end];
          end++;
        }

        if (window < k)
          break;

        start = end;
        window = 0;
        while (window < k && start > 0)
        {
          start--;
          window |= nums[start];
        }

        if (window < k)
          break;

        if (end - start < result)
          result = end - start;

        start++;
      }

      return result == int.MaxValue ? -1 : result;
    }
  }
}
