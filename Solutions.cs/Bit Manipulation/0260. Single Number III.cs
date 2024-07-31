namespace Problem260
{

  /// <summary>
  /// 260. Single Number III
  /// https://leetcode.com/problems/single-number-iii
  /// 
  /// Difficulty Medium
  /// Acceptance 70.8%
  /// 
  /// Array
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int[] SingleNumber(int[] nums)
    {
      var d = 0;
      foreach (var n in nums)
      {
        d ^= n;
      }

      var c = 0;
      for (var i = 0; i < 32; i++)
      {
        c = 1 << i;
        if ((d & c) != 0)
          break;
      }

      var a = 0;
      var b = 0;
      foreach (var n in nums)
      {
        if ((n & c) == 0)
          a ^= n;
        else
        {
          b ^= n;
        }
      }

      return new int[] { a, b };
    }
  }
}
