namespace Problem237
{

  /// <summary>
  /// 237. Delete Node in a Linked List
  /// https://leetcode.com/problems/delete-node-in-a-linked-list
  /// 
  /// Difficulty Medium
  /// Acceptance 80.4%
  /// 
  /// Linked List
  /// </summary>
  public class Solution
  {
    public void DeleteNode(ListNode node)
    {
      while (node.next.next != null)
      {
        node.val = node.next.val;
        node = node.next;
      }

      node.val = node.next.val;
      node.next = null;
    }
  }
}
