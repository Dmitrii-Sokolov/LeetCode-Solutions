/// <summary>
/// 678. Valid Parenthesis String
/// https://leetcode.com/problems/valid-parenthesis-string
/// 
/// Difficulty Medium
/// Acceptance 38.1%
/// 
/// String
/// Dynamic Programming
/// Stack
/// Greedy
/// </summary>
class Solution
{
  public boolean checkValidString(String s)
  {
    var left = 0;
    var right = 0;

    for (int i = 0; i < s.length(); i++)
    {
      var c = s.charAt(i);
      if (c == '(')
      {
        left++;
        right++;
      }
      else if (c == ')')
      {
        left--;
        right--;
      }
      else
      {
        left--;
        right++;
      }

      if (right < 0)
        return false;
      
      left = Math.max(left, 0);
    }

    return left <= 0;
  }
}
