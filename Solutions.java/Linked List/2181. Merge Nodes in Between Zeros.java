/// <summary>
/// 2181. Merge Nodes in Between Zeros
/// https://leetcode.com/problems/merge-nodes-in-between-zeros
/// 
/// Difficulty Medium
/// Acceptance 89.8%
/// 
/// Linked List
/// Simulation
/// </summary>
class Solution {
    public ListNode mergeNodes(ListNode head) {
        var result = head;

        var node = head;
        head = head.next;

        while (head.next != null) {
            if (head.val == 0) {
                node = node.next;
                node.val = 0;
            }

            node.val += head.val;
            head = head.next;
        }

        node.next = null;
        
        return result;
    }
}
