namespace Problem1910
{

  /// <summary>
  /// 1910. Remove All Occurrences of a Substring
  /// https://leetcode.com/problems/remove-all-occurrences-of-a-substring
  /// 
  /// Difficulty Medium
  /// Acceptance 77.9%
  /// 
  /// String
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public string RemoveOccurrences(string s, string part)
    {
      while (true)
      {
        var index = s.IndexOf(part, StringComparison.Ordinal);
        if (index == -1)
          break;

        s = s[..index] + s[(index + part.Length)..];
      }

      return s;
    }
  }
}
