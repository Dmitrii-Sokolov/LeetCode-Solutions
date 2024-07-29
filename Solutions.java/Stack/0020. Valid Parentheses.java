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
/// 
class Solution {
  public boolean isValid(String s) {
      var check = new Stack<Character>();
      if (s.length() % 2 != 0)
          return false;

      for(var i = 0; i < s.length(); i++)
      {
          var c = s.charAt(i);
          if (c == '(' || c == '{' || c == '[')
          {
              check.push(c);
          }
          else
          {
              if (check.size() == 0)
                  return false;

              var c2 = check.pop();

              if (c2 == '(' && c != ')')
                  return false;
                    
              if (c2 == '{' && c != '}')
                  return false;

              if (c2 == '[' && c != ']')
                  return false;
          }
      }

      return check.size() == 0;        
  }
}
