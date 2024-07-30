namespace Problem238
{

  /// <summary>
  /// 238. Product of Array Except Self
  /// https://leetcode.com/problems/product-of-array-except-self
  /// 
  /// Difficulty Medium
  /// Acceptance 66.5%
  /// 
  /// Array
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int[] ProductExceptSelf(int[] nums)
    {
      var types = new int[31];
      var factors = new int[31];
      var sign = 1;
      for (var i = 0; i < nums.Length; i++)
      {
        var t = Math.Abs(nums[i]);
        types[t]++;
        if (nums[i] != 0)
          sign *= Math.Sign(nums[i]);
      }

      var result = new int[nums.Length];
      if (types[0] >= 2)
        return result;

      for (var i = 0; i < types.Length; i++)
      {
        if (types[i] > 0)
        {
          factors[i] = 1;
          for (var n = 0; n < types.Length; n++)
          {
            for (var k = 0; k < ((n == i) ? types[n] - 1 : types[n]); k++)
              factors[i] *= n;
          }
        }
      }

      for (var i = 0; i < nums.Length; i++)
      {
        var t = Math.Abs(nums[i]);
        if (nums[i] == 0)
        {
          result[i] = factors[t] * sign;
        }
        else
        {
          result[i] = factors[t] * Math.Sign(nums[i]) * sign;
        }
      }

      return result;
    }
  }
}
