namespace Problem1945
{

  /// <summary>
  /// 1945. Sum of Digits of String After Convert
  /// https://leetcode.com/problems/sum-of-digits-of-string-after-convert
  /// 
  /// Difficulty Easy
  /// Acceptance 68.7%
  /// 
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int GetLucky(string s, int k)
    {
      var result = 0;
      foreach (var c in s)
      {
        var number = c - 'a' + 1;
        result += number % 10 + number / 10;
      }

      for (var i = 0; i < k - 1; i++)
      {
        var temp = result;
        result = 0;
        while (temp > 0)
        {
          result += temp % 10;
          temp /= 10;
        }
      }

      return result;
    }
  }
}
