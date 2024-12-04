namespace Problem2825
{

  /// <summary>
  /// 2825. Make String a Subsequence Using Cyclic Increments
  /// https://leetcode.com/problems/make-string-a-subsequence-using-cyclic-increments
  /// 
  /// Difficulty Medium
  /// Acceptance 58.5%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public bool CanMakeSubsequence(string str1, string str2)
    {
      var p1 = 0;
      var p2 = 0;
      while (p1 < str1.Length && p2 < str2.Length)
      {
        var diff = str2[p2] - str1[p1];
        if (diff == 0 || diff == 1 || diff == -25)
          p2++;

        p1++;
      }

      return p2 == str2.Length;
    }
  }
}
