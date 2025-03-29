namespace Problem1358
{

  /// <summary>
  /// 1358. Number of Substrings Containing All Three Characters
  /// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters
  /// 
  /// Difficulty Medium
  /// Acceptance 70.4%
  /// 
  /// Hash Table
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int NumberOfSubstrings(string s)
    {
      var result = 0;
      var min = 0;
      Span<int> lastOccurrences = stackalloc int[3];
      for (var i = 0; i < s.Length; i++)
      {
        if (lastOccurrences[s[i] - 'a'] == min)
        {
          lastOccurrences[s[i] - 'a'] = i + 1;
          min = Math.Min(lastOccurrences[0], Math.Min(lastOccurrences[1], lastOccurrences[2]));
        }
        else
        {
          lastOccurrences[s[i] - 'a'] = i + 1;
        }

        result += min;
      }

      return result;
    }
  }
}
