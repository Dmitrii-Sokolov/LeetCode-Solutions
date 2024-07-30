namespace Problem1653
{

  /// <summary>
  /// 1653. Minimum Deletions to Make String Balanced
  /// https://leetcode.com/problems/minimum-deletions-to-make-string-balanced
  /// 
  /// Difficulty Medium
  /// Acceptance 63.0%
  /// 
  /// String
  /// Dynamic Programming
  /// Stack
  /// </summary>
  public class Solution
  {
    public int MinimumDeletions(string s)
    {
      var result = 0;
      var bCount = 0;
      for (var i = 0; i < s.Length; i++)
      {
        if (s[i] == 'b')
        {
          bCount++;
        }
        else
        {
          result = Math.Min(result + 1, bCount);
        }
      }

      return result;
    }
  }
}
