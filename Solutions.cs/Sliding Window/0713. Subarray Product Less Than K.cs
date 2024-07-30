namespace Problem713
{

  /// <summary>
  /// 713. Subarray Product Less Than K
  /// https://leetcode.com/problems/subarray-product-less-than-k
  /// 
  /// Difficulty Medium
  /// Acceptance 51.6%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
      if (k <= 1)
        return 0;

      var product = 1;
      var count = 0;
      var left = 0;
      var right = 0;

      while (right < nums.Length)
      {
        product *= nums[right++];

        while (product >= k)
          product /= nums[left++];

        count += right - left;
      }

      return count;
    }
  }
}
