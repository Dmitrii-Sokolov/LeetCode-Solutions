namespace Problem2971
{

  /// <summary>
  /// 2971. Find Polygon With the Largest Perimeter
  /// https://leetcode.com/problems/find-polygon-with-the-largest-perimeter
  /// 
  /// Difficulty Medium
  /// Acceptance 66.1%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public long LargestPerimeter(int[] nums)
    {
      Array.Sort(nums);

      var len = nums.Length;
      long sum = 0;

      for (var i = len - 1; i >= 0; i--)
        sum += nums[i];

      for (var i = len - 1; i >= 0; i--)
      {
        var num = nums[i];

        if (sum - num > num)
          return sum;

        sum -= num;
      }

      return -1;
    }
  }
}
