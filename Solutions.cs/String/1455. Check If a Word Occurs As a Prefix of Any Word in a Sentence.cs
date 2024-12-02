namespace Problem1455
{

  /// <summary>
  /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
  /// https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence
  /// 
  /// Difficulty Easy
  /// Acceptance 66.4%
  /// 
  /// Two Pointers
  /// String
  /// String Matching
  /// </summary>
  public class Solution
  {
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
      var words = sentence.Split(' ');
      for (var i = 0; i < words.Length; i++)
      {
        var word = words[i];
        if (word.StartsWith(searchWord))
          return i + 1;

      }

      return -1;
    }
  }
}
