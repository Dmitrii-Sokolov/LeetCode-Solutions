namespace Problem2044
{

  /// <summary>
  /// 2044. Count Number of Maximum Bitwise-OR Subsets
  /// https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets
  /// 
  /// Difficulty Medium
  /// Acceptance 82.6%
  /// 
  /// Array
  /// Backtracking
  /// Bit Manipulation
  /// Enumeration
  /// </summary>
  public class Solution
  {
    public int CountMaxOrSubsets(int[] nums) => Check(nums, nums.Aggregate((a, b) => a | b));

    private static int Check(int[] nums, int max, int position = 0, int current = 0)
      => current == max
        ? 1 << nums.Length - position
        : nums.Length == position
          ? 0
          : Check(nums, max, position + 1, current) + Check(nums, max, position + 1, current | nums[position]);
  }
}
