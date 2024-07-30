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
class Solution
{
    public String minRemoveToMakeValid(String s)
    {
    var stack = new Stack<Character>();
    var pCount = 0;

    for (var i = s.length() - 1; i >= 0 ; i--)
    {
      var c = s.charAt(i);
      if (c == ')')
      {
        pCount++;
        stack.push(c);
      }
      else if (c == '(')
      {
        if (pCount > 0)
        {
          pCount--;
          stack.push(c);
        }
      }
      else
      {
        stack.push(c);
      }
    }    

    var result = new StringBuilder();
    pCount = 0;

    while (!stack.isEmpty())
    {
      var c = stack.pop();

      if (c == '(')
      {
        pCount++;
        result.append(c);
      }
      else if (c == ')')
      {
        if (pCount > 0)
        {
          pCount--;
          result.append(c);
        }
      }
      else
      {
        result.append(c);
      }
    }

    return result.toString();
    }
}
