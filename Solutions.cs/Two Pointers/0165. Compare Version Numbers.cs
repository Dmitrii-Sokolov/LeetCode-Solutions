namespace Problem165
{

  /// <summary>
  /// 165. Compare Version Numbers
  /// https://leetcode.com/problems/compare-version-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 41.1%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public int CompareVersion(string version1, string version2)
    {
      var ver1 = version1.Split('.');
      var ver2 = version2.Split('.');
      var level = 0;

      while (level < ver1.Length || level < ver2.Length)
      {
        var v1 = 0;
        var v2 = 0;

        if (level < ver1.Length)
          v1 = int.Parse(ver1[level]);

        if (level < ver2.Length)
          v2 = int.Parse(ver2[level]);

        if (v1 > v2)
          return 1;

        if (v1 < v2)
          return -1;

        level++;
      }

      return 0;
    }
  }
}
