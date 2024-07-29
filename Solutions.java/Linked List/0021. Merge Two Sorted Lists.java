/// <summary>
/// 21. Merge Two Sorted Lists
/// https://leetcode.com/problems/merge-two-sorted-lists
/// 
/// Difficulty Easy
/// Acceptance 64.9%
/// 
/// Linked List
/// Recursion
/// </summary>
class Solution
{
  public ListNode mergeTwoLists(ListNode list1, ListNode list2)
  {
    ListNode result = null;
    var node = new ListNode(-1, null);
    while (list1 != null || list2 != null)
    {
      if (list1 != null && list2 == null)
      {
        node.next = list1;
        list1 = null;
      }
      else if (list1 == null && list2 != null)
      {
        node.next = list2;
        list2 = null;
      }
      else if (list1.val > list2.val)
      {
        node.next = new ListNode(list2.val, null);
        list2 = list2.next;
      }
      else
      {
        node.next = new ListNode(list1.val, null);
        list1 = list1.next;
      }

      node = node.next;
      if (result == null)
      {
        result = node;
      }
    }

    return result;
  }
}
