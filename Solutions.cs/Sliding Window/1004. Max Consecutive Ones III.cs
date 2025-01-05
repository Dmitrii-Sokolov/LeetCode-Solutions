namespace Problem1004
{

  /// <summary>
  /// 1004. Max Consecutive Ones III
  /// https://leetcode.com/problems/max-consecutive-ones-iii
  /// 
  /// Difficulty Medium
  /// Acceptance 64.8%
  /// 
  /// Array
  /// Binary Search
  /// Sliding Window
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int LongestOnes(int[] numbers, int k)
    {
      var left = 0;
      var right = 0;
      while (right < numbers.Length)
      {
        k += numbers[right] - 1;
        right++;

        if (k < 0)
        {
          k -= numbers[left] - 1;
          left++;
        }
      }

      return right - left;
    }
  }
}
