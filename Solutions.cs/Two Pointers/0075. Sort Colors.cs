namespace Problem75
{

  /// <summary>
  /// 75. Sort Colors
  /// https://leetcode.com/problems/sort-colors
  /// 
  /// Difficulty Medium
  /// Acceptance 64.4%
  /// 
  /// Array
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    public void SortColors(int[] nums)
    {
      var length = nums.Length;
      var left = 0;
      var right = length - 1;

      while (left < length && nums[left] == 0)
      {
        left++;
      }

      while (right >= 0 && nums[right] == 2)
      {
        right--;
      }

      var p = left;

      while (p <= right)
      {
        if (nums[p] == 0)
        {
          nums[p] = nums[left];
          nums[left] = 0;
          left++;
          p++;
        }
        else if (nums[p] == 2)
        {
          nums[p] = nums[right];
          nums[right] = 2;
          right--;
        }
        else
        {
          p++;
        }
      }
    }
  }
}
