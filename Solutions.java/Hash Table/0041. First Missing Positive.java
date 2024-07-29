/// <summary>
/// 41. First Missing Positive
/// https://leetcode.com/problems/first-missing-positive
/// 
/// Difficulty Hard
/// Acceptance 39.8%
/// 
/// Array
/// Hash Table
/// </summary>
class Solution
{
  public int firstMissingPositive(int[] nums)
  {
      var max = nums.length;
      for(var i = 0; i < max; i++)
      {
          if (nums[i] <= 0)
              nums[i] = max + 1;
      }

      for(var i = 0; i < max; i++)
      {
          var num = Math.abs(nums[i]);
          if (1 <= num && num <= max)
          {
              if (nums[num - 1] > 0)
                  nums[num - 1] *= -1;
          }
      }

      for(var i = 0; i < max; i++)
      {
          if (nums[i] > 0)
              return i + 1;
      }

      return max + 1;        
  }
}
