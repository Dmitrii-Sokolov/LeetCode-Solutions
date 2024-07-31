namespace Problem409
{

  /// <summary>
  /// 409. Longest Palindrome
  /// https://leetcode.com/problems/longest-palindrome
  /// 
  /// Difficulty Easy
  /// Acceptance 55.4%
  /// 
  /// Hash Table
  /// String
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int LongestPalindrome(string s)
    {
      var letters = new int[52];

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        if (c >= 'a')
          letters[c - 'a' + 26]++;
        else
        {
          letters[c - 'A']++;
        }
      }

      var result = 0;
      var middle = false;
      for (var i = 0; i < 52; i++)
      {
        result += letters[i] / 2 * 2;
        middle |= letters[i] % 2 > 0;
      }

      if (middle)
        result++;

      return result;
    }
  }
}
