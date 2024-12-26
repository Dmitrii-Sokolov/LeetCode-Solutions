namespace Problem494
{

  /// <summary>
  /// 494. Target Sum
  /// https://leetcode.com/problems/target-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 48.5%
  /// 
  /// Array
  /// Dynamic Programming
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public int FindTargetSumWays(int[] numbers, int target)
    {
      var sum = 0;
      for (var i = 0; i < numbers.Length; i++)
        sum += numbers[i];

      if ((target + sum) % 2 != 0)
        return 0;

      if (target < 0)
        target = -target;

      if (target > sum)
        return 0;

      var max = 1;
      var results = new int[sum + 1];
      results[0] = 1;
      for (var i = 0; i < numbers.Length; i++)
      {
        var number = numbers[i];
        max += number;

        for (var j = max - 1; j >= number; j--)
          results[j] += results[j - number];
      }

      return results[(sum + target) / 2];
    }
  }
}
