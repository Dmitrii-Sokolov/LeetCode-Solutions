namespace Problem2762
{

  /// <summary>
  /// 2762. Continuous Subarrays
  /// https://leetcode.com/problems/continuous-subarrays
  /// 
  /// Difficulty Medium
  /// Acceptance 48.5%
  /// 
  /// Sliding Window
  /// Array
  /// Queue
  /// Heap (Priority Queue)
  /// Ordered Set
  /// Monotonic Queue
  /// Two Pointers
  /// Ordered Map
  /// Hash Table
  /// Dynamic Programming
  /// Binary Search Tree
  /// Counting
  /// Segment Tree
  /// Binary Search
  /// Stack
  /// Tree
  /// Memoization
  /// Monotonic Stack
  /// Math
  /// Iterator
  /// Recursion
  /// Depth-First Search
  /// Greedy
  /// </summary>
  public class Solution
  {
    private const int MaxDifference = 2;

    public long ContinuousSubarrays(int[] numbers)
    {
      var result = 0L;
      var right = 0;
      while (right < numbers.Length)
      {
        var maxIndex = right;
        var minIndex = right;
        var left = right;

        while (left > 0 && IsInBounds(numbers, left - 1, maxIndex, minIndex))
          CheckBounds(numbers, ref maxIndex, ref minIndex, --left);

        long count = right - left;
        result -= count * (count + 1) / 2;

        while (right < numbers.Length && IsInBounds(numbers, right, maxIndex, minIndex))
          CheckBounds(numbers, ref maxIndex, ref minIndex, right++);

        count = right - left;
        result += count * (count + 1) / 2;
      }

      return result;
    }

    private static bool IsInBounds(int[] numbers, int right, int maxIndex, int minIndex)
    {
      return numbers[right] - numbers[minIndex] <= MaxDifference &&
        numbers[maxIndex] - numbers[right] <= MaxDifference;
    }

    private static void CheckBounds(int[] numbers, ref int maxIndex, ref int minIndex, int left)
    {
      if (numbers[minIndex] > numbers[left])
        minIndex = left;

      if (numbers[maxIndex] < numbers[left])
        maxIndex = left;
    }
  }
}
