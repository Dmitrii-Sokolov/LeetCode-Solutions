namespace Problem1813
{

  /// <summary>
  /// 1813. Sentence Similarity III
  /// https://leetcode.com/problems/sentence-similarity-iii
  /// 
  /// Difficulty Medium
  /// Acceptance 43.9%
  /// 
  /// Array
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
      var words1 = sentence1.Split(' ');
      var words2 = sentence2.Split(' ');

      if (words1.Length == words2.Length)
        return sentence1 == sentence2;

      var minLength = Math.Min(words1.Length, words2.Length);
      var start = 0;
      var end = 1;

      while (start < minLength && words1[start] == words2[start])
        start++;

      while (end <= minLength && words1[^end] == words2[^end])
        end++;

      return start > minLength - end;
    }
  }
}
