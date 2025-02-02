namespace Problem2130
{

  /// <summary>
  /// 2130. Maximum Twin Sum of a Linked List
  /// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 81.2%
  /// 
  /// Linked List
  /// Two Pointers
  /// Stack
  /// </summary>
  public class Solution
  {
    public int PairSum(ListNode head)
    {
      ListNode reversed = default;
      var slow = head;
      var fast = head;
      while (fast != null)
      {
        var next = slow.next;

        fast = fast.next.next;
        slow.next = reversed;
        reversed = slow;

        slow = next;
      }

      var result = 0;
      while (slow != null)
      {
        var candidate = slow.val + reversed.val;
        if (result < candidate)
          result = candidate;

        slow = slow.next;
        reversed = reversed.next;
      }

      return result;
    }
  }
}
