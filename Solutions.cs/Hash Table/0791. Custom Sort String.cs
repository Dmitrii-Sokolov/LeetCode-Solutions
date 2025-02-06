namespace Problem791
{

  /// <summary>
  /// 791. Custom Sort String
  /// https://leetcode.com/problems/custom-sort-string
  /// 
  /// Difficulty Medium
  /// Acceptance 70.9%
  /// 
  /// Hash Table
  /// String
  /// Sorting
  /// </summary>
  public class Solution
  {
    public string CustomSortString(string order, string s)
    {
      var dic = new Dictionary<char, int>();
      for (var i = 0; i < order.Length; i++)
        dic[order[i]] = i;

      return string.Concat(s.OrderBy(Priority));

      int Priority(char c) => dic.TryGetValue(c, out var i) ? i : -1;
    }
  }
}
