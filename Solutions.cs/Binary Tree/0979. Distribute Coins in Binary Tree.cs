namespace Problem979
{

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
  public class Solution
  {
    public int DistributeCoins(TreeNode root)
    {
      Check(root);
      return moves;
    }

    private int moves = 0;

    private int Check(TreeNode node)
    {
      var coins = node.val;
      if (node.left != null)
        coins += Check(node.left);

      if (node.right != null)
        coins += Check(node.right);

      moves += Math.Abs(coins - 1);
      return coins - 1;
    }
  }
}
