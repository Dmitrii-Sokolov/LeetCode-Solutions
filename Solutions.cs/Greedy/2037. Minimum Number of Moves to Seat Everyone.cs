namespace Problem2037
{

  /// <summary>
  /// 2037. Minimum Number of Moves to Seat Everyone
  /// https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone
  /// 
  /// Difficulty Easy
  /// Acceptance 87.7%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MinMovesToSeat(int[] seats, int[] students)
    {
      Array.Sort(seats);
      Array.Sort(students);

      var n = seats.Length;
      var result = 0;

      for (var i = 0; i < n; i++)
      {
        result += Math.Abs(seats[i] - students[i]);
      }

      return result;
    }
  }
}
