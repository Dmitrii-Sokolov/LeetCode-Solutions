namespace Problem3068
{

  /// <summary>
  /// 3068. Find the Maximum Sum of Node Values
  /// https://leetcode.com/problems/find-the-maximum-sum-of-node-values
  /// 
  /// Difficulty Hard 67.0%
  /// 
  /// Array
  /// Dynamic Programming
  /// Greedy
  /// Bit Manipulation
  /// Tree
  /// Sorting
  /// </summary>
  class Solution
  {
    public long maximumValueSum(int[] nums, int k, int[][] edges)
    {
      long sum = 0;
      var minDelta = Integer.MAX_VALUE;
      var isOdd = false;

      for (var i = 0; i < nums.length; i++)
      {
        var a = nums[i];
        var b = nums[i] ^ k;

        isOdd ^= b > a;
        minDelta = Math.min(minDelta, Math.abs(a - b));
        sum += Math.max(a, b);
      }

      if (isOdd)
      {
        sum -= minDelta;
      }

      return sum;

    }
  }
}
