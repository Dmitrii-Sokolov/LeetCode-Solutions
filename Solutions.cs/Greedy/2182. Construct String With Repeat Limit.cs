namespace Problem2182
{

  /// <summary>
  /// 2182. Construct String With Repeat Limit
  /// https://leetcode.com/problems/construct-string-with-repeat-limit
  /// 
  /// Difficulty Medium
  /// Acceptance 63.8%
  /// 
  /// Hash Table
  /// String
  /// Greedy
  /// Heap (Priority Queue)
  /// Counting
  /// </summary>
  public class Solution
  {
    public string RepeatLimitedString(string s, int repeatLimit)
    {
      var counts = new int[26];
      foreach (var c in s)
        counts[c - 'a']++;

      var result = new System.Text.StringBuilder();
      var pointer = counts.Length - 1;
      while (pointer >= 0)
      {
        if (counts[pointer] == 0)
        {
          pointer--;
          continue;
        }

        var count = Math.Min(counts[pointer], repeatLimit);
        counts[pointer] -= count;
        while (count-- > 0)
          result.Append((char)('a' + pointer));

        if (counts[pointer] == 0)
          continue;

        var separator = pointer - 1;
        while (separator >= 0 && counts[separator] == 0)
          separator--;

        if (separator == -1)
          break;

        result.Append((char)('a' + separator));
        counts[separator] -= 1;
      }

      return result.ToString();
    }
  }
}
