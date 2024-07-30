/// <summary>
/// 2. Add Two Numbers
/// https://leetcode.com/problems/add-two-numbers
/// 
/// Difficulty Medium
/// Acceptance 43.6%
/// 
/// Linked List
/// Math
/// Recursion
/// </summary>
class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var result = new ListNode();;
        var node = result;

        while (l1 != null || l2 != null) {
            if (node.next == null) {
                node.next = new ListNode(0, null);
            }

            node = node.next;

            if (l1 != null) {
                node.val += l1.val;
                l1 = l1.next;
            }

            if (l2 != null) {
                node.val += l2.val;
                l2 = l2.next;
            }
            
            if (node.val >= 10) {
                node.next = new ListNode(node.val / 10, null);
            }
            
            node.val %= 10;
        }

        return result.next;
    }
}
