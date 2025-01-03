namespace Problem1071
{

  /// <summary>
  /// 1071. Greatest Common Divisor of Strings
  /// https://leetcode.com/problems/greatest-common-divisor-of-strings
  /// 
  /// Difficulty Easy
  /// Acceptance 52.3%
  /// 
  /// Math
  /// String
  /// </summary>
  public class Solution
  {
    public string GcdOfStrings(string str1, string str2)
    {
      if (str1 + str2 != str2 + str1)
        return string.Empty;

      var gcd = GetGCD(str1.Length, str2.Length);
      return str1[..gcd];
    }

    private static int GetGCD(int a, int b)
    {
      while (b != 0)
      {
        a %= b;
        (a, b) = (b, a);
      }

      return a;
    }
  }
}
