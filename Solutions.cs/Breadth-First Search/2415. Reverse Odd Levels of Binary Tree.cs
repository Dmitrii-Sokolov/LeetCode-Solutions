namespace Problem2415
{

  /// <summary>
  /// 2415. Reverse Odd Levels of Binary Tree
  /// https://leetcode.com/problems/reverse-odd-levels-of-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 82.2%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode ReverseOddLevels(TreeNode root)
    {
      Reverse(root.left, root.right, true);
      return root;
    }

    private static void Reverse(TreeNode left, TreeNode right, bool isOdd)
    {
      if (left == null)
        return;

      if (isOdd)
        (left.val, right.val) = (right.val, left.val);

      Reverse(left.left, right.right, !isOdd);
      Reverse(left.right, right.left, !isOdd);
    }
  }
}
