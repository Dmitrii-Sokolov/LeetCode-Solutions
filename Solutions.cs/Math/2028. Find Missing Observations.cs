namespace Problem2028
{

  /// <summary>
  /// 2028. Find Missing Observations
  /// https://leetcode.com/problems/find-missing-observations
  /// 
  /// Difficulty Medium
  /// Acceptance 51.9%
  /// 
  /// Array
  /// Math
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
      var sum = (n + rolls.Length) * mean - rolls.Sum();
      if (n * 6 < sum || sum < n)
        return [];

      var result = new int[n];
      var average = sum / n;
      var remainder = sum - average * n;
      for (var i = 0; i < result.Length; i++)
      {
        result[i] = average + (remainder > 0 ? 1 : 0);
        remainder--;
      }

      return result;
    }
  }
}
