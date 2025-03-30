namespace Extensions
{
  public class UnionFind
  {
    private readonly int Size;
    private readonly int[] Parents;
    private readonly int[] Heights;

    public int GroupsCount { get; private set; }

    public UnionFind(int size)
    {
      Size = size;
      GroupsCount = size;

      Parents = new int[size];
      Heights = new int[size];

      for (var i = 0; i < size; i++)
        Parents[i] = i;
    }

    public UnionFind(UnionFind other)
    {

      Size = other.Size;
      Parents = [.. other.Parents];
      Heights = [.. other.Parents];
      GroupsCount = other.GroupsCount;
    }

    public bool IsUnited(int node0, int node1)
      => node0 == node1 || FindSubroot(node0) == FindSubroot(node1);

    public bool TryUnite(int parent, int child)
    {
      if (parent == child)
        return false;

      parent = FindSubroot(parent);
      child = FindSubroot(child);

      if (parent == child)
        return false;

      if (Heights[parent] < Heights[child])
        (parent, child) = (child, parent);

      Parents[child] = parent;
      Heights[parent] = Math.Max(Heights[parent], Heights[child] + 1);

      GroupsCount--;

      return true;
    }

    private int FindSubroot(int node)
    {
      while (node != Parents[node])
        node = Parents[node];

      return node;
    }
  }
}
