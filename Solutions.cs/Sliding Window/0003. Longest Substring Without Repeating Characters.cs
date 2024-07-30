namespace Problem3
{

  /// <summary>
  /// 3. Longest Substring Without Repeating Characters
  /// https://leetcode.com/problems/longest-substring-without-repeating-characters
  /// 
  /// Difficulty Medium
  /// Acceptance 35.2%
  /// 
  /// Hash Table
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int LengthOfLongestSubstring(string s)
    {
      var result = 0;
      var start = 0;
      var end = 0;
      var set = new HashSet<char>();

      while (end < s.Length)
      {
        while (end < s.Length && set.Add(s[end]))
        {
          end++;
        }

        result = Math.Max(result, end - start);
        if (end == s.Length)
          return result;

        while (start < end && s[end] != s[start])
        {
          set.Remove(s[start]);
          start++;
        }

        start++;
        end++;
      }

      return result;

    }
  }
}
