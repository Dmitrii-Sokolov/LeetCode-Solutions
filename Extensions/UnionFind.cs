namespace Extensions
{
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
