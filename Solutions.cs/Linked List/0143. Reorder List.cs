namespace Problem143
{

  /// <summary>
  /// 143. Reorder List
  /// https://leetcode.com/problems/reorder-list
  /// 
  /// Difficulty Medium
  /// Acceptance 59.5%
  /// 
  /// Linked List
  /// Two Pointers
  /// Stack
  /// Recursion
  /// </summary>
  public class Solution
  {
    public void ReorderList(ListNode head)
    {
      var count = 0;
      for (var node = head; node != null; node = node.next)
        count++;

      var links = new ListNode[count];

      var i = 0;
      for (var node = head; node != null; node = node.next)
        links[i++] = node;

      var median = count / 2;
      for (i = 0; i < count; i++)
        links[i].next = i < median
            ? links[count - i - 1]
            : i > median
                ? links[count - i]
                : null;
    }
  }
}
