namespace Problem3068
{

  /// <summary>
  /// 3068. Find the Maximum Sum of Node Values
  /// https://leetcode.com/problems/find-the-maximum-sum-of-node-values
  /// 
  /// Difficulty Hard
  /// Acceptance 67.0%
  /// 
  /// Array
  /// Dynamic Programming
  /// Greedy
  /// Bit Manipulation
  /// Tree
  /// Sorting
  /// </summary>
  public class Solution
  {
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
      long sum = 0;
      var minDelta = int.MaxValue;
      var isOdd = false;

      for (var i = 0; i < nums.Length; i++)
      {
        var a = nums[i];
        var b = nums[i] ^ k;

        isOdd ^= b > a;
        minDelta = Math.Min(minDelta, Math.Abs(a - b));
        sum += Math.Max(a, b);
      }

      if (isOdd)
        sum -= minDelta;

      return sum;

    }
  }
}
