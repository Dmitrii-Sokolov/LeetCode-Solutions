namespace Problem1750
{

  /// <summary>
  /// 1750. Minimum Length of String After Deleting Similar Ends
  /// https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends
  /// 
  /// Difficulty Medium
  /// Acceptance 56.0%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public int MinimumLength(string s)
    {
      var first = 0;
      var last = s.Length - 1;

      while (first < last && s[first] == s[last])
      {
        while (first + 1 < s.Length && s[first] == s[first + 1])
          first++;

        while (last - 1 > 0 && s[last] == s[last - 1])
          last--;

        first++;
        last--;
      }

      return Math.Max(last - first + 1, 0);
    }
  }
}
