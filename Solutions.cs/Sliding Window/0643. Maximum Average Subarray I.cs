namespace Problem643
{

  /// <summary>
  /// 643. Maximum Average Subarray I
  /// https://leetcode.com/problems/maximum-average-subarray-i
  /// 
  /// Difficulty Easy
  /// Acceptance 44.3%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public double FindMaxAverage(int[] numbers, int k)
    {
      var sum = 0d;
      for (var i = 0; i < k; i++)
        sum += numbers[i];

      var result = sum;
      for (var i = k; i < numbers.Length; i++)
      {
        sum += numbers[i];
        sum -= numbers[i - k];

        if (result < sum)
          result = sum;
      }

      return result / k;
    }
  }
}
