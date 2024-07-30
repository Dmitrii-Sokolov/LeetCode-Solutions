namespace Problem2196
{

  /// <summary>
  /// 2196. Create Binary Tree From Descriptions
  /// https://leetcode.com/problems/create-binary-tree-from-descriptions
  /// 
  /// Difficulty Medium
  /// Acceptance 81.8%
  /// 
  /// Array
  /// Hash Table
  /// Tree
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
      var nodes = new Dictionary<int, TreeNode>();
      var parents = new HashSet<TreeNode>();
      var children = new HashSet<TreeNode>();

      foreach (var item in descriptions)
      {
        var parent = GetNode(nodes, parents, item[0]);
        var child = GetNode(nodes, children, item[1]);

        if (item[2] == 1)
          parent.left = child;
        else
          parent.right = child;
      }

      return parents.Except(children).FirstOrDefault();
    }

    private static TreeNode GetNode(Dictionary<int, TreeNode> nodes, HashSet<TreeNode> roots, int nodeValue)
    {
      if (!nodes.TryGetValue(nodeValue, out var node))
      {
        node = new TreeNode(nodeValue);
        nodes.Add(nodeValue, node);
      }

      roots.Add(node);
      return node;
    }
  }
}
