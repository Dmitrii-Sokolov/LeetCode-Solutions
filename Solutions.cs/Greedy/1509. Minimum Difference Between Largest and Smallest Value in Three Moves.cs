namespace Problem1509
{

  /// <summary>
  /// 1509. Minimum Difference Between Largest and Smallest Value in Three Moves
  /// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves
  /// 
  /// Difficulty Medium
  /// Acceptance 59.2%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MinDifference(int[] nums)
    {
      if (nums.Length <= 4)
        return 0;

      int[] mins = { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
      int[] maxs = { int.MinValue, int.MinValue, int.MinValue, int.MinValue };
      for (var i = 0; i < nums.Length; i++)
      {
        var a = nums[i];
        if (a < mins[3])
        {
          mins[3] = a;
          Array.Sort(mins);
        }
        if (a > maxs[0])
        {
          maxs[0] = a;
          Array.Sort(maxs);
        }
      }

      var result = int.MaxValue;
      for (var i = 0; i < 4; i++)
      {
        result = Math.Min(result, maxs[i] - mins[i]);
      }
      return result;
    }
  }
}
