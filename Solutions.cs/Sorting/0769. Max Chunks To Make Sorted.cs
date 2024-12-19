namespace Problem769
{

  /// <summary>
  /// 769. Max Chunks To Make Sorted
  /// https://leetcode.com/problems/max-chunks-to-make-sorted
  /// 
  /// Difficulty Medium
  /// Acceptance 60.4%
  /// 
  /// Array
  /// Stack
  /// Greedy
  /// Sorting
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public int MaxChunksToSorted(int[] numbers)
    {
      var result = 0;
      var sum = 0;
      var targetSum = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        sum += i;
        targetSum += numbers[i];
        if (sum == targetSum)
          result++;
      }

      return result;
    }
  }
}
