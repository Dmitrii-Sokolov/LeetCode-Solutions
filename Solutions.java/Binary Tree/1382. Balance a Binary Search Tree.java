/// <summary>
/// 1382. Balance a Binary Search Tree
/// https://leetcode.com/problems/balance-a-binary-search-tree
/// 
/// Difficulty Medium
/// Acceptance 84.7%
/// 
/// Divide and Conquer
/// Greedy
/// Tree
/// Depth-First Search
/// Binary Search Tree
/// Binary Tree
/// </summary>
class Solution {
    public TreeNode balanceBST(TreeNode root) {
        var nums = new ArrayList<TreeNode>();

        collect(nums, root);
        root = construct(nums);

        return root;
    }

    private void collect(ArrayList<TreeNode> nums, TreeNode node) {
        if (node.left != null) {
            collect(nums, node.left);
        }

        nums.add(node);

        if (node.right != null) {
            collect(nums, node.right);
        }
    }

    private TreeNode construct(ArrayList<TreeNode> nums) {
        return construct(nums, 0, nums.size() - 1);
    }

    private TreeNode construct(ArrayList<TreeNode> nums, int from, int to) {
        if (from > to) {
            return null;
        } else if (from == to) {
            var node = nums.get(from);
            node.left = null;
            node.right = null;
            return node;
        } else {
            var center = (from + to) / 2;
            var node = nums.get(center);
            node.left = construct(nums, from, center - 1);
            node.right = construct(nums, center + 1, to);            
            return node;
        }
    }
}
