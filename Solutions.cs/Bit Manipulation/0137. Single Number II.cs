namespace Problem137
{

  /// <summary>
  /// 137. Single Number II
  /// https://leetcode.com/problems/single-number-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 63.4%
  /// 
  /// Array
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int SingleNumber(int[] nums)
    {
      var result0 = 0;
      var result1 = 0;
      foreach (var n in nums)
      {
        result0 = (result0 ^ n) & ~result1;
        result1 = (result1 ^ n) & ~result0;
      }
      return result0;
    }
  }
}
