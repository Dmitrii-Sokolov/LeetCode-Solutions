namespace Problem2095
{

  /// <summary>
  /// 2095. Delete the Middle Node of a Linked List
  /// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 59.5%
  /// 
  /// Linked List
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public ListNode DeleteMiddle(ListNode head)
    {
      if (head.next == null)
        return null;

      var slow = head;
      var fast = head.next;
      while (fast.next != null && fast.next.next != null)
      {
        slow = slow.next;
        fast = fast.next.next;
      }

      slow.next = slow.next.next;

      return head;
    }
  }
}
