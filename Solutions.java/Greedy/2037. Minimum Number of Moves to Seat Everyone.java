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
class Solution
{
  public int minMovesToSeat(int[] seats, int[] students)
  {
    Arrays.sort(seats);
    Arrays.sort(students);

    var n = seats.length;
    var result = 0;

    for (var i = 0; i < n; i++)
    {
      result += Math.abs(seats[i] - students[i]);
    }

    return result;
  }
}
