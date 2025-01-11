namespace Problem1400
{

  /// <summary>
  /// 1400. Construct K Palindrome Strings
  /// https://leetcode.com/problems/construct-k-palindrome-strings
  /// 
  /// Difficulty Medium
  /// Acceptance 65.8%
  /// 
  /// Hash Table
  /// String
  /// Greedy
  /// Counting
  /// </summary>
  public class Solution
  {
    public bool CanConstruct(string s, int k)
    {
      if (s.Length < k)
        return false;

      if (k >= 26)
        return true;

      var isOdd = new bool[26];
      foreach (var c in s)
        isOdd[c - 'a'] = !isOdd[c - 'a'];

      var oddCount = 0;
      foreach (var c in isOdd)
      {
        if (c)
          oddCount++;
      }

      return oddCount <= k;
    }
  }
}
