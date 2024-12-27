namespace Problem102
{

  /// <summary>
  /// 102. Binary Tree Level Order Traversal
  /// https://leetcode.com/problems/binary-tree-level-order-traversal
  /// 
  /// Difficulty Medium
  /// Acceptance 69.2%
  /// 
  /// Tree
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      var result = new List<IList<int>>();

      Add(result, root, 0);

      return result;
    }

    private static void Add(List<IList<int>> result, TreeNode node, int level)
    {
      if (node == null)
        return;

      if (result.Count == level)
        result.Add([]);

      result[level].Add(node.val);

      Add(result, node.left, level + 1);
      Add(result, node.right, level + 1);
    }

    //public IList<IList<int>> LevelOrder(TreeNode root)
    //{
    //  var result = new List<IList<int>>();
    //  var level = new Queue<TreeNode>();
    //  level.Enqueue(root);
    //  while (level.Count > 0)
    //  {
    //    var resultLevel = new List<int>();
    //    var count = level.Count;
    //    while (count-- > 0)
    //    {
    //      var node = level.Dequeue();
    //      if (node != null)
    //      {
    //        resultLevel.Add(node.val);
    //        level.Enqueue(node.left);
    //        level.Enqueue(node.right);
    //      }
    //    }

    //    if (resultLevel.Count > 0)
    //      result.Add(resultLevel);
    //  }

    //  return result;
    //}
  }
}
