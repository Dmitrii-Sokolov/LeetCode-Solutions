namespace Problem231
{

  /// <summary>
  /// 231. Power of Two
  /// https://leetcode.com/problems/power-of-two
  /// 
  /// Difficulty Easy
  /// Acceptance 47.9%
  /// 
  /// Math
  /// Bit Manipulation
  /// Recursion
  /// </summary>
  public class Solution
  {
    public bool IsPowerOfTwo(int n)
    {
      return (1 << (int)Math.Round(Math.Log(n, 2))) == n;
    }
  }
}
