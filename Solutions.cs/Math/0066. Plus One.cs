namespace Problem66
{

  /// <summary>
  /// 66. Plus One
  /// https://leetcode.com/problems/plus-one
  /// 
  /// Difficulty Easy
  /// Acceptance 45.8%
  /// 
  /// Array
  /// Math
  /// </summary>
  public class Solution
  {
    public int[] PlusOne(int[] digits)
    {

      var pos = digits.Length - 1;
      var shift = 0;

      while (pos >= 0)
      {
        if (digits[pos] < 9)
        {
          digits[pos]++;
          return digits;
        }

        digits[pos--] = 0;
      }

      var result = new int[digits.Length + 1];
      result[0] = 1;

      return result;
    }
  }
}
