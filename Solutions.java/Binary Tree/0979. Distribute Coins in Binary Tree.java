/// <summary>
/// 979. Distribute Coins in Binary Tree
/// https://leetcode.com/problems/distribute-coins-in-binary-tree
/// 
/// Difficulty Medium
/// Acceptance 77.1%
/// 
/// Tree
/// Depth-First Search
/// Binary Tree
/// </summary>
class Solution {
    public int distributeCoins(TreeNode root) {
        check(root);
        return moves;
    }

    private int moves = 0;

    private int check(TreeNode node) {
        var coins = node.val;
        if (node.left != null) {
            coins += check(node.left);
        }
        if (node.right != null) {
            coins += check(node.right);
        }

        moves += Math.abs(coins - 1);
        return coins - 1;
    }
}
