namespace Problem268
{

  /// <summary>
  /// 268. Missing Number
  /// https://leetcode.com/problems/missing-number
  /// 
  /// Difficulty Easy
  /// Acceptance 67.6%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Binary Search
  /// Bit Manipulation
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MissingNumber(int[] nums)
    {
      var n = 0;
      while (n < nums.Length)
      {
        while (n < nums.Length && (nums[n] < 0 || nums[n] >= nums.Length))
          n++;

        if (n == nums.Length)
          break;

        var next = nums[n];
        while (next >= 0 && next < nums.Length)
        {
          var m = nums[next];
          nums[next] = -1;
          next = m;
        }
        n++;
      }

      n = 0;
      while (n < nums.Length)
      {
        if (nums[n] == -1)
        {
          n++;
        }
        else
        {
          return n;
        }
      }

      return nums.Length;
    }
  }
}
