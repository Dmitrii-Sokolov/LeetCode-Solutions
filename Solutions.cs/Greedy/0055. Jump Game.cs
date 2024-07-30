namespace Problem55
{

  /// <summary>
  /// 55. Jump Game
  /// https://leetcode.com/problems/jump-game
  /// 
  /// Difficulty Medium
  /// Acceptance 38.7%
  /// 
  /// Array
  /// Dynamic Programming
  /// Greedy
  /// </summary>
  public class Solution
  {
    public bool CanJump(int[] nums)
    {
      var max = 0;
      var current = 0;
      var target = nums.Length - 1;

      while (current <= max && max < target)
      {
        max = Math.Max(current + nums[current++], max);
      }

      return max >= target;
    }
  }
}
