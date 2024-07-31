namespace Problem392
{

  /// <summary>
  /// 392. Is Subsequence
  /// https://leetcode.com/problems/is-subsequence
  /// 
  /// Difficulty Easy
  /// Acceptance 48.1%
  /// 
  /// Two Pointers
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public bool IsSubsequence(string s, string t)
    {
      var slen = s.Length;
      var tlen = t.Length;

      var sp = 0;
      var tp = 0;

      while (sp < slen && tp < tlen)
      {
        if (s[sp] == t[tp])
          sp++;

        tp++;
      }

      return slen == sp;
    }
  }
}
