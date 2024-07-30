namespace Problem129
{

  /// <summary>
  /// 129. Sum Root to Leaf Numbers
  /// https://leetcode.com/problems/sum-root-to-leaf-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 66.4%
  /// 
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int SumNumbers(TreeNode root)
    {
      return Calculate(root, 0);
    }

    private int Calculate(TreeNode node, int sum)
    {
      sum = (10 * sum) + node.val;
      if (node.left == null && node.right == null)
        return sum;

      var result = 0;

      if (node.left != null)
        result += Calculate(node.left, sum);

      if (node.right != null)
        result += Calculate(node.right, sum);

      return result;
    }
  }
}
