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
class Solution
{
  public boolean isAnagram(String s, String t)
  {
    if (s.length() != t.length())
      return false;

    var letters = new int[26];

    for (var i = 0; i < s.length(); i++)
    {
      letters[s.charAt(i) - 'a']++;
    }

    for (var i = 0; i < s.length(); i++)
    {
      letters[t.charAt(i) - 'a']--;

      if (letters[t.charAt(i) - 'a'] < 0)
        return false;
    }

    return true;
  }
}
