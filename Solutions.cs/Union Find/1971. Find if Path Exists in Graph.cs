namespace Problem1971
{

  /// <summary>
  /// 1971. Find if Path Exists in Graph
  /// https://leetcode.com/problems/find-if-path-exists-in-graph
  /// 
  /// Difficulty Easy
  /// Acceptance 54.1%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
      if (source == destination)
        return true;

      var union = new UnionFind(n);
      foreach (var edge in edges)
        union.TryUnite(edge[0], edge[1]);

      return union.IsUnited(source, destination);
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

      public bool IsUnited(int node0, int node1)
        => node0 == node1 || FindSubroot(node0) == FindSubroot(node1);

      public bool TryUnite(int node0, int node1)
      {
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
