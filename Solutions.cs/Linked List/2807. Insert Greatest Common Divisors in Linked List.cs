namespace Problem2807
{

  /// <summary>
  /// 2807. Insert Greatest Common Divisors in Linked List
  /// https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 91.0%
  /// 
  /// Linked List
  /// Math
  /// Number Theory
  /// </summary>
  public class Solution
  {
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
      var node = head;
      var previous = node.val;
      node = node.next;

      while (node != null)
      {
        var current = node.val;
        node.val = GetGCD(previous, current);
        previous = current;
        node.next = new ListNode(current, node.next);
        node = node.next.next;
      }

      return head;
    }

    private int GetGCD(int min, int max)
    {
      if (min > max)
        (min, max) = (max, min);

      while (min > 0)
      {
        max %= min;
        (min, max) = (max, min);
      }

      return max;
    }
  }
}
