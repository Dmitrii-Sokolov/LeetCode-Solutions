/// <summary>
/// 58. Length of Last Word
/// https://leetcode.com/problems/length-of-last-word
/// 
/// Difficulty Easy
/// Acceptance 52.9%
/// 
/// String
/// </summary>
class Solution
{
  public int lengthOfLastWord(String s)
  {
    var len = s.length();

    var start = 0;
    while (s.charAt(len - start - 1) == ' ')
      start++;

    var end = start;
    while (len - end - 1 >= 0 && s.charAt(len - end - 1) != ' ')
      end++;

    return end - start;
  }
}
