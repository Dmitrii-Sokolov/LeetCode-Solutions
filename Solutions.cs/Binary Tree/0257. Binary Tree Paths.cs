namespace Problem257
{

  /// <summary>
  /// 257. Binary Tree Paths
  /// https://leetcode.com/problems/binary-tree-paths
  /// 
  /// Difficulty Easy
  /// Acceptance 64.3%
  /// 
  /// String
  /// Backtracking
  /// Tree
  /// Depth-First Search
  /// Binary Tree
  /// </summary>
  public class Solution
  {
    public List<string> BinaryTreePaths(TreeNode root)
    {
      Result = new List<string>();

      Check(new System.Text.StringBuilder(), root);

      return Result;
    }

    private List<string> Result;

    private void Check(System.Text.StringBuilder sb, TreeNode root)
    {
      sb.Append(root.val);

      if (root.left == null && root.right == null)
        Result.Add(sb.ToString());
      else if (root.left != null && root.right == null)
      {
        sb.Append("->");
        Check(sb, root.left);
      }
      else if (root.left == null && root.right != null)
      {
        sb.Append("->");
        Check(sb, root.right);
      }
      else
      {
        sb.Append("->");
        var newSB = new System.Text.StringBuilder(sb.ToString());
        Check(newSB, root.left);
        Check(sb, root.right);
      }
    }
  }
}
