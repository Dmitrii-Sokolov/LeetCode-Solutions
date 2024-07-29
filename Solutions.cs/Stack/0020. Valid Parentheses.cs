namespace Problem20
{

  /// <summary>
  /// 20. Valid Parentheses
  /// https://leetcode.com/problems/valid-parentheses
  /// 
  /// Difficulty Easy
  /// Acceptance 40.8%
  /// 
  /// String
  /// Stack
  /// </summary>
  public class Solution
  {
    public bool IsValid(string s)
    {
      var check = new Stack<char>();
      if (s.Length % 2 != 0)
        return false;

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        if (c == '(' || c == '{' || c == '[')
        {
          check.Push(c);
        }
        else
        {
          if (check.Count == 0)
            return false;

          var c2 = check.Pop();

          if (c2 == '(' && c != ')')
            return false;

          if (c2 == '{' && c != '}')
            return false;

          if (c2 == '[' && c != ']')
            return false;
        }
      }

      return check.Count == 0;
    }
  }
}
