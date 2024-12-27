namespace Problem1161
{

  /// <summary>
  /// 1161. Maximum Level Sum of a Binary Tree
  /// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 67.2%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public int MaxLevelSum(TreeNode root)
    {
      var sums = new int[10_000];
      var levelsCount = Add(sums, root, 0);
      var maxSumLevel = 0;
      var maxSum = sums[maxSumLevel];
      for (var i = 1; i < levelsCount; i++)
      {
        if (maxSum < sums[i])
        {
          maxSum = sums[i];
          maxSumLevel = i;
        }
      }

      return maxSumLevel + 1;
    }

    private static int Add(int[] sums, TreeNode node, int level)
    {
      if (node == null)
        return level;

      sums[level] += node.val;

      return Math.Max(
        Add(sums, node.left, level + 1),
        Add(sums, node.right, level + 1));
    }

    //public int MaxLevelSum(TreeNode root)
    //{
    //  var maxSum = root.val;
    //  var maxLevel = 1;

    //  var levelNumber = 0;
    //  var level = new Queue<TreeNode>();
    //  level.Enqueue(root);
    //  var nodesCount = 1;

    //  while (nodesCount > 0)
    //  {
    //    levelNumber++;
    //    var sum = 0;
    //    var count = nodesCount;
    //    while (count-- > 0)
    //    {
    //      var node = level.Dequeue();
    //      sum += node.val;

    //      if (node.left != null)
    //        level.Enqueue(node.left);

    //      if (node.right != null)
    //        level.Enqueue(node.right);
    //    }

    //    nodesCount = level.Count;

    //    if (maxSum < sum)
    //    {
    //      maxSum = sum;
    //      maxLevel = levelNumber;
    //    }
    //  }

    //  return maxLevel;
    //}
  }
}
