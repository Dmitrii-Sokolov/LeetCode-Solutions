namespace Problem2490
{

  /// <summary>
  /// 2490. Circular Sentence
  /// https://leetcode.com/problems/circular-sentence
  /// 
  /// Difficulty Easy
  /// Acceptance 68.4%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public bool IsCircularSentence(string sentence)
    {
      for (var i = 0; i < sentence.Length; i++)
      {
        if (sentence[i] == ' ' && sentence[i - 1] != sentence[i + 1])
          return false;
      }

      return sentence[0] == sentence[^1];
    }
  }
}
