namespace Problem590
{

  /// <summary>
  /// 590. N-ary Tree Postorder Traversal
  /// https://leetcode.com/problems/n-ary-tree-postorder-traversal
  /// 
  /// Difficulty Easy
  /// Acceptance 78.8%
  /// 
  /// Stack
  /// Tree
  /// Depth-First Search
  /// </summary>
  public class Solution
  {
    public IList<int> Postorder(Node root)
    {
      var result = new List<int>();
      var stack = new Stack<Node>();

      if (root != null)
        stack.Push(root);

      while (stack.TryPop(out var node))
      {
        foreach (var child in node.children)
          stack.Push(child);

        result.Add(node.val);
      }

      result.Reverse();

      return result;
    }
  }
}
