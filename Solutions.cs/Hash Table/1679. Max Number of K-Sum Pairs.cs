namespace Problem1679
{

  /// <summary>
  /// 1679. Max Number of K-Sum Pairs
  /// https://leetcode.com/problems/max-number-of-k-sum-pairs
  /// 
  /// Difficulty Medium
  /// Acceptance 55.6%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    // Hash Table
    public int MaxOperations(int[] numbers, int k)
    {
      var counts = new Dictionary<int, int>();
      foreach (var number in numbers)
      {
        if (!counts.TryGetValue(number, out var value))
        {
          value = 0;
          counts[number] = value;
          counts[k - number] = 0;
        }

        counts[number] = ++value;
      }

      var result = 0;
      foreach (var pair in counts)
        result += Math.Min(pair.Value, counts[k - pair.Key]);

      return result / 2;
    }

    // Two Pointers
    //public int MaxOperations(int[] numbers, int k)
    //{
    //  Array.Sort(numbers);

    //  var min = 0;
    //  var max = numbers.Length - 1;
    //  var result = 0;
    //  while (min < max)
    //  {
    //    if (numbers[min] + numbers[max] == k)
    //    {
    //      result++;
    //      min++;
    //      max--;
    //    }
    //    else if (numbers[min] + numbers[max] > k)
    //    {
    //      max--;
    //    }
    //    else
    //    {
    //      min++;
    //    }
    //  }

    //  return result;
    //}
  }
}
