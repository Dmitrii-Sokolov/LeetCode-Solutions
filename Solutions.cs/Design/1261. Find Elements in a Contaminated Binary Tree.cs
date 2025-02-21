namespace Problem1261
{

  /// <summary>
  /// 1261. Find Elements in a Contaminated Binary Tree
  /// https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 81.1%
  /// 
  /// Hash Table
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Design
  /// Binary Tree
  /// </summary>
  public class FindElements
  {
    private TreeNode Root;

    public FindElements(TreeNode root) => Root = root;

    public bool Find(int target)
    {
      target++;
      var depth = int.Log2(target);
      var index = target - (1 << depth);
      var node = Root;
      for (var level = depth - 1; level >= 0 && node != null; level--)
      {
        var mask = 1 << level;
        node = (index & mask) > 0 ? node.right : node.left;
        index &= ~mask;
      }

      return node != null;
    }
  }
}
