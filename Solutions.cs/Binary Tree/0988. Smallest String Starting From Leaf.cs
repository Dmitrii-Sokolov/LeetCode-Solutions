namespace Problem988
{

  /// <summary>
  /// 988. Smallest String Starting From Leaf
  /// https://leetcode.com/problems/smallest-string-starting-from-leaf
  /// 
  /// Difficulty Medium
  /// Acceptance 60.5%
  /// 
  /// String
  /// Backtracking
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public string SmallestFromLeaf(TreeNode root)
    {
      var parents = new Dictionary<TreeNode, TreeNode>();
      var leafs = new List<TreeNode>();
      Check(root);

      void Check(TreeNode node)
      {
        if (node.left != null)
        {
          parents.Add(node.left, node);
          Check(node.left);
        }

        if (node.right != null)
        {
          parents.Add(node.right, node);
          Check(node.right);
        }

        if (node.left == null && node.right == null)
          leafs.Add(node);
      }

      var result = new List<int>();

      while (leafs.All(l => l != null))
      {
        var min = leafs.Min(a => a.val);
        result.Add(min);
        leafs = leafs.Where(l => l.val == min).Select(l => parents.GetValueOrDefault(l)).ToList();
      }

      return string.Concat(result.Select(c => (char)(c + 97)));
    }
  }
}
