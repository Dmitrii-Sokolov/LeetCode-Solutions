namespace Problem2342
{

  /// <summary>
  /// 2342. Max Sum of a Pair With Equal Sum of Digits
  /// https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits
  /// 
  /// Difficulty Medium
  /// Acceptance 63.8%
  /// 
  /// Array
  /// Hash Table
  /// Sorting
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    private static int MaxDigitSum = 9 * 9;

    public int MaximumSum(int[] numbers)
    {
      Span<int> maxNumbers = stackalloc int[MaxDigitSum];
      var result = -1;
      foreach (var number in numbers)
      {
        var sum = GetDigitSum(number) - 1;
        if (maxNumbers[sum] == 0)
        {
          maxNumbers[sum] = number;
        }
        else
        {
          var candidate = maxNumbers[sum] + number;
          if (result < candidate)
            result = candidate;

          if (maxNumbers[sum] < number)
            maxNumbers[sum] = number;
        }
      }

      return result;
    }

    private int GetDigitSum(int number)
    {
      var result = 0;
      while (number > 0)
      {
        result += number % 10;
        number /= 10;
      }

      return result;
    }
  }
}
