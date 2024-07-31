namespace Problem190
{

  /// <summary>
  /// 190. Reverse Bits
  /// https://leetcode.com/problems/reverse-bits
  /// 
  /// Difficulty Easy
  /// Acceptance 59.5%
  /// 
  /// Divide and Conquer
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
#pragma warning disable IDE1006 // Naming Styles
    public uint reverseBits(uint n)
#pragma warning restore IDE1006 // Naming Styles
    {
      var result = 0u;

      for (var i = 0; i < 32; i++)
      {
        result = (result << 1) | (n & 1);
        n >>= 1;
      }

      return result;
    }
  }
}
