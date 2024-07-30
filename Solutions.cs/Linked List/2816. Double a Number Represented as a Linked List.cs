namespace Problem2816
{

  /// <summary>
  /// 2816. Double a Number Represented as a Linked List
  /// https://leetcode.com/problems/double-a-number-represented-as-a-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 61.5%
  /// 
  /// Linked List
  /// Math
  /// Stack
  /// </summary>
  public class Solution
  {
    public ListNode DoubleIt(ListNode head)
    {
      var newHead = new ListNode(0, head);
      var prev = newHead;

      while (head != null)
      {
        var val = head.val * 2;
        prev.val += val / 10;
        head.val = val % 10;
        prev = head;
        head = head.next;
      }

      return newHead.val == 0 ? newHead.next : newHead;
    }
  }
}
