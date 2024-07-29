namespace Problem42
{

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
  public class Solution
  {
    public int Trap(int[] height)
    {
      var len = height.Length;
      var lefts = new int[len];
      var rights = new int[len];

      var left = 0;
      var right = 0;

      for (var i = 0; i < len; i++)
      {
        left = Math.Max(left, height[i]);
        lefts[i] = left;

        right = Math.Max(right, height[len - 1 - i]);
        rights[len - 1 - i] = right;
      }

      var result = 0;

      for (var i = 0; i < len; i++)
        result += Math.Min(lefts[i], rights[i]) - height[i];

      return result;
    }
  }
}
