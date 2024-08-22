namespace Problem476
{

  /// <summary>
  /// 476. Number Complement
  /// https://leetcode.com/problems/number-complement
  /// 
  /// Difficulty Easy
  /// Acceptance 68.6%
  /// 
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int FindComplement(int num)
    {
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
