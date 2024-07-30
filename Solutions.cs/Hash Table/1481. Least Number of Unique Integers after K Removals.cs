namespace Problem1481
{

  /// <summary>
  /// 1481. Least Number of Unique Integers after K Removals
  /// https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals
  /// 
  /// Difficulty Medium
  /// Acceptance 63.1%
  /// 
  /// Array
  /// Hash Table
  /// Greedy
  /// Sorting
  /// Counting
  /// </summary>
  public class Solution
  {
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
      var numbers = new Dictionary<int, int>();

      for (var i = 0; i < arr.Length; i++)
      {
        if (numbers.TryGetValue(arr[i], out var count))
        {
          numbers[arr[i]] = count + 1;
        }
        else
        {
          numbers[arr[i]] = 1;
        }
      }

      var counts = numbers.Values.ToArray();

      Array.Sort(counts);

      for (var i = 0; i < counts.Length; i++)
      {
        k -= counts[i];
        if (k < 0)
          return counts.Length - i;
      }

      return 0;
    }
  }
}
