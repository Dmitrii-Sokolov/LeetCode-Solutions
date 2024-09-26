namespace Problem729
{

  /// <summary>
  /// 729. My Calendar I
  /// https://leetcode.com/problems/my-calendar-i
  /// 
  /// Difficulty Medium
  /// Acceptance 56.9%
  /// 
  /// Array
  /// Binary Search
  /// Design
  /// Segment Tree
  /// Ordered Set
  /// </summary>
  public class MyCalendar
  {
    private SortedList<int, int> Bookings = new();

    public bool Book(int start, int end)
    {
      if (Bookings.Count > 0)
      {
        var min = 0;
        var max = Bookings.Count - 1;
        while (min <= max)
        {
          var middle = (max + min) / 2;
          var start0 = Bookings.GetKeyAtIndex(middle);
          var end0 = Bookings.GetValueAtIndex(middle);

          if (end <= start0)
            max = middle - 1;
          else if (end0 <= start)
          {
            min = middle + 1;
          }
          else
          {
            return false;
          }
        }
      }

      Bookings.Add(start, end);

      return true;
    }
  }
}
