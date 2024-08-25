/// <summary>
/// 145. Binary Tree Postorder Traversal
/// https://leetcode.com/problems/binary-tree-postorder-traversal
/// 
/// Difficulty Easy
/// Acceptance 72.5%
/// 
/// Stack
/// Tree
/// Depth-First Search
/// Binary Tree
/// </summary>
public class Solution
{
  public IList<int> PostorderTraversal(TreeNode root)
  {
    var result = new List<int>();
    var stack = new Stack<TreeNode>();

    if (root != null)
      stack.Push(root);

    while (stack.TryPop(out var node))
    {
      if (node.left != null)
        stack.Push(node.left);

      if (node.right != null)
        stack.Push(node.right);

      result.Add(node.val);
    }

    result.Reverse();

    return result;
  }
}
