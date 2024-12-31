namespace Problem983
{

  /// <summary>
  /// 983. Minimum Cost For Tickets
  /// https://leetcode.com/problems/minimum-cost-for-tickets
  /// 
  /// Difficulty Medium
  /// Acceptance 66.0%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MincostTickets(int[] days, int[] costs)
    {
      var day = costs[0];
      var week = costs[1];
      var month = costs[2];

      var maxCost = days.Length * day;
      var minDate = days[0];
      var maxDate = days[^1];

      var dollars = new int[maxDate - minDate + 2];
      for (var i = 1; i < dollars.Length; i++)
        dollars[i] = maxCost;

      var dayNumber = 0;
      for (var dateShift = 0; dateShift < maxDate - minDate + 1; dateShift++)
      {
        if (minDate + dateShift < days[dayNumber])
        {
          dollars[dateShift + 1] = dollars[dateShift];
        }
        else
        {
          dayNumber++;

          var weekEarlier = Math.Max(0, dateShift - 6);
          var monthEarlier = Math.Max(0, dateShift - 29);

          dollars[dateShift + 1] = Math.Min(Math.Min(
            dollars[dateShift] + day,
            dollars[weekEarlier] + week),
            dollars[monthEarlier] + month);
        }
      }

      return dollars[^1];
    }
  }
}
