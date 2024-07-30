namespace Problem136
{

  /// <summary>
  /// 136. Single Number
  /// https://leetcode.com/problems/single-number
  /// 
  /// Difficulty Easy
  /// Acceptance 73.6%
  /// 
  /// Array
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int SingleNumber(int[] nums)
    {
      var result = 0;

      foreach (var n in nums)
      {
        result ^= n;
      }

      return result;
    }
  }
}
