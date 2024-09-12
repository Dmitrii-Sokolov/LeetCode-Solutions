namespace Problem1684
{

  /// <summary>
  /// 1684. Count the Number of Consistent Strings
  /// https://leetcode.com/problems/count-the-number-of-consistent-strings
  /// 
  /// Difficulty Easy
  /// Acceptance 85.7%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Bit Manipulation
  /// Counting
  /// </summary>
  public class Solution
  {
    public int CountConsistentStrings(string allowedRaw, string[] words)
    {
      var allowed = allowedRaw.ToHashSet();
      return words.Count(w => w.All(allowed.Contains));
    }
  }
}
