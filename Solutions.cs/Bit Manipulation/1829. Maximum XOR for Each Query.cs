namespace Problem1829
{

  /// <summary>
  /// 1829. Maximum XOR for Each Query
  /// https://leetcode.com/problems/maximum-xor-for-each-query
  /// 
  /// Difficulty Medium
  /// Acceptance 81.9%
  /// 
  /// Array
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
      var target = (1 << maximumBit) - 1;
      var result = new int[nums.Length];
      var subXOR = 0;
      for (var i = 0; i < nums.Length; i++)
      {
        subXOR ^= nums[i];
        result[nums.Length - 1 - i] = target ^ subXOR;
      }

      return result;
    }
  }
}
