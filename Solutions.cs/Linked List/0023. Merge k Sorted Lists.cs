namespace Problem23
{

  /// <summary>
  /// 23. Merge k Sorted Lists
  /// https://leetcode.com/problems/merge-k-sorted-lists
  /// 
  /// Difficulty Hard
  /// Acceptance 53.6%
  /// 
  /// Linked List
  /// Divide and Conquer
  /// Heap (Priority Queue)
  /// Merge Sort
  /// </summary>
  public class Solution
  {
    public ListNode MergeKLists(ListNode[] lists)
    {
      if (lists == null || lists.Length == 0)
        return null;

      if (lists.Length == 1)
        return lists[0];

      var result = new ListNode();
      var current = result;
      var queue = new PriorityQueue<ListNode, int>();
      foreach (var node in lists)
      {
        if (node != null)
          queue.Enqueue(node, node.val);
      }

      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        current.next = new ListNode(node.val);
        current = current.next;
        if (node.next != null)
          queue.Enqueue(node.next, node.next.val);
      }

      return result.next;
    }
  }
}
