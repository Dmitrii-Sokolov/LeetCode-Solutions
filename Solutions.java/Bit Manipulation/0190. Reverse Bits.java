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
  public int reverseBits(int n)
  {
    var result = 0;

    for (var i = 0; i < 32; i++)
    {
      result = (result << 1) | (n & 1);
      n = n >> 1;
    }

    return result;
  }
}
