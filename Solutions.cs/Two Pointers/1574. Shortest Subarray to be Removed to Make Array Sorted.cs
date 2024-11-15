namespace Problem1574
{

  /// <summary>
  /// 1574. Shortest Subarray to be Removed to Make Array Sorted
  /// https://leetcode.com/problems/shortest-subarray-to-be-removed-to-make-array-sorted
  /// 
  /// Difficulty Medium
  /// Acceptance 45.7%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Stack
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public int FindLengthOfShortestSubarray(int[] array)
    {
      var first = 0;
      while (first < array.Length - 1 && array[first] <= array[first + 1])
        first++;

      if (first == array.Length - 1)
        return 0;

      var last = array.Length - 1;
      if (array[first] <= array[last])
      {
        do
        {
          last--;
        }
        while (array[first] <= array[last] && array[last] <= array[last + 1]);
      }

      var result = last - first;
      while (last > 0 && (last == array.Length - 1 || array[last] <= array[last + 1]))
      {
        last--;

        if (first >= 0 && array[first] > array[last + 1])
          first = FindMin(0, first, c => array[c] > array[last + 1]) - 1;

        while (last > 0 && (first == -1 || array[first] <= array[last]) && array[last] <= array[last + 1])
          last--;

        if (result > last - first)
          result = last - first;
      }

      return result;
    }

    // Find first that's appropriate
    private static int FindMin(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = max + min >> 1;
        if (check(middle))
        {
          max = middle;
        }
        else
        {
          min = middle + 1;
        }
      }

      return min;
    }
  }
}
