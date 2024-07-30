/// <summary>
/// 1544. Make The String Great
/// https://leetcode.com/problems/make-the-string-great
/// 
/// Difficulty Easy
/// Acceptance 68.3%
/// 
/// String
/// Stack
/// </summary>
class Solution
{
  public String makeGood(String s)
  {
    var stack = new Stack<Character>();
    
    for (var i = 0; i < s.length(); i++)
    //for (var i = s.length() - 1; i >= 0; i--)
    {
      var a = s.charAt(i);
      if (!stack.isEmpty() && Math.abs((int)a - (int)stack.peek()) == 32)
      {
        stack.pop();
      }
      else
      {
        stack.push(a);
      }
    }

    return stack.stream()
      .map(n -> String.valueOf(n))
      .collect(Collectors.joining());
  }
}
