namespace Problem1382
{

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
  public class Solution
  {
    public TreeNode BalanceBST(TreeNode root)
    {
      var nums = new List<TreeNode>();

      Collect(nums, root);
      root = Construct(nums);

      return root;
    }

    private void Collect(List<TreeNode> nums, TreeNode node)
    {
      if (node.left != null)
        Collect(nums, node.left);

      nums.Add(node);

      if (node.right != null)
        Collect(nums, node.right);
    }

    private TreeNode Construct(List<TreeNode> nums)
    {
      return Construct(nums, 0, nums.Count - 1);
    }

    private TreeNode Construct(List<TreeNode> nums, int from, int to)
    {
      if (from > to)
        return null;
      else if (from == to)
      {
        var node = nums[from];
        node.left = null;
        node.right = null;
        return node;
      }
      else
      {
        var center = (from + to) / 2;
        var node = nums[center];
        node.left = Construct(nums, from, center - 1);
        node.right = Construct(nums, center + 1, to);
        return node;
      }
    }
  }
}
