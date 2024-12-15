namespace Problem2054
{

  /// <summary>
  /// 2054. Two Best Non-Overlapping Events
  /// https://leetcode.com/problems/two-best-non-overlapping-events
  /// 
  /// Difficulty Medium
  /// Acceptance 53.0%
  /// 
  /// Array
  /// Binary Search
  /// Dynamic Programming
  /// Sorting
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public int MaxTwoEvents(int[][] events)
    {
      Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));
      var postfixes = new int[events.Length];

      postfixes[^1] = 0;
      for (var i = events.Length - 1; i >= 1; i--)
        postfixes[i - 1] = Math.Max(events[i][2], postfixes[i]);

      var result = 0;
      for (var i = 0; i < events.Length; i++)
      {
        var index = FindMax(i, events.Length - 1, candidate => events[candidate][0] <= events[i][1]);
        var candidate = events[i][2] + postfixes[index];
        if (result < candidate)
          result = candidate;
      }

      return result;
    }

    // Find last that's appropriate
    private static int FindMax(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (check(middle))
        {
          min = middle;
        }
        else
        {
          max = middle - 1;
        }
      }

      return min;
    }
  }
}
