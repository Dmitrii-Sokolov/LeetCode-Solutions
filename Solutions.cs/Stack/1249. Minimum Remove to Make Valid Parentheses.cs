namespace Problem1249
{

  /// <summary>
  /// 1249. Minimum Remove to Make Valid Parentheses
  /// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses
  /// 
  /// Difficulty Medium
  /// Acceptance 69.1%
  /// 
  /// String
  /// Stack
  /// </summary>
  public class Solution
  {
    public string MinRemoveToMakeValid(string s)
    {
      var stack = new Stack<char>();
      var pCount = 0;

      for (var i = s.Length - 1; i >= 0; i--)
      {
        var c = s[i];
        if (c == ')')
        {
          pCount++;
          stack.Push(c);
        }
        else if (c == '(')
        {
          if (pCount > 0)
          {
            pCount--;
            stack.Push(c);
          }
        }
        else
        {
          stack.Push(c);
        }
      }

      var result = new System.Text.StringBuilder();
      pCount = 0;

      while (stack.Count > 0)
      {
        var c = stack.Pop();

        if (c == '(')
        {
          pCount++;
          result.Append(c);
        }
        else if (c == ')')
        {
          if (pCount > 0)
          {
            pCount--;
            result.Append(c);
          }
        }
        else
        {
          result.Append(c);
        }
      }

      return result.ToString();
    }
  }
}
