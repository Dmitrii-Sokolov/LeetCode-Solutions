namespace Problem169
{

  /// <summary>
  /// 169. Majority Element
  /// https://leetcode.com/problems/majority-element
  /// 
  /// Difficulty Easy
  /// Acceptance 65.1%
  /// 
  /// Array
  /// Hash Table
  /// Divide and Conquer
  /// Sorting
  /// Counting
  /// </summary>
  public class Solution
  {
    public int MajorityElement(int[] nums)
    {
      Array.Sort(nums);
      if (nums.Length % 2 > 0)
        return nums[nums.Length / 2];
      else
      {
        var left = nums[(nums.Length / 2) - 1];
        var right = nums[nums.Length / 2];
        if (left == right)
          return left;
        else
        {
          if (nums[(nums.Length / 2) - 1] == nums[(nums.Length / 2) - 2])
            return left;
          else
          {
            return right;
          }
        }
      }
    }
  }
}
