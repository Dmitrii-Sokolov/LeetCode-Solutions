namespace Problem1800
{

  /// <summary>
  /// 1800. Maximum Ascending Subarray Sum
  /// https://leetcode.com/problems/maximum-ascending-subarray-sum
  /// 
  /// Difficulty Easy
  /// Acceptance 65.2%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public int MaxAscendingSum(int[] numbers)
    {
      var result = 0;
      var currentSum = 0;
      var previous = numbers[0];
      for (var i = 0; i < numbers.Length; i++)
      {
        if (numbers[i] > previous)
        {
          currentSum += numbers[i];
        }
        else
        {
          currentSum = numbers[i];
        }

        previous = numbers[i];
        if (result < currentSum)
          result = currentSum;
      }

      return result;
    }
  }
}
