namespace Problem725
{

  /// <summary>
  /// 725. Split Linked List in Parts
  /// https://leetcode.com/problems/split-linked-list-in-parts
  /// 
  /// Difficulty Medium
  /// Acceptance 66.1%
  /// 
  /// Linked List
  /// </summary>
  public class Solution
  {
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
      var node = head;
      var count = 0;
      while (node != null)
      {
        node = node.next;
        count++;
      }

      var result = new ListNode[k];
      var biggerCount = count % k;
      count /= k;
      node = head;
      for (var i = 0; i < k; i++)
      {
        if (node != null)
        {
          if (biggerCount == 0)
            count--;

          result[i] = node;
          for (var j = 0; j < count; j++)
            node = node.next;

          (node, node.next) = (node.next, null);
          biggerCount--;
        }
      }

      return result;
    }
  }
}
