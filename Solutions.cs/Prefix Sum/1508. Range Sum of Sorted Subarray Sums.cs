namespace Problem1508
{

  /// <summary>
  /// 1508. Range Sum of Sorted Subarray Sums
  /// https://leetcode.com/problems/range-sum-of-sorted-subarray-sums
  /// 
  /// Difficulty Medium
  /// Acceptance 61.1%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    private const int Modulo = 1000000007;

    public int RangeSum(int[] nums, int n, int left, int right)
    {
      var sums = new int[n * (n + 1) / 2];
      var partialSums = new int[n];
      var sum = 0;
      for (var i = 0; i < n; i++)
      {
        sum += nums[i];
        partialSums[i] = sum;
      }

      var start = 0;
      var end = 0;
      var p = 0;

      while (end < n)
      {
        sums[p] = partialSums[end] - partialSums[start] + nums[start];
        start++;

        if (start > end)
        {
          end++;
          start = 0;
        }

        p++;
      }

      Array.Sort(sums);

      var result = 0;
      for (var i = left; i <= right; i++)
        result = (result % Modulo) + (sums[i - 1] % Modulo);

      return result;
    }
  }
}
