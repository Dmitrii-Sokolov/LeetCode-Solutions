namespace Problem1768
{

  /// <summary>
  /// 1768. Merge Strings Alternately
  /// https://leetcode.com/problems/merge-strings-alternately
  /// 
  /// Difficulty Easy
  /// Acceptance 80.3%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public string MergeAlternately(string word1, string word2)
    {
      var result = new System.Text.StringBuilder();
      var i1 = 0;
      var i2 = 0;

      while (i1 + i2 < word1.Length + word2.Length)
      {
        if (i1 < word1.Length)
          result.Append(word1[i1++]);

        if (i2 < word2.Length)
          result.Append(word2[i2++]);
      }

      return result.ToString();
    }
  }
}
