namespace Problem0300
{

  /// <summary>
  /// 300. Longest Increasing Subsequence
  /// https://leetcode.com/problems/longest-increasing-subsequence
  /// 
  /// Difficulty Medium
  /// Acceptance 56.5%
  /// 
  /// Array
  /// Binary Search
  /// Dynamic Programming
  /// Longest Increasing Subsequence
  /// </summary>
  public class Solution
  {
    public int LengthOfLIS(int[] numbers)
    {
      var ends = new List<int>();
      ends.Add(numbers[0]);
      for (var i = 1; i < numbers.Length; i++)
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
      }

      return ends.Count;
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
