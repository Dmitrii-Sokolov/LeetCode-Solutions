namespace Problem80
{

  /// <summary>
  /// 80. Remove Duplicates from Sorted Array II
  /// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 59.4%
  /// 
  /// Array
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public int RemoveDuplicates(int[] nums)
    {
      var n = 0;
      var prev = int.MaxValue;
      var counter = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] != prev)
        {
          nums[n++] = nums[i];
          counter = 0;
          prev = nums[i];
        }
        else if (counter < 1)
        {
          nums[n++] = nums[i];
          counter++;
          prev = nums[i];
        }
      }

      return n;
    }
  }
}
