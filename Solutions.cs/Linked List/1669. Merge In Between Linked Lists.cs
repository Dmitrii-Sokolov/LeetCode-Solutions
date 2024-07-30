namespace Problem1669
{

  /// <summary>
  /// 1669. Merge In Between Linked Lists
  /// https://leetcode.com/problems/merge-in-between-linked-lists
  /// 
  /// Difficulty Medium
  /// Acceptance 81.6%
  /// 
  /// Linked List
  /// </summary>
  public class Solution
  {
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
      var node = list1;

      a--;
      while (a > 0)
      {
        a--;
        b--;
        node = node.next;
      }

      var next = node.next;
      node.next = list2;
      node = next;

      while (b > 0)
      {
        b--;
        node = node.next;
      }

      while (list2.next != null)
        list2 = list2.next;

      list2.next = node;

      return list1;
    }
  }
}
