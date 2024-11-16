namespace Problem3254
{

  /// <summary>
  /// 3254. Find the Power of K-Size Subarrays I
  /// https://leetcode.com/problems/find-the-power-of-k-size-subarrays-i
  /// 
  /// Difficulty Medium
  /// Acceptance 58.0%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int[] ResultsArray(int[] numbers, int k)
    {
      var shift = k - 1;
      if (shift == 0)
        return numbers;

      var result = new int[numbers.Length - shift];
      var lastGoodPosition = 0;
      for (var i = 1; i <= shift; i++)
      {
        if (numbers[i] != numbers[i - 1] + 1)
          lastGoodPosition = i;
      }

      for (var i = shift; i < numbers.Length; i++)
      {
        if (numbers[i] != numbers[i - 1] + 1)
          lastGoodPosition = i;

        result[i - shift] = lastGoodPosition + shift <= i ? numbers[i] : -1;
      }

      return result;
    }
  }
}
