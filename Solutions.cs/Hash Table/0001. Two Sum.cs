namespace Problem1
{

  /// <summary>
  /// 1. Two Sum
  /// https://leetcode.com/problems/two-sum
  /// 
  /// Difficulty Easy
  /// Acceptance 53.2%
  /// 
  /// Array
  /// Hash Table
  /// </summary>
  public class Solution
  {
    public int[] TwoSum(int[] nums, int target)
    {
      var history = new Dictionary<int, int>(nums.Length);
      for (var i = 0; i < nums.Length; i++)
      {
        if (history.TryGetValue(target - nums[i], out var index))
          return new int[] { index, i };

        history[nums[i]] = i;
      }

      throw new ArgumentException();
    }
  }
}
