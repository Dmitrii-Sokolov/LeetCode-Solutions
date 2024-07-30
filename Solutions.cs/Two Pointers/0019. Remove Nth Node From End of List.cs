namespace Problem19
{

  /// <summary>
  /// 19. Remove Nth Node From End of List
  /// https://leetcode.com/problems/remove-nth-node-from-end-of-list
  /// 
  /// Difficulty Medium
  /// Acceptance 46.2%
  /// 
  /// Linked List
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
      var prev = head;
      var last = head;

      //for(; n > 1; n --)
      //for(var i = 0; i < n; i ++)
      //    last = last.next;

      while (last.next != null)
      {
        if (n > 0)
        {
          n--;
        }
        else
        {
          prev = prev.next;
        }

        last = last.next;
      }

      if (n > 0)
        return prev.next;

      prev.next = prev.next?.next;

      return head;
    }
  }
}
