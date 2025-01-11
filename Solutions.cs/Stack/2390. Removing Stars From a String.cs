namespace Problem2390
{

  /// <summary>
  /// 2390. Removing Stars From a String
  /// https://leetcode.com/problems/removing-stars-from-a-string
  /// 
  /// Difficulty Medium
  /// Acceptance 77.0%
  /// 
  /// String
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string RemoveStars(string s)
    {
      var stack = new List<char>();
      foreach (var c in s)
      {
        if (c == '*')
        {
          stack.RemoveAt(stack.Count - 1);
        }
        else
        {
          stack.Add(c);
        }
      }

      var result = new System.Text.StringBuilder();
      foreach (var c in stack)
        result.Append(c);

      return result.ToString();
    }
  }
}
