namespace Problem2563
{

  /// <summary>
  /// 2563. Count the Number of Fair Pairs
  /// https://leetcode.com/problems/count-the-number-of-fair-pairs
  /// 
  /// Difficulty Medium
  /// Acceptance 40.3%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public long CountFairPairs(int[] numbers, int minSum, int maxSum)
    {
      var result = 0L;
      Array.Sort(numbers);

      for (var i = 0; i < numbers.Length - 1; i++)
      {
        var number = numbers[i];
        var minValue = minSum - number;
        var maxValue = maxSum - number;

        if (numbers[^1] >= minValue && numbers[i + 1] <= maxValue)
        {
          var minIndex = FindMin(numbers, i + 1, minValue);
          var maxIndex = FindMax(numbers, i + 1, maxValue);
          result += maxIndex - minIndex + 1;
        }
      }

      return result;
    }

    // Find first that >= edge
    private static int FindMin(int[] numbers, int from, int edge)
    {
      var min = from;
      var max = numbers.Length - 1;
      while (max > min)
      {
        var middle = max + min >> 1;
        if (numbers[middle] >= edge)
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

    // Find last that <= edge
    private static int FindMax(int[] numbers, int from, int edge)
    {
      var min = from;
      var max = numbers.Length - 1;
      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (numbers[middle] <= edge)
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
