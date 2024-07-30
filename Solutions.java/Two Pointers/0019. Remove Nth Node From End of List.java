/// <summary>
/// 19. Remove Nth Node From End of List
/// https://leetcode.com/problems/remove-nth-node-from-end-of-list
/// 
/// Difficulty Medium
/// Acceptance 46.2%
/// 
/// Linked List
/// Two Pointers
/// </summary>
class Solution {
    public ListNode removeNthFromEnd(ListNode head, int n) {
        ListNode prev = head;
        ListNode last = head;

        while (last.next != null) {
            if (n > 0) {
                n--;
            }
            else {
                prev = prev.next;
            }

            last = last.next;
        }

        if (n > 0) {
            return prev.next;
        }

        prev.next = prev.next == null ? null : prev.next.next;

        return head;        
    }
}
