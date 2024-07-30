namespace Problem287
{

  /// <summary>
  /// 287. Find the Duplicate Number
  /// https://leetcode.com/problems/find-the-duplicate-number
  /// 
  /// Difficulty Medium
  /// Acceptance 61.3%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int FindDuplicate(int[] nums)
    {
      var slow = 0;
      var fast = 0;

      do
      {
        slow = nums[slow];
        fast = nums[nums[fast]];
      }
      while (slow != fast);

      slow = 0;

      while (slow != fast)
      {
        slow = nums[slow];
        fast = nums[fast];
      }

      return slow;
    }
  }
}
