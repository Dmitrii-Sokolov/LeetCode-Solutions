namespace Problem3108
{

  /// <summary>
  /// 3108. Minimum Cost Walk in Weighted Graph
  /// https://leetcode.com/problems/minimum-cost-walk-in-weighted-graph
  /// 
  /// Difficulty Hard
  /// Acceptance 57.3%
  /// 
  /// Array
  /// Bit Manipulation
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
      var unionFind = new UnionFind(n);
      foreach (var edge in edges)
        unionFind.Unite(edge);

      var result = new int[query.Length];
      for (var i = 0; i < query.Length; i++)
        result[i] = unionFind.GetCost(query[i]);

      return result;
    }

    private class UnionFind
    {
      private readonly int[] Parents;
      private readonly int[] Heights;
      private readonly int[] Costs;

      public UnionFind(int size)
      {
        Parents = new int[size];
        Heights = new int[size];
        Costs = new int[size];

        for (var i = 0; i < size; i++)
        {
          Parents[i] = i;
          Costs[i] = ~0;
        }
      }

      public int GetCost(int[] query)
      {
        var node0 = query[0];
        var node1 = query[1];
        var subroot0 = FindSubroot(node0);
        var subroot1 = FindSubroot(node1);
        return subroot0 != subroot1 ? -1 : Costs[subroot0];
      }

      public void Unite(int[] edge)
      {
        var parent = edge[0];
        var child = edge[1];
        var cost = edge[2];

        parent = FindSubroot(parent);
        child = FindSubroot(child);

        if (parent != child)
        {
          if (Heights[parent] < Heights[child])
            (parent, child) = (child, parent);

          Parents[child] = parent;
          Costs[parent] &= cost & Costs[child];
          Heights[parent] = Math.Max(Heights[parent], Heights[child] + 1);
        }
        else
        {
          Costs[parent] &= cost;
        }
      }

      private int FindSubroot(int node)
      {
        while (node != Parents[node])
          node = Parents[node];

        return node;
      }
    }
  }
}
