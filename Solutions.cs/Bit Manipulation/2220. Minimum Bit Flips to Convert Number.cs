namespace Problem2220
{

  /// <summary>
  /// 2220. Minimum Bit Flips to Convert Number
  /// https://leetcode.com/problems/minimum-bit-flips-to-convert-number
  /// 
  /// Difficulty Easy
  /// Acceptance 86.6%
  /// 
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int MinBitFlips(int start, int goal)
    {
      var difference = start ^ goal;
      var result = 0;
      while (difference > 0)
      {
        result += difference % 2;
        difference /= 2;
      }

      return result;
    }
  }
}
