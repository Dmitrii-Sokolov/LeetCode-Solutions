/// <summary>
/// 100. Same Tree
/// https://leetcode.com/problems/same-tree
/// 
/// Difficulty Easy
/// Acceptance 62.8%
/// 
/// Tree
/// Depth-First Search
/// Breadth-First Search
/// Binary Tree
/// </summary>
class Solution {
  public boolean isSameTree(TreeNode p, TreeNode q) {
    if (p == null && q == null)
      return true;
    else if (p == null && q != null)
        return false;
    else if (p != null && q == null)
      return false;
    else
      return p.val == q.val &&
        isSameTree(p.left, q.left) &&
        isSameTree(p.right, q.right);
}
