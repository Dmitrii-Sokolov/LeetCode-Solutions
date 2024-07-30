namespace Problem1929
{

  /// <summary>
  /// 1929. Concatenation of Array
  /// https://leetcode.com/problems/concatenation-of-array
  /// 
  /// Difficulty Easy
  /// Acceptance 90.0%
  /// 
  /// Array
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] GetConcatenation(int[] nums)
    {
      var result = new int[2 * nums.Length];

      for (var i = 0; i < nums.Length; i++)
      {
        result[i] = nums[i];
        result[i + nums.Length] = nums[i];
      }

      return result;
    }
  }
}
