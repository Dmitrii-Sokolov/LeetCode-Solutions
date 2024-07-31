namespace Problem2487
{

  /// <summary>
  /// 2487. Remove Nodes From Linked List
  /// https://leetcode.com/problems/remove-nodes-from-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 74.4%
  /// 
  /// Linked List
  /// Stack
  /// Recursion
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public ListNode RemoveNodes(ListNode head)
    {
      var node = head;
      var count = 0;
      while (node != null)
      {
        count++;
        node = node.next;
      }

      var list = new int[count];
      count = 0;
      while (head != null)
      {
        list[count++] = head.val;
        head = head.next;
      }

      var max = 0;
      for (var i = list.Length - 1; i >= 0; i--)
      {
        if (list[i] >= max)
        {
          max = list[i];
          head = new ListNode(max, head);
        }
      }

      return head;
    }
  }
}
