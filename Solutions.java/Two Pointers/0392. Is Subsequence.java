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
class Solution
{
  public boolean isSubsequence(String s, String t)
  {
    var slen = s.length();
    var tlen = t.length();

    var sp = 0;
    var tp = 0;

    while (sp < slen && tp < tlen)
    {
      if (s.charAt(sp) == t.charAt(tp))
      {
        sp++;
      }

      tp++;
    }

    return slen == sp;
  }
}
