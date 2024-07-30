namespace Problem623
{

  /// <summary>
  /// 623. Add One Row to Tree
  /// https://leetcode.com/problems/add-one-row-to-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 64.0%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
      return AddOneRow(root, val, depth, true);
    }

    private TreeNode AddOneRow(TreeNode root, int val, int depth, bool isLeft)
    {
      if (depth == 1)
      {
        return isLeft ? new TreeNode(val, root, null) : new TreeNode(val, null, root);
      }
      else if (root != null)
      {
        root.left = AddOneRow(root.left, val, depth - 1, true);
        root.right = AddOneRow(root.right, val, depth - 1, false);

        return root;
      }
      else
      {
        return null;
      }
    }
  }
}
