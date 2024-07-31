namespace Problem2331
{

  /// <summary>
  /// 2331. Evaluate Boolean Binary Tree
  /// https://leetcode.com/problems/evaluate-boolean-binary-tree
  /// 
  /// Difficulty Easy
  /// Acceptance 82.9%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public bool EvaluateTree(TreeNode root)
      => root.val != 0 && (root.val == 1 || (root.val == 2 ? EvaluateTree(root.left) || EvaluateTree(root.right) : EvaluateTree(root.left) && EvaluateTree(root.right)));
  }
}
