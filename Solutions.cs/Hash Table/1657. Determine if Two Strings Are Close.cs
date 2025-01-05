namespace Problem1657
{

  /// <summary>
  /// 1657. Determine if Two Strings Are Close
  /// https://leetcode.com/problems/determine-if-two-strings-are-close/description/?envType=study-plan-v2&envId=leetcode-75
  /// 
  /// Difficulty Medium
  /// Acceptance 54.2%
  /// 
  /// Hash Table
  /// String
  /// Sorting
  /// Counting
  /// </summary>
  public class Solution
  {
    public bool CloseStrings(string word1, string word2)
    {
      if (word1.Length != word2.Length)
        return false;

      var counts1 = new int[26];
      var counts2 = new int[26];
      for (var i = 0; i < word1.Length; i++)
      {
        counts1[word1[i] - 'a']++;
        counts2[word2[i] - 'a']++;
      }

      for (var i = 0; i < 26; i++)
      {
        if (counts1[i] == 0 && counts2[i] != 0 || counts1[i] != 0 && counts2[i] == 0)
          return false;
      }

      Array.Sort(counts1);
      Array.Sort(counts2);
      for (var i = 0; i < 26; i++)
      {
        if (counts1[i] != counts2[i])
          return false;
      }

      return true;
    }
  }
}
