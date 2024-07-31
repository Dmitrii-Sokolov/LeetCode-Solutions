namespace Problem283
{

  /// <summary>
  /// 283. Move Zeroes
  /// https://leetcode.com/problems/move-zeroes
  /// 
  /// Difficulty Easy
  /// Acceptance 61.9%
  /// 
  /// Array
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public void MoveZeroes(int[] nums)
    {
      var index = 0;
      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] != 0)
        {
          nums[index] = nums[i];
          index++;
        }
      }

      for (; index < nums.Length; index++)
      {
        nums[index] = 0;
      }
    }
  }
}
