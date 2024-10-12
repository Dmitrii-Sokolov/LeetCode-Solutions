namespace Problem2406
{

  /// <summary>
  /// 2406. Divide Intervals Into Minimum Number of Groups
  /// https://leetcode.com/problems/divide-intervals-into-minimum-number-of-groups
  /// 
  /// Difficulty Medium
  /// Acceptance 53.3%
  /// 
  /// Array
  /// Two Pointers
  /// Greedy
  /// Sorting
  /// Heap (Priority Queue)
  /// Prefix Sum
  /// </summary>
  public class Solution
  {

    ///// <summary>
    ///// Solution with primitive counting, about 530 ms
    ///// </summary>
    public int MinGroups(int[][] intervals)
    {
      var min = int.MaxValue;
      var max = int.MinValue;
      foreach (var interval in intervals)
      {
        var start = interval[0];
        var end = interval[1];

        if (start < min)
          min = start;

        if (end > max)
          max = end;
      }

      var points = new int[max - min + 2];
      foreach (var interval in intervals)
      {
        var start = interval[0];
        var end = interval[1];

        points[start - min]++;
        points[end - min + 1]--;
      }

      var result = 1;
      var current = 0;
      foreach (var point in points)
      {
        current += point;

        if (current > result)
          result = current;
      }

      return result;
    }

    /// <summary>
    /// Solution with dictionary counting, about 1000 ms
    /// </summary>
    //public int MinGroups(int[][] intervals)
    //{
    //  var points = new SortedDictionary<int, int>();
    //  foreach (var interval in intervals)
    //  {
    //    var start = interval[0];
    //    var end = interval[1] + 1;

    //    points[start] = points.GetValueOrDefault(start, 0) + 1;
    //    points[end] = points.GetValueOrDefault(end, 0) - 1;
    //  }

    //  var result = 1;
    //  var current = 0;
    //  foreach (var point in points.Values)
    //  {
    //    current += point;

    //    if (current > result)
    //      result = current;
    //  }

    //  return result;
    //}

    /// <summary>
    /// Solution with sorting and PriorityQueue, about 700 ms
    /// </summary>
    //public int MinGroups(int[][] intervals)
    //{
    //  Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
    //  var result = 1;
    //  var ends = new PriorityQueue<int, int>();

    //  foreach (var interval in intervals)
    //  {
    //    var start = interval[0];
    //    while (ends.Count > 0 && ends.Peek() < start)
    //    {
    //      ends.Dequeue();
    //    }

    //    var end = interval[1];
    //    ends.Enqueue(end, end);

    //    if (ends.Count > result)
    //      result = ends.Count;
    //  }

    //  return result;
    //}
  }
}
