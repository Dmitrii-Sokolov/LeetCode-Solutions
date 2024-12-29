namespace Problem732
{

  /// <summary>
  /// 732. My Calendar III
  /// https://leetcode.com/problems/my-calendar-iii
  /// 
  /// Difficulty Hard
  /// Acceptance 71.9%
  /// 
  /// Binary Search
  /// Design
  /// Segment Tree
  /// Prefix Sum
  /// Ordered Set
  /// </summary>
  public class MyCalendarThree
  {

    private SortedList<int, int> TimeSegments = new();
    private int Intersections = 0;

    public MyCalendarThree()
    {
      TimeSegments.Add(-1, 0);
      TimeSegments.Add(1000_000_000, 0);
    }

    public int Book(int startTime, int endTime)
    {
      var from = GetIndex(startTime);
      var to = GetIndex(endTime);
      var currentSegmentIntersections = 0;
      for (var i = from; i < to; i++)
      {
        var intersections = TimeSegments.GetValueAtIndex(i);
        intersections++;
        TimeSegments.SetValueAtIndex(i, intersections);

        if (currentSegmentIntersections < intersections)
          currentSegmentIntersections = intersections;
      }

      if (Intersections < currentSegmentIntersections)
        Intersections = currentSegmentIntersections;

      return Intersections;
    }

    private int GetIndex(int time)
    {
      int index;
      if (!TimeSegments.ContainsKey(time))
      {
        index = FindLast(0, TimeSegments.Count - 1, c => TimeSegments.GetKeyAtIndex(c) <= time);
        TimeSegments[time] = TimeSegments.GetValueAtIndex(index);
        index++;
      }
      else
      {
        index = TimeSegments.IndexOfKey(time);
      }

      return index;
    }

    private static int FindLast(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (check(middle))
          min = middle;
        else
        {
          max = middle - 1;
        }
      }

      return min;
    }
  }
}
