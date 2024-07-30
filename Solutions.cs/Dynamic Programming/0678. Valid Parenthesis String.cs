namespace Problem678
{

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
  public class Solution
  {
    public bool CheckValidString(string s)
    {
      var left = 0;
      var right = 0;

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
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

        left = Math.Max(left, 0);
      }

      return left <= 0;
    }
  }
}
