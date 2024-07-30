namespace Problem2958
{

  /// <summary>
  /// 2958. Length of Longest Subarray With at Most K Frequency
  /// https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency
  /// 
  /// Difficulty Medium
  /// Acceptance 55.8%
  /// 
  /// Array
  /// Hash Table
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MaxSubarrayLength(int[] nums, int k)
    {
      var left = 0;
      var right = 0;
      var max = 0;
      var freq = new Dictionary<int, int>();

      while (right < nums.Length)
      {
        freq[nums[right]] = freq.GetValueOrDefault(nums[right]) + 1;

        while (freq[nums[right]] > k)
          freq[nums[left++]]--;

        right++;
        max = Math.Max(max, right - left);
      }

      return max;
    }
  }
}
