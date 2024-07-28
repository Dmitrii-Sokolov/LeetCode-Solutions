namespace Problem2778
{

  /// <summary>
  /// 2778. Sum of Squares of Special Elements 
  /// https://leetcode.com/problems/sum-of-squares-of-special-elements/description/
  /// 
  /// Difficulty Easy 81.4%
  /// 
  /// Array
  /// Enumeration
  /// </summary>
  class Solution
  {
    public int sumOfSquares(int[] nums)
    {
      var result = 0;

      for (var i = 0; i < nums.length; i++)
      {
        if (nums.length % (i + 1) == 0)
        {
          result += nums[i] * nums[i];
        }
      }

      return result;
    }
  }
}
