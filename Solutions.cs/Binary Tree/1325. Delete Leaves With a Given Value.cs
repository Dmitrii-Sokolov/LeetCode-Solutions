namespace Problem1325
{

  /// <summary>
  /// 1325. Delete Leaves With a Given Value
  /// https://leetcode.com/problems/delete-leaves-with-a-given-value
  /// 
  /// Difficulty Medium
  /// Acceptance 77.5%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
      if (root == null)
        return null;

      root.left = RemoveLeafNodes(root.left, target);
      root.right = RemoveLeafNodes(root.right, target);

      if (isLeaf(root) && root.val == target)
        root = null;

      return root;
    }

    private bool isLeaf(TreeNode node)
    {
      return node.left == null & node.right == null;
    }
  }
}
