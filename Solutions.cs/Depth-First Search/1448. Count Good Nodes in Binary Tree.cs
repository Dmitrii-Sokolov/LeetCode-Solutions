namespace Problem1448
{

  /// <summary>
  /// 1448. Count Good Nodes in Binary Tree
  /// https://leetcode.com/problems/count-good-nodes-in-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 73.3%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int GoodNodes(TreeNode root)
    {
      var count = 0;

      GoodNodes(root, int.MinValue, ref count);

      return count;
    }

    private void GoodNodes(TreeNode root, int maxValue, ref int count)
    {
      if (root == null)
        return;

      if (root.val >= maxValue)
      {
        count++;
        maxValue = root.val;
      }

      GoodNodes(root.left, maxValue, ref count);
      GoodNodes(root.right, maxValue, ref count);
    }
  }
}
