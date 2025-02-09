namespace Problem2364
{

  /// <summary>
  /// 2364. Count Number of Bad Pairs
  /// https://leetcode.com/problems/count-number-of-bad-pairs
  /// 
  /// Difficulty Medium
  /// Acceptance 48.0%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Counting
  /// </summary>
  public class Solution
  {
    public long CountBadPairs(int[] numbers)
    {
      var offsets = new Dictionary<int, int>();
      var goodPairs = 0L;
      for (var i = 0; i < numbers.Length; i++)
      {
        var offset = numbers[i] - i;
        var count = offsets.GetValueOrDefault(offset);
        goodPairs += count;
        offsets[offset] = count + 1;
      }

      return numbers.Length * (numbers.Length - 1L) / 2L - goodPairs;
    }
  }
}
