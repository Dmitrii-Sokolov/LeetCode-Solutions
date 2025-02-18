namespace Problem2375
{

  /// <summary>
  /// 2375. Construct Smallest Number From DI String
  /// https://leetcode.com/problems/construct-smallest-number-from-di-string
  /// 
  /// Difficulty Medium
  /// Acceptance 81.5%
  /// 
  /// String
  /// Backtracking
  /// Stack
  /// Greedy
  /// </summary>
  public class Solution
  {
    public string SmallestNumber(string pattern)
    {
      var result = new char[pattern.Length + 1];

      Proceed(new bool[10], result, pattern, 0, 0);

      return new string(result);
    }

    private static bool Proceed(bool[] usedDigits, char[] result, string pattern, int position, int previousDigit)
    {
      if (position == result.Length)
        return true;

      var (from, to) = position == 0
        ? (1, 9)
        : pattern[position - 1] == 'I'
          ? (previousDigit + 1, 9)
          : (1, previousDigit - 1);
      for (var digit = from; digit <= to; digit++)
      {
        if (!usedDigits[digit])
        {
          usedDigits[digit] = true;
          result[position] = (char)('0' + digit);

          if (Proceed(usedDigits, result, pattern, position + 1, digit))
            return true;

          usedDigits[digit] = false;
        }
      }

      return false;
    }
  }
}
