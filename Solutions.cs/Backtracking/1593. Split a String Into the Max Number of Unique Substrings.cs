namespace Problem1593
{

  /// <summary>
  /// 1593. Split a String Into the Max Number of Unique Substrings
  /// https://leetcode.com/problems/split-a-string-into-the-max-number-of-unique-substrings
  /// 
  /// Difficulty Medium
  /// Acceptance 60.6%
  /// 
  /// Hash Table
  /// String
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public int MaxUniqueSplit(string s) => MaxUniqueSplit(s, []);

    private static int MaxUniqueSplit(string s, HashSet<string> substrings, int from = 0)
    {
      var result = 0;
      for (var i = 1; i < s.Length - from + 1; i++)
      {
        var candidate = s.Substring(from, i);
        if (substrings.Add(candidate))
        {
          var check = MaxUniqueSplit(s, substrings, from + i) + 1;
          if (check > result)
            result = check;

          substrings.Remove(candidate);
        }
      }

      return result;
    }
  }
}
