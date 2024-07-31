namespace Problem2997
{

  /// <summary>
  /// 2997. Minimum Number of Operations to Make Array XOR Equal to K
  /// https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k
  /// 
  /// Difficulty Medium
  /// Acceptance 86.4%
  /// 
  /// Array
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int MinOperations(int[] nums, int k)
    {
      foreach (var num in nums)
        k ^= num;

      var result = 0;
      while (k > 0)
      {
        result += k % 2;
        k /= 2;
      }

      return result;
    }
  }
}
