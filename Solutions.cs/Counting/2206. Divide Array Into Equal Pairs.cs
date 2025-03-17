namespace Problem2206
{

  /// <summary>
  /// 2206. Divide Array Into Equal Pairs
  /// https://leetcode.com/problems/divide-array-into-equal-pairs
  /// 
  /// Difficulty Easy
  /// Acceptance 76.7%
  /// 
  /// Array
  /// Hash Table
  /// Bit Manipulation
  /// Counting
  /// </summary>
  public class Solution
  {
    public bool DivideArray(int[] numbers)
    {
      Span<bool> counts = stackalloc bool[500];
      var count = 0;
      foreach (var number in numbers)
      {
        counts[number - 1] = !counts[number - 1];
        count += counts[number - 1] ? 1 : -1;
      }

      return count == 0;
    }
  }
}
