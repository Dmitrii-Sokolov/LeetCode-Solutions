namespace Problem386
{

  /// <summary>
  /// 386. Lexicographical Numbers
  /// https://leetcode.com/problems/lexicographical-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 67.0%
  /// 
  /// Depth-First Search
  /// Trie
  /// </summary>
  public class Solution
  {
    public IList<int> LexicalOrder(int n)
    {
      var result = new List<int>(n);

      for (var i = 1; i < 10; i++)
        ProcessPrefix(result, n, i);

      return result;
    }

    private static void ProcessPrefix(List<int> result, int n, int prefix)
    {
      if (prefix > n)
        return;

      result.Add(prefix);

      for (var i = 0; i < 10; i++)
        ProcessPrefix(result, n, 10 * prefix + i);
    }
  }
}
