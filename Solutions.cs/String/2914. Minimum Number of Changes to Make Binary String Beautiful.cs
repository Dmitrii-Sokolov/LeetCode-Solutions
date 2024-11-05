namespace Problem2914
{

  /// <summary>
  /// 2914. Minimum Number of Changes to Make Binary String Beautiful
  /// https://leetcode.com/problems/minimum-number-of-changes-to-make-binary-string-beautiful
  /// 
  /// Difficulty Medium
  /// Acceptance 71.0%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public int MinChanges(string s)
    {
      var result = 0;
      for (var i = 0; i < s.Length / 2; i++)
      {
        if (s[2 * i] != s[2 * i + 1])
          result++;
      }

      return result;
    }
  }
}
