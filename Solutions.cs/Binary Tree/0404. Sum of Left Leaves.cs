namespace Problem
{

  /// <summary>
  /// 404. Sum of Left Leaves
  /// https://leetcode.com/problems/sum-of-left-leaves
  /// 
  /// Difficulty Easy
  /// Acceptance 60.8%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int SumOfLeftLeaves(TreeNode root)
    {
      Check(root, false);

      return Result;
    }

    private int Result = 0;

    private void Check(TreeNode node, bool isLeft)
    {
      if (isLeft && node.left == null && node.right == null)
        Result += node.val;

      if (node.left != null)
        Check(node.left, true);

      if (node.right != null)
        Check(node.right, false);
    }
  }
}
