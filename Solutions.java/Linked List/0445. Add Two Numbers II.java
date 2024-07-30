/// <summary>
/// 445. Add Two Numbers II
/// https://leetcode.com/problems/add-two-numbers-ii
/// 
/// Difficulty Medium
/// Acceptance 61.3%
/// 
/// Linked List
/// Math
/// Stack
/// </summary>
class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var lastNonNine = new ListNode(0, null);
        var result = lastNonNine;
        ListNode node;

        var size1 = 1;
        node = l1;
        while (node != null) {
            node = node.next;
            size1++;
        }

        var size2 = 1;
        node = l2;
        while (node != null) {
            node = node.next;
            size2++;
        }

        node = result;
        var counter = Math.max(size2, size1) - 1;
        while (counter > 0) {
            node.next = new ListNode(0, null);
            node = node.next;

            if (counter < size1) {
                node.val += l1.val;
                l1 = l1.next;
            }

            if (counter < size2) {
                node.val += l2.val;
                l2 = l2.next;
            }
            counter--;

            if (node.val >= 10) {
                node.val = node.val % 10;
                lastNonNine.val++;
                lastNonNine = lastNonNine.next;

                while (lastNonNine != node) {
                    lastNonNine.val = 0;
                    lastNonNine = lastNonNine.next;
                }
            }

            if (node.val <= 8) {
                lastNonNine = node;
            }
        }

        return result.val == 0 ? result.next : result;
    }
}
