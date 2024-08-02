namespace Problem2134
{

  /// <summary>
  /// 2134. Minimum Swaps to Group All 1's Together II
  /// https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 57.8 %
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MinSwaps(int[] nums)
    {
      var ones = nums.Sum();
      var current = ones - Enumerable.Range(0, ones).Sum(i => nums[i]);
      var result = current;
      for (var i = 0; i < nums.Length - 1; i++)
      {
        current += 1 - nums[(i + ones) % nums.Length];
        current -= 1 - nums[i];

        if (current < result)
          result = current;

        if (result == 0)
          break;
      }

      return result;
    }
  }
}
