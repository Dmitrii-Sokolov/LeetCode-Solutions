namespace Problem14
{

  /// <summary>
  /// 14. Longest Common Prefix
  /// https://leetcode.com/problems/longest-common-prefix
  /// 
  /// Difficulty Easy
  /// Acceptance 43.4%
  /// 
  /// String
  /// Trie
  /// </summary>
  public class Solution
  {
    public string LongestCommonPrefix(string[] strs)
    {
      var result = strs[0];
      for (var i = 1; i < strs.Length; i++)
      {
        while (strs[i].IndexOf(result) != 0)
        {
          result = result.Substring(0, result.Length - 1);
        }
      }

      return result;
    }
  }
}
