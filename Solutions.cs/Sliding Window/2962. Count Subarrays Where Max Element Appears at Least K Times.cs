namespace Problem2962
{

  /// <summary>
  /// 2962. Count Subarrays Where Max Element Appears at Least K Times
  /// https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times
  /// 
  /// Difficulty Medium
  /// Acceptance 59.0%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public long CountSubarrays(int[] nums, int k)
    {
      var len = nums.Length;
      if (k > len)
        return 0;

      long result = 0;
      long left = 0;
      long right = -1;
      var max = 0;

      for (var i = 0; i < len; i++)
        max = Math.Max(nums[i], max);

      while (k > 0 && right < len - 1)
      {
        if (nums[++right] == max)
          k--;
      }

      if (k > 0)
        return 0;

      while (right < len)
      {
        var r = 1;
        while (right + r < len && nums[right + r] != max)
          r++;

        while (nums[left] != max)
          left++;

        result += (left + 1) * r;

        left++;
        right += r;
      }

      return result;
    }
  }
}
