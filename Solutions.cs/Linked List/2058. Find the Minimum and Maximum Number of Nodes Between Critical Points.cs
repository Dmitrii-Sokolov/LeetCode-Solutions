﻿namespace Problem2058
{

  /// <summary>
  /// 2058. Find the Minimum and Maximum Number of Nodes Between Critical Points
  /// https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points
  /// 
  /// Difficulty Medium
  /// Acceptance 69.7%
  /// 
  /// Linked List
  /// </summary>
  public class Solution
  {
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
      var direction = 0;
      var counter = 0;
      var previous = head.val;
      var first = -1;
      var last = -1;
      var min = int.MaxValue;

      while (head != null)
      {
        var newDirection = head.val.CompareTo(previous);
        if ((newDirection == 1 && direction == -1) || (newDirection == -1 && direction == 1))
        {
          if (last != -1)
            min = Math.Min(min, counter - last);

          if (first == -1)
            first = counter;

          last = counter;
        }

        direction = newDirection;
        counter++;
        previous = head.val;
        head = head.next;
      }

      int[] result = { min == int.MaxValue ? -1 : min, first == last ? -1 : last - first };
      return result;
    }
  }
}