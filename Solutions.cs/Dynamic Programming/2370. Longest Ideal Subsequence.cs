namespace Problem2370
{

  /// <summary>
  /// 2370. Longest Ideal Subsequence
  /// https://leetcode.com/problems/longest-ideal-subsequence
  /// 
  /// Difficulty Medium
  /// Acceptance 47.4%
  /// 
  /// Hash Table
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int LongestIdealString(string s, int k)
    {
      var dp = new int[27];
      var n = s.Length;

      for (var i = n - 1; i >= 0; i--)
      {
        var c = s[i];
        var idx = c - 'a';
        var max = int.MinValue;

        var left = Math.Max(idx - k, 0);
        var right = Math.Min(idx + k, 26);

        for (var j = left; j <= right; j++)
        {
          max = Math.Max(max, dp[j]);
        }

        dp[idx] = max + 1;
      }

      var result = int.MinValue;

      foreach (var ele in dp)
      {
        result = Math.Max(ele, result);
      }

      return result;
    }
  }
}
