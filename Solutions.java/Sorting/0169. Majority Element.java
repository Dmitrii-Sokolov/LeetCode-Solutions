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
class Solution
{
  public int majorityElement(int[] nums)
  {
    Arrays.sort(nums);
    if (nums.length % 2 > 0)
    {
      return nums[nums.length / 2];
    }
    else
    {
      var left = nums[nums.length / 2 - 1];
      var right = nums[nums.length / 2];
      if (left == right)
      {
        return left;
      }
      else
      {
        if (nums[nums.length / 2 - 1] == nums[nums.length / 2 - 2])
        {
          return left;
        }
        else
        {
          return right;
        }
      }
    }
  }
}
