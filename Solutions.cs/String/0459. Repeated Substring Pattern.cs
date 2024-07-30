namespace Problem459
{

  /// <summary>
  /// 459. Repeated Substring Pattern
  /// https://leetcode.com/problems/repeated-substring-pattern
  /// 
  /// Difficulty Easy
  /// Acceptance 46.2%
  /// 
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public bool RepeatedSubstringPattern(string s)
    {
      for (var sublength = s.Length / 2; sublength > 0; sublength--)
      {
        if (s.Length % sublength == 0 && Check(s, sublength))
          return true;
      }

      return false;
    }

    public bool Check(string s, int sublength)
    {
      var times = s.Length / sublength;
      for (var i = 1; i < times; i++)
      {
        for (var k = 0; k < sublength; k++)
        {
          if (s[k] != s[k + (i * sublength)])
            return false;
        }
      }

      return true;
    }
  }
}
