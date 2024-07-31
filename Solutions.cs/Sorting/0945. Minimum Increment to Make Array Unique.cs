namespace Problem945
{

  /// <summary>
  /// 945. Minimum Increment to Make Array Unique
  /// https://leetcode.com/problems/minimum-increment-to-make-array-unique
  /// 
  /// Difficulty Medium
  /// Acceptance 60.0%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Counting
  /// </summary>
  public class Solution
  {
    public int MinIncrementForUnique(int[] nums)
    {
      var max = 0;
      foreach (var n in nums)
      {
        max = Math.Max(n, max);
      }

      var len = max + nums.Length;
      var counts = new int[len];
      foreach (var n in nums)
      {
        counts[n]++;
      }

      var result = 0;
      for (var i = 0; i < len; i++)
      {
        if (counts[i] > 1)
        {
          result += counts[i] - 1;
          counts[i + 1] += counts[i] - 1;
        }
      }
      return result;
    }
  }
}
