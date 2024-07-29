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
class Solution
{
  public List<String> binaryTreePaths(TreeNode root)
  {
    result = new ArrayList<String>();

    Check(new StringBuilder(), root);

    return result;
  }

  private void Check(StringBuilder sb, TreeNode root)
  {
    sb.append(root.val);

    if (root.left == null && root.right == null)
    {
      result.add(sb.toString());
    }
    else if (root.left != null && root.right == null)
    {
      sb.append("->");
      Check(sb, root.left);
    }
    else if (root.left == null && root.right != null)
    {
      sb.append("->");
      Check(sb, root.right);
    }
    else
    {
      sb.append("->");
      var newSB = new StringBuilder(sb);
      Check(newSB, root.left);
      Check(sb, root.right);
    }
  }

  private ArrayList<String> result;
}
