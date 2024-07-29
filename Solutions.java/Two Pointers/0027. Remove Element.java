/// <summary>
/// 27. Remove Element
/// https://leetcode.com/problems/remove-element
/// 
/// Difficulty Easy
/// Acceptance 57.6%
/// 
/// Array
/// Two Pointers
/// </summary>
class Solution
{
  public int removeElement(int[] nums, int val)
  {
    var n = 0;

    for (var i = 0; i < nums.length; i++)
    {
      if (nums[i] != val)
      {
        nums[n++] = nums[i];
      }
    }

    return n;
  }
}
