namespace Problem53
{

  /// <summary>
  /// 53. Maximum Subarray
  /// https://leetcode.com/problems/maximum-subarray/description/
  /// 
  /// Difficulty Medium
  /// Acceptance 51.5%
  /// 
  /// Array
  /// Divide and Conquer
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MaxSubArray(int[] numbers)
    {
      var sum = 0;
      var result = numbers[0];
      foreach (var number in numbers)
      {
        sum += number;

        if (result < sum)
          result = sum;

        if (sum < 0)
          sum = 0;
      }

      return result;
    }
  }
}
