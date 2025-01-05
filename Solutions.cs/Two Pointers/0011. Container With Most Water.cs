namespace Problem11
{

  /// <summary>
  /// 11. Container With Most Water
  /// https://leetcode.com/problems/container-with-most-water
  /// 
  /// Difficulty Medium
  /// Acceptance 56.8%
  /// 
  /// Array
  /// Two Pointers
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MaxArea(int[] height)
    {
      var maxArea = 0;
      var left = 0;
      var right = height.Length - 1;
      while (left < right)
      {
        var candidate = (right - left) * Math.Min(height[left], height[right]);
        if (maxArea < candidate)
          maxArea = candidate;

        if (height[left] < height[right])
        {
          var test = height[left];
          while (left < right && height[left] <= test)
            left++;
        }
        else
        {
          var test = height[right];
          while (left < right && height[right] <= test)
            right--;
        }
      }

      return maxArea;
    }
  }
}
