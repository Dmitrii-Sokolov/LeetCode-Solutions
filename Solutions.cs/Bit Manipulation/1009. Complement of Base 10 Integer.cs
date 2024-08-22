namespace Problem1009
{

  /// <summary>
  /// 1009. Complement of Base 10 Integer
  /// https://leetcode.com/problems/complement-of-base-10-integer
  /// 
  /// Difficulty Easy
  /// Acceptance 60.8%
  /// 
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int BitwiseComplement(int num)
    {
      if (num == 0)
        return 1;

      var result = 0;
      var bit = 1L;
      while (num >= bit)
      {
        result += ~num & (int)bit;
        bit <<= 1;
      }

      return result;
    }
  }
}
