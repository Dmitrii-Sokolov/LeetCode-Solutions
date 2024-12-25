namespace Problem1671
{

  /// <summary>
  /// 1671. Minimum Number of Removals to Make Mountain Array
  /// https://leetcode.com/problems/minimum-number-of-removals-to-make-mountain-array
  /// 
  /// Difficulty Hard
  /// Acceptance 46.5%
  /// 
  /// Array
  /// Binary Search
  /// Dynamic Programming
  /// Greedy
  /// Longest Increasing Subsequence
  /// </summary>
  public class Solution
  {
    public int MinimumMountainRemovals(int[] numbers)
    {
      var maxLength = 3;
      var increasing = LengthOfLIS(numbers);
      var decreasing = LengthOfLDS(numbers);
      for (var i = 1; i < numbers.Length - 1; i++)
      {
        if (increasing[i] > 1 && decreasing[i] > 1)
        {
          var candidate = increasing[i] + decreasing[i] - 1;
          if (maxLength < candidate)
            maxLength = candidate;
        }
      }

      return numbers.Length - maxLength;
    }

    private static int[] LengthOfLIS(int[] numbers)
    {
      var result = new int[numbers.Length];
      var ends = new List<int> { numbers[0] };
      for (var i = 0; i < numbers.Length; i++)
      {
        var number = numbers[i];
        if (ends[^1] < number)
        {
          ends.Add(number);
        }
        else
        {
          var index = FindFirstGreaterOrEqual(ends, number);
          ends[index] = number;
        }

        result[i] = ends.Count;
      }

      return result;
    }

    private static int[] LengthOfLDS(int[] numbers)
    {
      var result = new int[numbers.Length];
      var ends = new List<int> { numbers[^1] };
      for (var i = numbers.Length - 1; i >= 0; i--)
      {
        var number = numbers[i];
        if (ends[^1] < number)
        {
          ends.Add(number);
        }
        else
        {
          var index = FindFirstGreaterOrEqual(ends, number);
          ends[index] = number;
        }

        result[i] = ends.Count;
      }

      return result;
    }

    private static int FindFirstGreaterOrEqual(List<int> list, int number)
    {
      var min = 0;
      var max = list.Count - 1;
      while (min < max)
      {
        var middle = max + min >> 1;
        var test = list[middle];

        if (test == number)
        {
          return middle;
        }
        else if (test < number)
        {
          min = middle + 1;
        }
        else
        {
          max = middle;
        }
      }

      return min;
    }
  }
}
