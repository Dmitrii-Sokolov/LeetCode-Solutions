namespace Problem206
{

  /// <summary>
  /// 206. Reverse Linked List
  /// https://leetcode.com/problems/reverse-linked-list
  /// 
  /// Difficulty Easy
  /// Acceptance 77.2%
  /// 
  /// Linked List
  /// Recursion
  /// </summary>
  public class Solution
  {
    public ListNode ReverseList(ListNode head)
    {
      ListNode newList = default;

      while (head != null)
      {
        newList = new ListNode(head.val, newList);
        head = head.next;
      }

      return newList;
    }
  }
}
