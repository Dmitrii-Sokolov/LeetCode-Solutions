namespace Problem2444
{

  /// <summary>
  /// 2444. Count Subarrays With Fixed Bounds
  /// https://leetcode.com/problems/count-subarrays-with-fixed-bounds
  /// 
  /// Difficulty Hard 67.9%
  /// 
  /// Array
  /// Queue
  /// Sliding Window
  /// Monotonic Queue
  /// </summary>
  public class Solution
  {
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
      var right = 0;
      long result = 0;

      while (right < nums.Length)
      {
        int? lastMin = null;
        int? lastMax = null;
        var left = right;

        while (right < nums.Length)
        {
          if (nums[right] == minK)
            lastMin = right;

          if (nums[right] == maxK)
            lastMax = right;

          if (nums[right] < minK || maxK < nums[right])
          {
            left = right + 1;
            lastMin = null;
            lastMax = null;
          }

          if (lastMin.HasValue && lastMax.HasValue)
            break;

          right++;
        }

        if (!(lastMin.HasValue && lastMax.HasValue))
          break;

        right = Math.Max(lastMin.Value, lastMax.Value);

        while (right < nums.Length && nums[right] >= minK && maxK >= nums[right])
        {
          if (nums[right] == minK)
            lastMin = right;

          if (nums[right] == maxK)
            lastMax = right;

          result += Math.Min(lastMin.Value, lastMax.Value) - left + 1;

          right++;
        }
      }

      return result;
    }
  }
}
