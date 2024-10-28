namespace Problem2501
{

  /// <summary>
  /// 2501. Longest Square Streak in an Array
  /// https://leetcode.com/problems/longest-square-streak-in-an-array
  /// 
  /// Difficulty Medium
  /// Acceptance 47.7%
  /// 
  /// Array
  /// Hash Table
  /// Binary Search
  /// Dynamic Programming
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int LongestSquareStreak(int[] numbersRaw)
    {
      var numbers = numbersRaw.ToHashSet();
      var result = 1;

      foreach (var number in numbers)
      {
        if (number > 317)
          continue;

        var streak = 1;
        var next = number * number;
        while (numbers.Contains(next))
        {
          streak++;
          next *= next;
        }

        if (streak > result)
          result = streak;
      }

      return result == 1 ? -1 : result;
    }
  }
}
