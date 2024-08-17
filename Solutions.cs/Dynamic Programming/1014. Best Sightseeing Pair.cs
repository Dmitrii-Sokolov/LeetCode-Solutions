namespace Problem1014
{

  /// <summary>
  /// 1014. Best Sightseeing Pair
  /// https://leetcode.com/problems/best-sightseeing-pair
  /// 
  /// Difficulty Medium
  /// Acceptance 59.2%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MaxScoreSightseeingPair(int[] values)
    {
      var sum = 0;
      var max = 0;

      foreach (var value in values)
      {
        max--;
        if (value + max > sum)
          sum = value + max;

        if (value > max)
          max = value;
      }

      return sum;
    }
  }
}
