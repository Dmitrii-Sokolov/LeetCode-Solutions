namespace Problem1588
{

  /// <summary>
  /// 1588. Sum of All Odd Length Subarrays
  /// https://leetcode.com/problems/sum-of-all-odd-length-subarrays
  /// 
  /// Difficulty Easy
  /// Acceptance 83.1%
  /// 
  /// Array
  /// Math
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int SumOddLengthSubarrays(int[] arr)
    {
      var result = 0;

      for (var i = 0; i < arr.Length / 2; i++)
      {
        var multiplier = CalcMultiplier(i, arr.Length - i - 1);
        ;
        result += arr[i] * multiplier;
        result += arr[arr.Length - i - 1] * multiplier;
      }

      if (arr.Length % 2 > 0)
      {
        var multiplier = CalcMultiplier(arr.Length / 2, arr.Length / 2);
        ;
        result += arr[arr.Length / 2] * multiplier;
      }

      return result;
    }

    private int CalcMultiplier(int left, int right) => (((left + 1) * (right + 1)) + 1) / 2;
  }
}
