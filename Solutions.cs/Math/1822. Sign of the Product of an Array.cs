namespace Problem1822
{

  /// <summary>
  /// 1822. Sign of the Product of an Array
  /// https://leetcode.com/problems/sign-of-the-product-of-an-array
  /// 
  /// Difficulty Easy
  /// Acceptance 65.3%
  /// 
  /// Array
  /// Math
  /// </summary>
  public class Solution
  {
    public int ArraySign(int[] nums)
    {
      var result = 1;

      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] == 0)
          return 0;
        else if (nums[i] < 0)
        {
          result = -result;
        }
      }

      return result;
    }
  }
}
