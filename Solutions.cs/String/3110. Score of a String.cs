namespace Problem3110
{

  /// <summary>
  /// 3110. Score of a String
  /// https://leetcode.com/problems/score-of-a-string
  /// 
  /// Difficulty Easy
  /// Acceptance 93.4%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public int ScoreOfString(string s)
    {
      var result = 0;
      int prev = s[0];

      for (var i = 1; i < s.Length; i++)
      {
        result += Math.Abs(s[i] - prev);
        prev = s[i];
      }

      return result;
    }
  }
}
