namespace Problem513
{

  /// <summary>
  /// 513. Find Bottom Left Tree Value
  /// https://leetcode.com/problems/find-bottom-left-tree-value
  /// 
  /// Difficulty Medium
  /// Acceptance 71.3%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    private int MaxLevel = -1;
    private int Value;

    public int FindBottomLeftValue(TreeNode root)
    {
      Check(root, 1);

      return Value;
    }

    private void Check(TreeNode node, int level)
    {
      if (level > MaxLevel)
      {
        MaxLevel = level;
        Value = node.val;
      }

      if (node.left != null)
        Check(node.left, level + 1);

      if (node.right != null)
        Check(node.right, level + 1);
    }
  }
}
