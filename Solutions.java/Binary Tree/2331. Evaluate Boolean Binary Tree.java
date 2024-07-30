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
class Solution {
    public boolean evaluateTree(TreeNode root) {
        if (root.val == 0) {
            return false;
        } else if (root.val == 1) {
            return true;
        } else if (root.val == 2) {
            return evaluateTree(root.left) || evaluateTree(root.right);
        } else {
            return evaluateTree(root.left) && evaluateTree(root.right);
        }
    }
}
