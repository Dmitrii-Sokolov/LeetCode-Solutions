namespace Problem2779
{

  /// <summary>
  /// 2779. Maximum Beauty of an Array After Applying Operation
  /// https://leetcode.com/problems/maximum-beauty-of-an-array-after-applying-operation
  /// 
  /// Difficulty Medium
  /// Acceptance 48.8%
  /// 
  /// Array
  /// Binary Search
  /// Sliding Window
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MaximumBeauty(int[] numbers, int k)
    {
      Array.Sort(numbers);
      var maxDifference = 2 * k;
      var left = 0;
      var right = 0;
      var result = 1;
      while (right < numbers.Length)
      {
        var min = numbers[right] - maxDifference;
        while (numbers[left] < min)
          left++;

        var max = numbers[left] + maxDifference;
        while (right < numbers.Length && numbers[right] <= max)
          right++;

        var candidate = right - left;
        if (result < candidate)
          result = candidate;
      }

      return result;
    }
  }
}
