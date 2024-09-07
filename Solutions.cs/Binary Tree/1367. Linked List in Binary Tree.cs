namespace Problem1367
{

  /// <summary>
  /// 1367. Linked List in Binary Tree
  /// https://leetcode.com/problems/linked-list-in-binary-tree
  /// 
  /// Difficulty Medium
  /// Acceptance 46.3%
  /// 
  /// Linked List
  /// LTree
  /// LDepth-First Search
  /// LBreadth-First Search
  /// LBinary Tree
  /// </summary>
  public class Solution
  {
    public bool IsSubPath(ListNode head, TreeNode root)
    {
      return IsPath(head, root) ||
        root.left != null && IsSubPath(head, root.left) ||
        root.right != null && IsSubPath(head, root.right);
    }

    private bool IsPath(ListNode listNode, TreeNode treeNode)
        => listNode == null ||
        treeNode != null &&
        listNode.val == treeNode.val &&
        (IsPath(listNode.next, treeNode.left) || IsPath(listNode.next, treeNode.right));
  }
}
