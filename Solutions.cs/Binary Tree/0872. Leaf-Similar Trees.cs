namespace Problem872
{

  /// <summary>
  /// 872. Leaf-Similar Trees
  /// https://leetcode.com/problems/leaf-similar-trees
  /// 
  /// Difficulty Easy
  /// Acceptance 70.1%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public bool LeafSimilar(TreeNode root0, TreeNode root1)
    {
      var stack0 = new Stack<TreeNode>();
      var stack1 = new Stack<TreeNode>();

      stack0.Push(root0);
      stack1.Push(root1);

      while (stack0.Count > 0 && stack1.Count > 0)
      {
        var leaf0 = FindNextLeaf(stack0);
        var leaf1 = FindNextLeaf(stack1);

        if (leaf0.val != leaf1.val)
          return false;
      }

      return stack0.Count == stack1.Count;
    }

    private static TreeNode FindNextLeaf(Stack<TreeNode> stack)
    {
      var leaf = stack.Pop();
      while (leaf.left != null || leaf.right != null)
      {
        if (leaf.right != null)
          stack.Push(leaf.right);

        if (leaf.left != null)
          stack.Push(leaf.left);

        leaf = stack.Pop();
      }

      return leaf;
    }
  }
}
