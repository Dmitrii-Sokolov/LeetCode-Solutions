namespace Problem1438
{

  /// <summary>
  /// 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
  /// https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit
  /// 
  /// Difficulty Medium
  /// Acceptance 56.6%
  /// 
  /// Array
  /// Queue
  /// Sliding Window
  /// Heap (Priority Queue)
  /// Ordered Set
  /// Monotonic Queue
  /// </summary>
  public class Solution
  {
    public int LongestSubarray(int[] nums, int limit)
    {
      var right = 0;
      var result = 1;

      while (right < nums.Length - 1)
      {
        var left = right;
        var min = nums[left];
        var max = nums[left];
        while (left > 0)
        {
          left--;
          var newMax = Math.Max(max, nums[left]);
          var newMin = Math.Min(min, nums[left]);

          if (newMax - newMin <= limit)
          {
            min = newMin;
            max = newMax;
          }
          else
          {
            left++;
            break;
          }
        }

        while (true)
        {
          right++;
          max = Math.Max(max, nums[right]);
          min = Math.Min(min, nums[right]);

          if (max - min > limit)
          {
            result = Math.Max(result, right - left);
            break;
          }

          if (right == nums.Length - 1)
          {
            result = Math.Max(result, right - left + 1);
            break;
          }
        }
      }

      return result;
    }
  }
}
