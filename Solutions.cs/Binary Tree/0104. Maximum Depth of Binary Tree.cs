namespace Problem104
{

  /// <summary>
  /// 104. Maximum Depth of Binary Tree
  /// https://leetcode.com/problems/maximum-depth-of-binary-tree
  /// 
  /// Difficulty Easy
  /// Acceptance 76.3%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int MaxDepth(TreeNode node) => node == null ? 0 : Math.Max(MaxDepth(node.right), MaxDepth(node.left)) + 1;
  }
}
