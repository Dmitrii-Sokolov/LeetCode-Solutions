namespace Problem2583
{

  /// <summary>
  /// 2583. Kth Largest Sum in a Binary Tree
  /// https://leetcode.com/problems/kth-largest-sum-in-a-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 52.2%
  /// 
  /// Tree
  /// Breadth-First Search
  /// Sorting
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public long KthLargestLevelSum(TreeNode root, int k)
    {
      var sums = new PriorityQueue<long, long>();
      var level = new Queue<TreeNode>();
      level.Enqueue(root);
      while (level.Count > 0)
      {
        var sum = 0L;
        var count = level.Count;

        for (var i = 0; i < count; i++)
        {
          var node = level.Dequeue();
          sum += node.val;

          if (node.right != null)
            level.Enqueue(node.right);

          if (node.left != null)
            level.Enqueue(node.left);
        }

        sums.Enqueue(sum, -sum);
      }

      if (sums.Count < k)
        return -1;

      while (sums.Count > 0)
      {
        if (--k == 0)
          return sums.Dequeue();
        else
        {
          sums.Dequeue();
        }
      }

      return -2;
    }
  }
}
