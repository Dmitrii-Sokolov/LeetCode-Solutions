namespace Problem1579
{

  /// <summary>
  /// 1579. Remove Max Number of Edges to Keep Graph Fully Traversable
  /// https://leetcode.com/problems/remove-max-number-of-edges-to-keep-graph-fully-traversable
  /// 
  /// Difficulty Hard
  /// Acceptance 71.0%
  /// 
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
      if (edges.Length < n - 1)
        return -1;

      var graphUnion = new UnionFind(n);
      var edges1 = new List<(int A, int B)>();
      var edges2 = new List<(int A, int B)>();
      var lack = n - 1;

      foreach (var edge in edges)
      {
        var type = edge[0];
        if (type == 1)
        {
          edges1.Add((edge[1], edge[2]));
        }
        else if (type == 2)
        {
          edges2.Add((edge[1], edge[2]));
        }
        else
        {
          if (graphUnion.TryUnite(edge[1], edge[2]))
          {
            lack--;

            if (lack == 0)
              return edges.Length - n + 1;
          }
        }
      }

      var graphUnionClone = new UnionFind(graphUnion);
      if (IsBad(graphUnionClone, edges1, lack) ||
        IsBad(graphUnion, edges2, lack))
        return -1;

      return edges.Length - n + 1 - lack;
    }

    private static bool IsBad(UnionFind graphUnion, List<(int A, int B)> edges, int lack)
    {
      if (edges.Count < lack)
        return true;

      foreach (var edge in edges)
      {
        if (graphUnion.TryUnite(edge.A, edge.B))
          lack--;

        if (lack == 0)
          return false;
      }
      return lack > 0;
    }

    private class UnionFind
    {
      private readonly int Size;
      private readonly int[] Parents;
      private readonly int[] ChildrenCount;

      public int Groups { get; private set; }

      public UnionFind(int size)
      {
        Size = size;
        Parents = Enumerable.Range(0, Size).ToArray();
        ChildrenCount = Enumerable.Range(0, Size).Select(i => 1).ToArray();
        Groups = size;
      }

      public UnionFind(UnionFind other)
      {
        Size = other.Size;
        Parents = other.Parents.ToArray();
        ChildrenCount = other.Parents.ToArray();
        Groups = other.Groups;
      }

      public bool TryUnite(int node0, int node1)
      {
        node0--;
        node1--;

        if (node0 == node1)
          return false;

        node0 = FindSubroot(node0);
        node1 = FindSubroot(node1);

        if (node0 == node1)
          return false;

        if (ChildrenCount[node0] < ChildrenCount[node1])
        {
          Parents[node0] = node1;
          ChildrenCount[node1] += ChildrenCount[node0];
        }
        else
        {
          Parents[node1] = node0;
          ChildrenCount[node0] += ChildrenCount[node1];
        }

        Groups--;

        return true;
      }

      private int FindSubroot(int node)
      {
        while (Parents[node] != node)
          node = Parents[node];

        return node;
      }
    }
  }
}
