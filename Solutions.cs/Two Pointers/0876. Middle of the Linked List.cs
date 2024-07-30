namespace Problem876
{

  /// <summary>
  /// 876. Middle of the Linked List
  /// https://leetcode.com/problems/middle-of-the-linked-list
  /// 
  /// Difficulty Easy
  /// Acceptance 79.0%
  /// 
  /// Linked List
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public ListNode MiddleNode(ListNode head)
    {
      var pointer0 = head;
      var pointer1 = head;
      while (pointer1.next != null)
      {
        pointer0 = pointer0.next;

        pointer1 = pointer1.next;

        if (pointer1.next != null)
          pointer1 = pointer1.next;
      }

      return pointer0;
    }
  }
}
