namespace Problem2641
{

  /// <summary>
  /// 2641. Cousins in Binary Tree II
  /// https://leetcode.com/problems/cousins-in-binary-tree-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 71.8%
  /// 
  /// Hash Table
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
      root.val = 0;
      var level = new Queue<TreeNode>();
      level.Enqueue(root);
      while (level.Count > 0)
      {
        var rowSum = 0;
        var count = level.Count;

        for (var i = 0; i < count; i++)
        {
          var node = level.Dequeue();
          var childSum = 0;

          if (node.right != null)
          {
            childSum += node.right.val;
            level.Enqueue(node.right);
          }

          if (node.left != null)
          {
            childSum += node.left.val;
            level.Enqueue(node.left);
          }

          if (node.right != null)
            node.right.val = childSum;

          if (node.left != null)
            node.left.val = childSum;

          rowSum += childSum;
        }

        count = level.Count;
        for (var i = 0; i < count; i++)
        {
          var node = level.Dequeue();
          node.val = rowSum - node.val;
          level.Enqueue(node);
        }
      }

      return root;
    }
  }
}
