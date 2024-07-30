namespace Problem2192
{
  /// <summary>
  /// 2192. All Ancestors of a Node in a Directed Acyclic Graph
  /// https://leetcode.com/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph
  /// 
  /// Difficulty Medium
  /// Acceptance 62.2%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// Topological Sort
  /// </summary>
  public class Solution
  {
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
      Parents = new List<int>[n];
      Ancestors = new HashSet<int>[n];

      foreach (var edge in edges)
      {
        if (Parents[edge[1]] == null)
          Parents[edge[1]] = new List<int>();

        Parents[edge[1]].Add(edge[0]);
      }

      var result = new List<IList<int>>();
      for (var i = 0; i < n; i++)
      {
        var list = new List<int>();
        list.AddRange(Compute(i));
        list.Sort();
        result.Add(list);
      }

      return result;
    }

    private HashSet<int>[] Ancestors;
    private List<int>[] Parents;

    private HashSet<int> Compute(int i)
    {
      if (Ancestors[i] != null)
        return Ancestors[i];

      Ancestors[i] = new HashSet<int>();

      if (Parents[i] != null)
      {
        foreach (var parent in Parents[i])
        {
          Ancestors[i].Add(parent);
          foreach (var p in Compute(parent))
            Ancestors[i].Add(p);
        }
      }

      return Ancestors[i];
    }
  }
}
