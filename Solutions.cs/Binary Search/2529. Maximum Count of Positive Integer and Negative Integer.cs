namespace Problem2529
{

  /// <summary>
  /// 2529. Maximum Count of Positive Integer and Negative Integer
  /// https://leetcode.com/problems/maximum-count-of-positive-integer-and-negative-integer
  /// 
  /// Difficulty Easy
  /// Acceptance 72.0%
  /// 
  /// Array
  /// Binary Search
  /// Counting
  /// </summary>
  public class Solution
  {
    public int MaximumCount(int[] numbers)
      => FindMax(0, numbers.Length, count => numbers[count - 1] < 0 || numbers[numbers.Length - count] > 0);

    private static int FindMax(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (check(middle))
        {
          min = middle;
        }
        else
        {
          max = middle - 1;
        }
      }

      return min;
    }
  }
}
