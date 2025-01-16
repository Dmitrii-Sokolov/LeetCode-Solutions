namespace Problem2425
{

  /// <summary>
  /// 2425. Bitwise XOR of All Pairings
  /// https://leetcode.com/problems/bitwise-xor-of-all-pairings
  /// 
  /// Difficulty Medium
  /// Acceptance 63.3%
  /// 
  /// Array
  /// Bit Manipulation
  /// Brainteaser
  /// </summary>
  public class Solution
  {
    public int XorAllNums(int[] nums1, int[] nums2)
    {
      var result = 0;
      if ((nums1.Length & 1) == 1)
      {
        foreach (var number in nums2)
          result ^= number;
      }

      if ((nums2.Length & 1) == 1)
      {
        foreach (var number in nums1)
          result ^= number;
      }

      return result;
    }
  }
}
