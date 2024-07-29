/// <summary>
/// 3110. Score of a String
/// https://leetcode.com/problems/score-of-a-string
/// 
/// Difficulty Easy
/// Acceptance 93.4%
/// 
/// String
/// </summary>
class Solution
{
  public int scoreOfString(String s)
  {
    var result = 0;
    int prev = s.charAt(0);

    for (var i = 1; i < s.length(); i++)
    {
      result += Math.abs(s.charAt(i) - prev);
      prev = s.charAt(i);
    }

    return result;
  }
}
