namespace Problem2924
{

  /// <summary>
  /// 2924. Find Champion II
  /// https://leetcode.com/problems/find-champion-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 65.7%
  /// 
  /// Graph
  /// </summary>
  public class Solution
  {
    public int FindChampion(int n, int[][] edges)
    {
      var candidates = Enumerable.Range(0, n).ToHashSet();

      foreach (var edge in edges)
        candidates.Remove(edge[1]);

      return candidates.Count == 1 ? candidates.First() : -1;
    }
  }
}
