namespace Problem3151
{

  /// <summary>
  /// 3151. Special Array I
  /// https://leetcode.com/problems/special-array-i
  /// 
  /// Difficulty Easy
  /// Acceptance 79.3%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public bool IsArraySpecial(int[] numbers)
    {
      var bit = numbers[0] & 1;

      for (var i = 1; i < numbers.Length; i++)
      {
        if ((numbers[i] + i & 1) != bit)
          return false;
      }

      return true;
    }
  }
}
