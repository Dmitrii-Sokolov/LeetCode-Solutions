namespace Problem201
{

  /// <summary>
  /// 201. Bitwise AND of Numbers Range
  /// https://leetcode.com/problems/bitwise-and-of-numbers-range
  /// 
  /// Difficulty Medium
  /// Acceptance 47.1%
  /// 
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int RangeBitwiseAnd(int left, int right)
    {
      var firstBit = false;
      var result = 0;

      for (var i = 31; i >= 0; i--)
      {
        var digit = 1 << i;
        var digitInLeft = (left & digit) > 0;
        var digitInRight = (right & digit) > 0;

        if (!firstBit)
        {
          if (digitInLeft && digitInRight)
          {
            firstBit = true;
            result = digit;
          }
          else if (digitInLeft != digitInRight)
          {
            return 0;
          }
        }
        else
        {
          if (digitInLeft && digitInRight)
          {
            result += digit;
          }
          else if (!digitInLeft && !digitInRight)
          {
          }
          else
          {
            return result;
          }
        }
      }

      return result;
    }
  }
}
