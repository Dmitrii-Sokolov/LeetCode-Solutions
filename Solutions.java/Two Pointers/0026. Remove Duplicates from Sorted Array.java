/// <summary>
/// 26. Remove Duplicates from Sorted Array
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array
/// 
/// Difficulty Easy
/// Acceptance 56.9%
/// 
/// Array
/// Two Pointers
/// </summary>
class Solution
{
  public int removeDuplicates(int[] nums)
  {
    var n = 0;
    var prev = Integer.MAX_VALUE;

    for (var i = 0; i < nums.length; i++)
    {
      if (nums[i] != prev)
      {
        nums[n++] = nums[i];
        prev = nums[i];
      }
    }

    return n;
  }
}
