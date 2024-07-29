/// <summary>
/// 1863. Sum of All Subset XOR Totals
/// https://leetcode.com/problems/sum-of-all-subset-xor-totals
/// 
/// Difficulty Easy
/// Acceptance 87.8%
/// 
/// Array
/// Math
/// Backtracking
/// Bit Manipulation
/// Combinatorics
/// Enumeration
/// </summary>
class Solution
{
  public int subsetXORSum(int[] nums)
  {
    this.nums = nums;
    return Check(0, 0);
  }

  private int[] nums;

  private int Check(int xor, int index)
  {
    if (index == nums.length)
    {
      return xor;
    }

    return Check(xor ^ nums[index], index + 1) + Check(xor, index + 1);
  }
}
