namespace Problem1408
{

  /// <summary>
  /// 1408. String Matching in an Array
  /// https://leetcode.com/problems/string-matching-in-an-array
  /// 
  /// Difficulty Easy
  /// Acceptance 66.3%
  /// 
  /// Array
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public IList<string> StringMatching(string[] words)
    {
      var result = new List<string>(words.Length);
      for (var i = 0; i < words.Length; i++)
      {
        if (IsSubstring(words[i], words))
          result.Add(words[i]);
      }

      return result;
    }

    private static bool IsSubstring(string word, string[] words)
    {
      foreach (var anotherWord in words)
      {
        if (word.Length < anotherWord.Length && anotherWord.Contains(word))
          return true;
      }

      return false;
    }
  }
}
