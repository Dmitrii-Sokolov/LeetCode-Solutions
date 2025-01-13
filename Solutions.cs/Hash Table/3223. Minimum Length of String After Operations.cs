namespace Problem3223
{

  /// <summary>
  /// 3223. Minimum Length of String After Operations
  /// https://leetcode.com/problems/minimum-length-of-string-after-operations
  /// 
  /// Difficulty Medium
  /// Acceptance 68.5%
  /// 
  /// Hash Table
  /// String
  /// Counting
  /// </summary>
  public class Solution
  {
    public int MinimumLength(string s)
    {
      Span<int> counts = stackalloc int[26];
      foreach (var c in s)
        counts[c - 'a']++;

      var result = 0;
      for (var i = 0; i < 26; i++)
        result += (counts[i] - 1) % 2 + 1;

      return result;
    }
  }
}
