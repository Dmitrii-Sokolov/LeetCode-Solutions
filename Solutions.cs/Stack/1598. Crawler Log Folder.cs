namespace Problem1598
{

  /// <summary>
  /// 1598. Crawler Log Folder
  /// https://leetcode.com/problems/crawler-log-folder
  /// 
  /// Difficulty Easy
  /// Acceptance 71.8%
  /// 
  /// Array
  /// String
  /// Stack
  /// </summary>
  public class Solution
  {
    public int MinOperations(string[] logs)
    {
      var level = 0;

      foreach (var c in logs)
      {
        if (c[0] != '.')
        {
          level++;
        }
        else if (c[1] == '.' && level > 0)
        {
          level--;
        }
      }

      return level;
    }
  }
}
