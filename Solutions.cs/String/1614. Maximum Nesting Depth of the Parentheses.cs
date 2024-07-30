namespace Problem1614
{

  /// <summary>
  /// 1614. Maximum Nesting Depth of the Parentheses
  /// https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses
  /// 
  /// Difficulty Easy
  /// Acceptance 83.9%
  /// 
  /// String
  /// Stack
  /// </summary>
  public class Solution
  {
    public int MaxDepth(string s)
    {
      var result = 0;
      var depth = 0;

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];

        if (c == '(')
        {
          depth++;
          result = Math.Max(result, depth);
        }
        else if (c == ')')
        {
          depth--;
        }
      }

      return result;
    }
  }
}
