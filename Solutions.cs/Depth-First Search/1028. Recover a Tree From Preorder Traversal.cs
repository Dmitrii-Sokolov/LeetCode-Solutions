namespace Problem1028
{

  /// <summary>
  /// 1028. Recover a Tree From Preorder Traversal
  /// https://leetcode.com/problems/recover-a-tree-from-preorder-traversal
  /// 
  /// Difficulty Hard
  /// Acceptance 78.9%
  /// 
  /// String
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode RecoverFromPreorder(string traversal)
    {
      var position = 0;

      var root = GetNode(traversal, ref position);
      var levels = new List<TreeNode>();
      levels.Add(root);
      var levelsCount = levels.Count;

      while (position < traversal.Length)
      {
        var level = GetLevel(traversal, ref position);
        var node = GetNode(traversal, ref position);
        if (levelsCount == level)
        {
          levels[level - 1].left = node;
        }
        else
        {
          levels[level - 1].right = node;
        }

        if (levels.Count == level)
        {
          levels.Add(node);
        }
        else
        {
          levels[level] = node;
        }

        levelsCount = level + 1;
      }

      return root;
    }

    private static TreeNode GetNode(string traversal, ref int position)
    {
      var value = GetValue(traversal, ref position);

      return new TreeNode(value);
    }

    private static int GetValue(string traversal, ref int position)
    {
      var value = 0;
      while (position < traversal.Length && traversal[position] != '-')
      {
        value = value * 10 + traversal[position] - '0';
        position++;
      }

      return value;
    }

    private static int GetLevel(string traversal, ref int position)
    {
      var level = 0;
      while (traversal[position] == '-')
      {
        level++;
        position++;
      }

      return level;
    }
  }
}
