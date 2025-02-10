namespace Problem3174
{

  /// <summary>
  /// 3174. Clear Digits
  /// https://leetcode.com/problems/clear-digits
  /// 
  /// Difficulty Easy
  /// Acceptance 79.5%
  /// 
  /// String
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string ClearDigits(string s)
    {
      var stack = new char[s.Length];
      var length = 0;
      for (var i = 0; i < s.Length; i++)
      {
        if (char.IsDigit(s[i]))
        {
          --length;
        }
        else
        {
          stack[length++] = s[i];
        }
      }

      return string.Create(length, stack, (chars, state) =>
      {
        for (var i = 0; i < length; i++)
          chars[i] = state[i];
      });
    }
  }
}
