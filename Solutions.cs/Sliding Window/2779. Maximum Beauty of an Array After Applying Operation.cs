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
      return PerformSlidingWindow(
        (r) => r < numbers.Length,
        (l, r) => numbers[r] - numbers[l] <= maxDifference,
        (l, r) => r - l,
        (r, c) => r < c);
    }

    private static int PerformSlidingWindow(
      Func<int, bool> loopCheck,
      Func<int, int, bool> isValid,
      Func<int, int, int> getCandidate,
      Func<int, int, bool> isBetter)
    {
      var left = -1;
      var right = 0;
      var result = 1;
      while (loopCheck(right))
      {
        left++;

        while (!isValid(left, right))
          left++;

        while (loopCheck(right) && isValid(left, right))
          right++;

        var candidate = getCandidate(left, right);
        if (isBetter(result, candidate))
          result = candidate;
      }

      return result;
    }

    //public int MaximumBeauty(int[] numbers, int k)
    //{
    //  Array.Sort(numbers);
    //  var maxDifference = 2 * k;
    //  var left = -1;
    //  var right = 0;
    //  var result = 1;
    //  PerformSlidingWindow(
    //    () => right < numbers.Length,
    //    () => left++,
    //    () => numbers[right] - numbers[left] <= maxDifference,
    //    () => right++,
    //    () => result = Math.Max(result, right - left));

    //  return result;
    //}

    //private static void PerformSlidingWindow(
    //  Func<bool> loopCheck,
    //  Action leftShift,
    //  Func<bool> isValid,
    //  Action rightShift,
    //  Action resultRecord)
    //{
    //  while (loopCheck())
    //  {
    //    leftShift();

    //    while (!isValid())
    //      leftShift();

    //    while (loopCheck() && isValid())
    //      rightShift();

    //    resultRecord();
    //  }
    //}
  }
}
