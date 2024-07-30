namespace Problem1544
{

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
  public class Solution
  {
    public string MakeGood(string s)
    {
      var stack = new Stack<char>();

      for (var i = s.Length - 1; i >= 0; i--)
      {
        var a = s[i];
        if (stack.Count > 0 && Math.Abs(a - stack.Peek()) == 32)
        {
          stack.Pop();
        }
        else
        {
          stack.Push(a);
        }
      }

      return string.Concat(stack);
    }
  }
}
