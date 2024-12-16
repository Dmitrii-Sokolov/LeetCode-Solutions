#pragma warning disable IDE1006 // Naming Styles
/// <summary>
/// Definition for a Node.
/// </summary>
public class Node
{
  public int val;
  public IList<Node> children;

  public Node() { }

  public Node(int _val)
  {
    val = _val;
  }

  public Node(int _val, IList<Node> _children)
  {
    val = _val;
    children = _children;
  }
}
#pragma warning restore IDE1006 // Naming Styles
