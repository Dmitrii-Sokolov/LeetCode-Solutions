namespace Problem1038
{

  /// <summary>
  /// 1038. Binary Search Tree to Greater Sum Tree
  /// https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 88.2%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Search Tree
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode BstToGst(TreeNode root)
    {
      if (root.right != null)
        BstToGst(root.right);

      root.val += sum;
      sum = root.val;

      if (root.left != null)
        BstToGst(root.left);

      return root;
    }

    private int sum = 0;
  }
}
