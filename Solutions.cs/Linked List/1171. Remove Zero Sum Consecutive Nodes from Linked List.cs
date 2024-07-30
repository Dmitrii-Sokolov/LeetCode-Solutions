namespace Problem1171
{

  /// <summary>
  /// 1171. Remove Zero Sum Consecutive Nodes from Linked List
  /// https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 52.8%
  /// 
  /// Hash Table
  /// Linked List
  /// </summary>
  public class Solution
  {
    public ListNode RemoveZeroSumSublists(ListNode head)
    {
      var fakeStart = new ListNode(0, head);
      var subStart = fakeStart;

      while (subStart != null)
      {
        var caret = subStart.next;
        var sum = 0;

        while (caret != null)
        {
          sum += caret.val;
          caret = caret.next;

          if (sum == 0)
            subStart.next = caret;
        }

        subStart = subStart.next;
      }

      return fakeStart.next;
    }
  }
}
