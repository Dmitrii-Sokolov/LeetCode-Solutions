namespace Problem1422
{

  /// <summary>
  /// 1422. Maximum Score After Splitting a String
  /// https://leetcode.com/problems/maximum-score-after-splitting-a-string
  /// 
  /// Difficulty Easy
  /// Acceptance 63.0%
  /// 
  /// String
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int MaxScore(string s)
    {
      var zerosCount = 0;
      foreach (var c in s)
      {
        if (c == '0')
          zerosCount++;
      }

      var result = 0;
      var leftZeros = 0;
      for (var i = 0; i < s.Length - 1; i++)
      {
        if (s[i] == '0')
          leftZeros++;

        var score = 2 * leftZeros + s.Length - zerosCount - i - 1;
        if (result < score)
          result = score;
      }

      return result;
    }
  }
}
