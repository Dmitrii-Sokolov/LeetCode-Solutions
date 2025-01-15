namespace Problem2429
{

  /// <summary>
  /// 2429. Minimize XOR
  /// https://leetcode.com/problems/minimize-xor
  /// 
  /// Difficulty Medium
  /// Acceptance 54.9%
  /// 
  /// Greedy
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int MinimizeXor(int num1, int num2)
    {
      var result = 0;
      var bitsCount = CountBits(num2);
      var pointer = 1 << 30;
      while (bitsCount > 0 && pointer != 0)
      {
        if ((num1 & pointer) > 0)
        {
          result |= pointer;
          bitsCount--;
        }

        pointer >>= 1;
      }

      pointer = 1;
      while (bitsCount > 0)
      {
        if ((num1 & pointer) == 0)
        {
          result |= pointer;
          bitsCount--;
        }

        pointer <<= 1;
      }

      return result;
    }

    private static int CountBits(int number)
    {
      var result = 0;
      while (number > 0)
      {
        result += number & 1;
        number >>= 1;
      }

      return result;
    }
  }
}
