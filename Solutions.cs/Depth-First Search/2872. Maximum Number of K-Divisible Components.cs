namespace Problem2872
{

  /// <summary>
  /// 2872. Maximum Number of K-Divisible Components
  /// https://leetcode.com/problems/maximum-number-of-k-divisible-components
  /// 
  /// Difficulty Hard
  /// Acceptance 64.0%
  /// 
  /// Tree
  /// Depth-First Search
  /// </summary>
  public class Solution
  {
    public int MaxKDivisibleComponents(int n, int[][] edgesRaw, int[] values, int k)
    {
      if (n == 1)
        return 1;

      if (k == 1)
        return n;

      var edges = new List<int>[n];
      var sums = new int[n];
      foreach (var edge in edgesRaw)
      {
        var node0 = edge[0];
        var node1 = edge[1];

        AddEdge(edges, node0, node1);
        AddEdge(edges, node1, node0);
      }

      RemoveParent(edges, 0);
      GetSum(k, edges, sums, values, 0);

      return GetComponentsCount(edges, sums, 0);
    }

    private static void RemoveParent(List<int>[] edges, int node)
    {
      foreach (var child in edges[node])
        RemoveParent(edges, child, node);
    }

    private static void RemoveParent(List<int>[] edges, int node, int parent)
    {
      edges[node].Remove(parent);
      foreach (var child in edges[node])
        RemoveParent(edges, child, node);
    }

    private static void GetSum(int k, List<int>[] edges, int[] sums, int[] values, int node)
    {
      foreach (var child in edges[node])
        GetSum(k, edges, sums, values, child);

      sums[node] = values[node] % k;
      foreach (var child in edges[node])
        sums[node] = (sums[node] + sums[child]) % k;
    }

    private static int GetComponentsCount(List<int>[] edges, int[] sums, int node)
    {
      var components = 0;
      if (sums[node] == 0)
        components++;

      foreach (var child in edges[node])
        components += GetComponentsCount(edges, sums, child);

      return components;
    }

    private static void AddEdge(List<int>[] edges, int node0, int node1)
    {
      if (edges[node0] == null)
        edges[node0] = [];

      edges[node0].Add(node1);
    }
  }
}
