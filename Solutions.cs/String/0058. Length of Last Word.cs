namespace Problem58
{

  /// <summary>
  /// 58. Length of Last Word
  /// https://leetcode.com/problems/length-of-last-word
  /// 
  /// Difficulty Easy
  /// Acceptance 52.9%
  /// 
  /// String
  /// </summary>
  public class Solution
  {
    public int LengthOfLastWord(string s)
    {
      var len = s.Length;

      var start = 0;
      while (s[len - start - 1] == ' ')
        start++;

      var end = start;
      while (len - end - 1 >= 0 && s[len - end - 1] != ' ')
        end++;

      return end - start;
    }
  }
}
