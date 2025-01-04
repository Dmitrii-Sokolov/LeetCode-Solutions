namespace Problem1930
{

  /// <summary>
  /// 1930. Unique Length-3 Palindromic Subsequences
  /// https://leetcode.com/problems/unique-length-3-palindromic-subsequences
  /// 
  /// Difficulty Medium
  /// Acceptance 67.4%
  /// 
  /// Hash Table
  /// String
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int CountPalindromicSubsequence(string s)
    {
      var lastEntry = new int[26];
      var palindromes = new bool[26, 26];
      var presentTwice = new bool[26];
      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i] - 'a';
        if (lastEntry[c] != 0)
        {
          for (var j = lastEntry[c]; j < i; j++)
          {
            var b = s[j] - 'a';
            palindromes[c, b] = true;
          }

          if (presentTwice[c])
            palindromes[c, c] = true;

          presentTwice[c] = true;
        }

        lastEntry[c] = i + 1;
      }

      var result = 0;
      for (var i = 0; i < 26; i++)
      {
        for (var j = 0; j < 26; j++)
        {
          if (palindromes[i, j])
            result++;
        }
      }

      return result;
    }
  }
}
