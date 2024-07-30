/// <summary>
/// 206. Reverse Linked List
/// https://leetcode.com/problems/reverse-linked-list
/// 
/// Difficulty Easy
/// Acceptance 77.2%
/// 
/// Linked List
/// Recursion
/// </summary>
class Solution {
    public ListNode reverseList(ListNode head)
    {
        ListNode newList = null;

        while(head != null)
        {
            newList = new ListNode(head.val, newList);
            head = head.next;
        }

        return newList;
    }
}
