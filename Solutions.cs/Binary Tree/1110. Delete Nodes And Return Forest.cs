namespace Problem1110
{

  /// <summary>
  /// 1110. Delete Nodes And Return Forest
  /// https://leetcode.com/problems/delete-nodes-and-return-forest
  /// 
  /// Difficulty Medium
  /// Acceptance 72.4%
  /// 
  /// Array
  /// Hash Table
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
      HashSet = new HashSet<int>(to_delete);

      Check(root);

      return Result;
    }

    private HashSet<int> HashSet;
    private List<TreeNode> Result = new();

    private TreeNode Check(TreeNode node, bool include = true)
    {
      if (node == null)
      {
        return null;
      }
      else
      {
        var contains = HashSet.Contains(node.val);

        node.left = Check(node.left, contains);
        node.right = Check(node.right, contains);

        if (include && !contains)
          Result.Add(node);

        return contains ? null : node;
      }
    }
  }
}
