namespace Problem2864
{

  /// <summary>
  /// 2864. Maximum Odd Binary Number
  /// https://leetcode.com/problems/maximum-odd-binary-number
  /// 
  /// Difficulty Easy
  /// Acceptance 83.2%
  /// 
  /// Math
  /// String
  /// Greedy
  /// </summary>
  public class Solution
  {
    public string MaximumOddBinaryNumber(string s)
    {
      var zeros = 0;
      var ones = 0;

      foreach (var ch in s)
      {
        if (ch == '0')
          zeros++;

        if (ch == '1')
          ones++;
      }

      return new string('1', ones - 1) + new string('0', zeros) + "1";
    }
  }
}
