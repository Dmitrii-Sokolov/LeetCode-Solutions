namespace Problem2275
{

  /// <summary>
  /// 2275. Largest Combination With Bitwise AND Greater Than Zero
  /// https://leetcode.com/problems/largest-combination-with-bitwise-and-greater-than-zero
  /// 
  /// Difficulty Medium
  /// Acceptance 77.1%
  /// 
  /// Array
  /// Hash Table
  /// Bit Manipulation
  /// Counting
  /// </summary>
  public class Solution
  {
    public int LargestCombination(int[] candidates)
    {
      var digitCounts = new int[24];
      for (var i = 0; i < candidates.Length; i++)
      {
        var candidate = candidates[i];
        var digit = 0;
        while (candidate > 0)
        {
          digitCounts[digit++] += candidate % 2;
          candidate >>= 1;
        }
      }

      return digitCounts.Max();
    }
  }
}
