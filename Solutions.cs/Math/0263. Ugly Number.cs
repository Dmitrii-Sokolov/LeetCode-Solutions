namespace Problem263
{

  /// <summary>
  /// 263. Ugly Number
  /// https://leetcode.com/problems/ugly-number
  /// 
  /// Difficulty Easy
  /// Acceptance 42.0%
  /// 
  /// Math
  /// </summary>
  public class Solution
  {
    public bool IsUgly(int n)
    {
      if (n <= 0)
        return false;

      while (n % 2 == 0)
        n >>= 1;

      while (n % 3 == 0)
        n /= 3;

      while (n % 5 == 0)
        n /= 5;

      return n == 1;
    }
  }
}
