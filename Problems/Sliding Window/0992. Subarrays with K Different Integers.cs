namespace Problem992
{

  /// <summary>
  /// 992. Subarrays with K Different Integers
  /// https://leetcode.com/problems/subarrays-with-k-different-integers
  /// 
  /// Difficulty Hard 63.8%
  /// 
  /// Array
  /// Hash Table
  /// Sliding Window
  /// Counting
  /// </summary>
  public class Solution
  {
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
      var last = new Dictionary<int, int>();
      var result = 0;

      var left = -1;
      var right = 0;
      var urgent = 0;

      while (right < nums.Length)
      {
        var num = nums[right];
        last[num] = right;

        while (last[nums[urgent]] != urgent)
          urgent++;

        if (last.Count > k)
        {
          left = urgent++;
          last.Remove(nums[left]);

          while (last[nums[urgent]] != urgent)
            urgent++;
        }

        if (last.Count == k)
          result += urgent - left;

        right++;
      }

      return result;
    }
  }
}
