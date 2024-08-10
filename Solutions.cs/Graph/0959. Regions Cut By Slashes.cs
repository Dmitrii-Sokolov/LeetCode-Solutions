namespace Problem959
{

  /// <summary>
  /// 959. Regions Cut By Slashes
  /// https://leetcode.com/problems/regions-cut-by-slashes
  /// 
  /// Difficulty Medium
  /// Acceptance 71.5%
  /// 
  /// Array
  /// Hash Table
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int RegionsBySlashes(string[] grid)
    {
      var size = grid.Length;
      var period = (2 * size) + 1;
      var union = new UnionFind(2 * size * (size + 1));

      for (var x = 0; x < grid.Length; x++)
      {
        var row = grid[x];
        for (var y = 0; y < row.Length; y++)
        {
          var upper = x + (period * y);
          var bottom = upper + period;
          var left = upper + size;
          var right = left + 1;

          switch (row[y])
          {
            case '/':
              union.TryUnite(upper, left);
              union.TryUnite(bottom, right);
              break;

            case '\\':
              union.TryUnite(upper, right);
              union.TryUnite(bottom, left);
              break;

            case ' ':
              union.TryUnite(upper, left);
              union.TryUnite(upper, right);
              union.TryUnite(upper, bottom);
              break;

            default:
              throw new ArgumentException();
          }
        }
      }

      return union.GroupsCount;
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
