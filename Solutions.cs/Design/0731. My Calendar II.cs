namespace Problem731
{

  /// <summary>
  /// 731. My Calendar II
  /// https://leetcode.com/problems/my-calendar-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 57.1%
  /// 
  /// Array
  /// Binary Search
  /// Design
  /// Segment Tree
  /// Prefix Sum
  /// Ordered Set
  /// </summary>
  public class MyCalendarTwo
  {
    private const int MaxLoad = 2;

    private readonly List<(int Start, int End, int Load)> Bookings = [(0, 1000000000, 0)];

    public bool Book(int start, int end)
    {
      var first = FindFirst(start);
      var last = FindLast(end);
      for (var i = first; i <= last; i++)
      {
        if (Bookings[i].Load >= MaxLoad)
          return false;
      }

      if (Bookings[last].End != end)
      {
        var lastBooking = Bookings[last];
        Bookings[last] = (end, lastBooking.End, lastBooking.Load);
        Bookings.Insert(last, (lastBooking.Start, end, lastBooking.Load));
      }

      if (Bookings[last].Start != start)
      {
        var firstBooking = Bookings[first];
        Bookings[first] = (firstBooking.Start, start, firstBooking.Load);
        first++;
        last++;
        Bookings.Insert(first, (start, firstBooking.End, firstBooking.Load));
      }

      for (var i = first; i <= last; i++)
      {
        var booking = Bookings[i];
        Bookings[i] = (booking.Start, booking.End, booking.Load + 1);

      }

      return true;
    }

    private int FindFirst(int point)
    {
      var min = 0;
      var max = Bookings.Count - 1;
      while (true)
      {
        var middle = (max + min) / 2;
        var (start0, end0, _) = Bookings[middle];

        if (point < start0)
          max = middle - 1;
        else if (end0 <= point)
        {
          min = middle + 1;
        }
        else
        {
          return middle;
        }
      }
    }

    private int FindLast(int point)
    {
      var min = 0;
      var max = Bookings.Count - 1;
      while (true)
      {
        var middle = (max + min) / 2;
        var (start0, end0, _) = Bookings[middle];

        if (point <= start0)
          max = middle - 1;
        else if (end0 < point)
        {
          min = middle + 1;
        }
        else
        {
          return middle;
        }
      }
    }
  }
}
