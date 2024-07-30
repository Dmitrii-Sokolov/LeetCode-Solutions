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
class Solution {
    public TreeNode removeLeafNodes(TreeNode root, int target) {
        if (root == null) {
            return null;
        }

        root.left = removeLeafNodes(root.left, target);
        root.right = removeLeafNodes(root.right, target);

        if (isLeaf(root) && root.val == target) {
            root = null;
        }

        return root;
    }

    private boolean isLeaf(TreeNode node) {
        return node.left == null & node.right == null;
    }
}
