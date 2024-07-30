namespace Problem543
{

  /// <summary>
  /// 543. Diameter of Binary Tree
  /// https://leetcode.com/problems/diameter-of-binary-tree
  /// 
  /// Difficulty Easy
  /// Acceptance 61.0%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    private int CurrentMax;

    public int DiameterOfBinaryTree(TreeNode root)
    {
      return Math.Max(GetMaxDepth(root), CurrentMax);
    }

    public int GetMaxDepth(TreeNode node)
    {
      var result = 0;
      if (node.left != null && node.right == null)
      {
        result = GetMaxDepth(node.left) + 1;
      }
      else if (node.left == null && node.right != null)
      {
        result = GetMaxDepth(node.right) + 1;
      }
      else if (node.left != null && node.right != null)
      {
        var d0 = GetMaxDepth(node.left);
        var d1 = GetMaxDepth(node.right);
        CurrentMax = Math.Max(d0 + d1 + 2, CurrentMax);
        result = Math.Max(d0, d1) + 1;
      }

      return result;
    }
  }
}
