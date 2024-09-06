namespace Problem3217
{

  /// <summary>
  /// 3217. Delete Nodes From Linked List Present in Array
  /// https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array
  /// 
  /// Difficulty Medium
  /// Acceptance 65.5%
  /// 
  /// Array
  /// Hash Table
  /// Linked List
  /// </summary>
  public class Solution
  {
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
      var hashset = nums.ToHashSet();
      var root = new ListNode(0, head);
      var node = root;

      while (node.next != null)
      {
        if (hashset.Contains(node.next.val))
          node.next = node.next.next;
        else
        {
          node = node.next;
        }
      }

      return root.next;
    }
  }
}
