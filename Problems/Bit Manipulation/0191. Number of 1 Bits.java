namespace Problem191
{

  /// <summary>
  /// 191. Number of 1 Bits
  /// https://leetcode.com/problems/number-of-1-bits/description/
  /// 
  /// Difficulty Easy 71.9%
  /// 
  /// Divide and Conquer
  /// Bit Manipulation
  /// </summary>
  class Solution
  {
    public int hammingWeight(int n)
    {
      var result = 0;

      for (var i = 0; i < 32; i++)
      {
        result += (n & 1);
        n = n >> 1;
      }

      return result;
    }
  }
}
