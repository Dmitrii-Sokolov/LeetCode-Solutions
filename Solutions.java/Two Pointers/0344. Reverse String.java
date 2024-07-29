/// <summary>
/// 344. Reverse String
/// https://leetcode.com/problems/reverse-string
/// 
/// Difficulty Easy
/// Acceptance 78.8%
/// 
/// Two Pointers
/// String
/// </summary>
class Solution
{
  public void reverseString(char[] s)
  {
    var len = s.length;
    for (var i = 0; i < len / 2; i++)
    {
      var temp = s[i];
      s[i] = s[len - i - 1];
      s[len - i - 1] = temp;
    }
  }
}
