namespace Problem1863
{

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
  public class Solution
  {
    public int SubsetXORSum(int[] nums)
    {
      Nums = nums;
      return Check(0, 0);
    }

    private int[] Nums;

    private int Check(int xor, int index)
    {
      if (index == Nums.Length)
        return xor;

      return Check(xor ^ Nums[index], index + 1) + Check(xor, index + 1);
    }
  }
}
