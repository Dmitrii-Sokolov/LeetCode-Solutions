namespace Problem977
{

  /// <summary>
  /// 977. Squares of a Sorted Array
  /// https://leetcode.com/problems/squares-of-a-sorted-array
  /// 
  /// Difficulty Easy
  /// Acceptance 72.9%
  /// 
  /// Array
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] SortedSquares(int[] nums)
    {
      for (var i = 0; i < nums.Length; i++)
      {
        nums[i] = nums[i] * nums[i];
      }

      Array.Sort(nums);

      return nums;
    }
  }
}
