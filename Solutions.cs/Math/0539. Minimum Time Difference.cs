namespace Problem539
{

  /// <summary>
  /// 539. Minimum Time Difference
  /// https://leetcode.com/problems/minimum-time-difference
  /// 
  /// Difficulty Medium
  /// Acceptance 58.5%
  /// 
  /// Array
  /// Math
  /// String
  /// Sorting
  /// </summary>
  public class Solution
  {
    private const char ZeroDigit = '0';

    public int FindMinDifference(IList<string> timePoints)
    {
      var numbers = timePoints.Select(TimeToMinutes).ToArray();
      Array.Sort(numbers);

      var result = Distance(numbers[^1] - numbers[0]);
      for (var i = 0; i < numbers.Length - 1; i++)
      {
        var difference = Distance(numbers[i + 1] - numbers[i]);
        if (difference < result)
          result = difference;
      }

      return result;
    }

    private static int Distance(int difference)
    {
      if (difference > 720)
        difference = 1440 - difference;

      return difference;
    }

    private static int TimeToMinutes(string time)
    {
      var hours = 10 * CharToDigit(time[0]) + CharToDigit(time[1]);
      var minutes = 10 * CharToDigit(time[3]) + CharToDigit(time[4]);
      return hours * 60 + minutes;
    }

    private static int CharToDigit(char digit)
      => digit - ZeroDigit;
  }
}
