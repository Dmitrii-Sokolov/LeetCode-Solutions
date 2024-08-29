namespace Problem947
{

  /// <summary>
  /// 947. Most Stones Removed with Same Row or Column
  /// https://leetcode.com/problems/most-stones-removed-with-same-row-or-column
  /// 
  /// Difficulty Medium
  /// Acceptance 59.6%
  /// 
  /// Hash Table
  /// Depth - First Search
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public int RemoveStones(int[][] stones)
    {
      var shift = stones.Length;
      var union = new UnionFind(shift + 20002);
      var columns = new HashSet<int>();
      var rows = new HashSet<int>();

      for (var i = 0; i < stones.Length; i++)
      {
        var stone = stones[i];
        var a = shift + 2 * stone[0];
        var b = shift + 2 * stone[1] + 1;
        union.TryUnite(i, a);
        union.TryUnite(i, b);

        columns.Add(a);
        rows.Add(b);
      }

      return shift + 20002 - union.GroupsCount - rows.Count - columns.Count;
    }

    public class UnionFind
    {
      private readonly int Size;
      private readonly int[] Parents;
      private readonly int[] ChildrenCount;

      public int GroupsCount { get; private set; }

      public UnionFind(int size)
      {
        Size = size;
        Parents = Enumerable.Range(0, Size).ToArray();
        ChildrenCount = Enumerable.Range(0, Size).Select(i => 1).ToArray();
        GroupsCount = size;
      }

      public UnionFind(UnionFind other)
      {
        Size = other.Size;
        Parents = other.Parents.ToArray();
        ChildrenCount = other.Parents.ToArray();
        GroupsCount = other.GroupsCount;
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

        GroupsCount--;

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
