namespace Problem2185
{

  /// <summary>
  /// 2185. Counting Words With a Given Prefix
  /// https://leetcode.com/problems/counting-words-with-a-given-prefix
  /// 
  /// Difficulty Easy
  /// Acceptance 81.8%
  /// 
  /// Array
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public int PrefixCount(string[] words, string prefix)
    {
      var result = 0;
      foreach (var word in words)
      {
        if (word.Length >= prefix.Length && word.StartsWith(prefix))
          result++;
      }

      return result;
    }
  }
}
