namespace Problem242
{

  /// <summary>
  /// 242. Valid Anagram
  /// https://leetcode.com/problems/valid-anagram
  /// 
  /// Difficulty Easy
  /// Acceptance 65.0%
  /// 
  /// Hash Table
  /// String
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool IsAnagram(string s, string t)
    {
      if (s.Length != t.Length)
        return false;

      var letters = new int[26];

      for (var i = 0; i < s.Length; i++)
        letters[s[i] - 'a']++;

      for (var i = 0; i < s.Length; i++)
      {
        letters[t[i] - 'a']--;

        if (letters[t[i] - 'a'] < 0)
          return false;
      }

      return true;
    }
  }
}
