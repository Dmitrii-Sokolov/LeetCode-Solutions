/// <summary>
/// 42. Trapping Rain Water
/// https://leetcode.com/problems/trapping-rain-water
/// 
/// Difficulty Hard
/// Acceptance 62.6%
/// 
/// Array
/// Two Pointers
/// Dynamic Programming
/// Stack
/// Monotonic Stack
/// </summary>
class Solution
{
  public int trap(int[] height)
  {
    var len = height.length;
    var lefts = new int[len];
    var rights = new int[len];

    var left = 0;
    var right = 0;

    for (var i = 0; i < len; i++)
    {
      left = Math.max(left, height[i]);
      lefts[i] = left;

      right = Math.max(right, height[len - 1 - i]);
      rights[len - 1 - i] = right;
    }

    var result = 0;

    for (var i = 0; i < len; i++)
      result += Math.min(lefts[i], rights[i]) - height[i];

    return result;
  }
}
