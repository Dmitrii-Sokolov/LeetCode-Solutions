namespace Problem234
{

  /// <summary>
  /// 234. Palindrome Linked List
  /// https://leetcode.com/problems/palindrome-linked-list
  /// 
  /// Difficulty Easy
  /// Acceptance 53.8%
  /// 
  /// Linked List
  /// Two Pointers
  /// Stack
  /// Recursion
  /// </summary>
	public class Solution
  {
    public bool IsPalindrome(ListNode head)
    {
      ListNode reversed = null;
      var node = head;

      while (node != null)
      {
        reversed = new ListNode(node.val, reversed);
        node = node.next;
      }

      while (head != null)
      {
        if (reversed.val != head.val)
          return false;

        head = head.next;
        reversed = reversed.next;
      }

      return true;
    }
  }
}
