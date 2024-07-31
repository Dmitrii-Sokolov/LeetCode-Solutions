namespace Problem2486
{

  /// <summary>
  /// 2486. Append Characters to String to Make Subsequence
  /// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence
  /// 
  /// Difficulty Medium
  /// Acceptance 73.0%
  /// 
  /// Two Pointers
  /// String
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int AppendCharacters(string s, string t)
    {
      var slen = s.Length;
      var tlen = t.Length;

      var sp = 0;
      var tp = 0;

      while (sp < slen && tp < tlen)
      {
        if (s[sp] == t[tp])
          tp++;

        sp++;
      }

      return tlen - tp;
    }
  }
}
