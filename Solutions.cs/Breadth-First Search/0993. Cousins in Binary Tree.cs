namespace Problem993
{

  /// <summary>
  /// 993. Cousins in Binary Tree
  /// https://leetcode.com/problems/cousins-in-binary-tree/description/
  /// 
  /// Difficulty Easy
  /// Acceptance 57.3%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public bool IsCousins(TreeNode root, int x, int y)
    {
      var level = new Queue<TreeNode>();
      level.Enqueue(root);
      while (level.Count > 0)
      {
        var count = level.Count;
        var parentX = -1;
        var parentY = -1;
        while (count-- > 0)
        {
          var node = level.Dequeue();
          if (node != null)
          {
            if (node.left != null && node.left.val == x || node.right != null && node.right.val == x)
              parentX = node.val;

            if (node.left != null && node.left.val == y || node.right != null && node.right.val == y)
              parentY = node.val;

            level.Enqueue(node.left);
            level.Enqueue(node.right);
          }
        }

        if (parentX != -1 && parentY == -1)
          return false;

        if (parentX == -1 && parentY != -1)
          return false;

        if (parentX != -1 && parentY != -1)
          return parentX != parentY;
      }

      return false;
    }
  }
}
