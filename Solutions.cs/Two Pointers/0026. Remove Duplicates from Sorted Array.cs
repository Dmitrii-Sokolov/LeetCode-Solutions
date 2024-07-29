namespace Problem26
{

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
  public class Solution
  {
    public int RemoveDuplicates(int[] nums)
    {
      if (nums.Length == 1)
        return 1;

      var k = 0;
      var i = 1;
      while (i < nums.Length)
      {
        if (nums[k] != nums[i])
        {
          k++;
          nums[k] = nums[i];
        }

        i++;
      }

      return k + 1;
    }
  }
}
