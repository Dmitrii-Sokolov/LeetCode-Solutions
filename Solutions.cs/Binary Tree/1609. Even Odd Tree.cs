namespace Problem1609
{

  /// <summary>
  /// 1609. Even Odd Tree
  /// https://leetcode.com/problems/even-odd-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 65.8%
  /// 
  /// Tree
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public bool IsEvenOddTree(TreeNode root)
    {
      var next = new List<TreeNode>();
      var current = new List<TreeNode>() { root };
      var divisor = 1;
      var val = 0;

      while (current.Count > 0)
      {
        val = divisor == 0 ? int.MaxValue : 0;

        foreach (var node in current)
        {
          if (node.val % 2 != divisor)
            return false;

          if (val <= node.val && divisor == 0)
            return false;

          if (val >= node.val && divisor == 1)
            return false;

          val = node.val;

          if (node.left != null)
            next.Add(node.left);

          if (node.right != null)
            next.Add(node.right);
        }

        current = next;
        next = new List<TreeNode>();
        divisor = divisor == 0 ? 1 : 0;
      }

      return true;
    }
  }
}
