namespace Problem2696
{

  /// <summary>
  /// 2696. Minimum String Length After Removing Substrings
  /// https://leetcode.com/problems/minimum-string-length-after-removing-substrings
  /// 
  /// Difficulty Easy
  /// Acceptance 73.5%
  /// 
  /// String
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int MinLength(string s)
    {
      var previous = new Stack<char>();

      foreach (var c in s)
      {
        if (previous.Count == 0)
        {
          previous.Push(c);
        }
        else if (c == 'B' && previous.Peek() == 'A')
        {
          previous.Pop();
        }
        else if (c == 'D' && previous.Peek() == 'C')
        {
          previous.Pop();
        }
        else
        {
          previous.Push(c);
        }
      }

      return previous.Count;
    }
  }
}
