namespace Problem2683
{

  /// <summary>
  /// 2683. Neighboring Bitwise XOR
  /// https://leetcode.com/problems/neighboring-bitwise-xor
  /// 
  /// Difficulty Medium
  /// Acceptance 74.6%
  /// 
  /// Array
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public bool DoesValidArrayExist(int[] derived)
    {
      var xor = 0;
      foreach (var number in derived)
        xor ^= number;

      return xor == 0;
    }
  }
}
