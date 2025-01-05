namespace Problem1456
{

  /// <summary>
  /// 1456. Maximum Number of Vowels in a Substring of Given Length
  /// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length
  /// 
  /// Difficulty Medium
  /// Acceptance 59.5%
  /// 
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MaxVowels(string s, int k)
    {
      var isVowel = new int[26];
      isVowel['e' - 'a'] = 1;
      isVowel['u' - 'a'] = 1;
      isVowel['i' - 'a'] = 1;
      isVowel['o' - 'a'] = 1;
      isVowel['a' - 'a'] = 1;

      var current = 0;
      for (var i = 0; i < k; i++)
        current += isVowel[s[i] - 'a'];

      var result = current;
      for (var i = k; i < s.Length && result != k; i++)
      {
        current += isVowel[s[i] - 'a'];
        current -= isVowel[s[i - k] - 'a'];

        if (result < current)
          result = current;
      }

      return result;
    }
  }
}
