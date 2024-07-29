namespace Problem141
{

  /// <summary>
  /// 141. Linked List Cycle
  /// https://leetcode.com/problems/linked-list-cycle
  /// 
  /// Difficulty Easy
  /// Acceptance 50.8%
  /// 
  /// Hash Table
  /// Linked List
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public bool HasCycle(ListNode head)
    {
      while (head != null)
      {
        if (head.val == 1000000)
          return true;

        head.val = 1000000;
        head = head.next;
      }

      return false;
    }
  }
}
