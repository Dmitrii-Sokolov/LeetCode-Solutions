/// <summary>
/// 143. Reorder List
/// https://leetcode.com/problems/reorder-list
/// 
/// Difficulty Medium
/// Acceptance 59.5%
/// 
/// Linked List
/// Two Pointers
/// Stack
/// Recursion
/// </summary>
public class Solution
{
    public void reorderList(ListNode head)
    {
        var count = 0;
        ListNode node1 = head;


        while(node1 != null)
        {
            node1 = node1.next;
            count++;
        }

        var links = new ListNode[count];

        var i = 0;
        for(var node = head; node != null; node = node.next)
            links[i++] = node;

        var median = count / 2;
        for(i = 0; i < count; i++)
        {
            if (i < median)
            {
                links[i].next = links[count - i - 1];
            }
            else if (i > median)
            {
                links[i].next = links[count - i];
            }
            else
            {
                links[i].next = null;
            }
        }
    }
}
