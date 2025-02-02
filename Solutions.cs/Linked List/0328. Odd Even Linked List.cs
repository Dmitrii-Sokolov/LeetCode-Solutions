namespace Problem328
{

  /// <summary>
  /// 328. Odd Even Linked List
  /// https://leetcode.com/problems/odd-even-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 61.8%
  /// 
  /// Linked List
  /// </summary>
  public class Solution
  {
    public ListNode OddEvenList(ListNode head)
    {
      if (head == null || head.next == null || head.next.next == null)
        return head;

      var oddHead = new ListNode(head.val);
      var evenHead = new ListNode(head.next.val);

      var odd = oddHead;
      var even = evenHead;
      var current = head.next.next;
      while (current != null)
      {
        odd.next = new ListNode(current.val);
        odd = odd.next;
        current = current.next;

        if (current == null)
          break;

        even.next = new ListNode(current.val);
        even = even.next;
        current = current.next;
      }

      odd.next = evenHead;

      return oddHead;
    }
  }
}
