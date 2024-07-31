namespace Problem389
{

  /// <summary>
  /// 389. Find the Difference
  /// https://leetcode.com/problems/find-the-difference
  /// 
  /// Difficulty Easy
  /// Acceptance 59.6%
  /// 
  /// Hash Table
  /// String
  /// Bit Manipulation
  /// Sorting
  /// </summary>
  public class Solution
  {
    public char FindTheDifference(string s, string t)
    {
      var counts = new int[26];

      for (var i = 0; i < s.Length; i++)
      {
        counts[s[i] - 'a']++;
      }

      for (var i = 0; i < t.Length; i++)
      {
        counts[t[i] - 'a']--;

        if (counts[t[i] - 'a'] == -1)
          return t[i];
      }

      return '0';
    }
  }
}
