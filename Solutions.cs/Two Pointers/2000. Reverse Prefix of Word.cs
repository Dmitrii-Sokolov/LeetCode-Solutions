namespace Problem2000
{

  /// <summary>
  /// 2000. Reverse Prefix of Word
  /// https://leetcode.com/problems/reverse-prefix-of-word
  /// 
  /// Difficulty Easy
  /// Acceptance 86.3%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public string ReversePrefix(string word, char ch)
    {
      var index = 0;

      for (; index < word.Length; index++)
      {
        if (word[index] == ch)
          break;
      }

      if (index == word.Length)
        return word;

      var result = new System.Text.StringBuilder();

      for (; index >= 0; index--)
        result.Append(word[index]);

      for (index = result.Length; index < word.Length; index++)
        result.Append(word[index]);

      return result.ToString();
    }
  }
}
