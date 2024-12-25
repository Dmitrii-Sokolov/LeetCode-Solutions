namespace Problem515
{

  /// <summary>
  /// 515. Find Largest Value in Each Tree Row
  /// https://leetcode.com/problems/find-largest-value-in-each-tree-row
  /// 
  /// Difficulty Medium
  /// Acceptance 65.8%
  /// 
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public IList<int> LargestValues(TreeNode root) => LargestValues(root, 0, []);

    private static IList<int> LargestValues(TreeNode node, int level, IList<int> result)
    {
      if (node != null)
      {
        if (result.Count == level)
        {
          result.Add(node.val);
        }
        else if (result[level] < node.val)
        {
          result[level] = node.val;
        }

        LargestValues(node.left, level + 1, result);
        LargestValues(node.right, level + 1, result);
      }

      return result;
    }
  }
}
