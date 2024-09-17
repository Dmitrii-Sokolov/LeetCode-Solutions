namespace Problem884
{

  /// <summary>
  /// 884. Uncommon Words from Two Sentences
  /// https://leetcode.com/problems/uncommon-words-from-two-sentences
  /// 
  /// Difficulty Easy
  /// Acceptance 71.6%
  /// 
  /// Hash Table
  /// String
  /// Counting
  /// </summary>
  public class Solution
  {
    public string[] UncommonFromSentences(string sentence0, string sentence1)
    {
      var dictionary = new Dictionary<string, int>();
      foreach (var word in sentence0.Split(' '))
      {
        dictionary[word] = dictionary.TryGetValue(word, out var count)
          ? count + 1
          : 1;
      }

      foreach (var word in sentence1.Split(' '))
      {
        dictionary[word] = dictionary.TryGetValue(word, out var count)
          ? count + 1
          : 1;
      }

      return dictionary.Where(pair => pair.Value == 1).Select(pair => pair.Key).ToArray();
    }
  }
}
