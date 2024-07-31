namespace Problem896
{

  /// <summary>
  /// 896. Monotonic Array
  /// https://leetcode.com/problems/monotonic-array
  /// 
  /// Difficulty Easy
  /// Acceptance 61.3%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public bool IsMonotonic(int[] nums)
    {
      var up = true;
      var down = true;

      for (var i = 1; i < nums.Length; i++)
      {
        if (nums[i] > nums[i - 1])
          down = false;

        if (nums[i] < nums[i - 1])
          up = false;

        if (down == false && up == false)
          return false;
      }

      return true;
    }
  }
}
