namespace Problem564
{

  /// <summary>
  /// 564. Find the Closest Palindrome
  /// https://leetcode.com/problems/find-the-closest-palindrome
  /// 
  /// DifficLty Hard
  /// Acceptance 24.5%
  /// 
  /// Math
  /// String
  /// </summary>
  public class Solution
  {
    public string NearestPalindromic(string numberString)
    {
      var number = long.Parse(numberString);
      var candidateAverage = MakePalindromicByPrefix(number, out var high, out var low, out var digit);

      var middle = high == low ? high : high + low;

      var candidateLow = candidateAverage == 11 ? 9 : digit == 0
         ? MakePalindromicByPrefix(candidateAverage - low)
         : candidateAverage - middle;

      var candidateHigh = digit == 9
         ? MakePalindromicByPrefix(candidateAverage + high)
         : candidateAverage + middle;

      var distanceAverage = Math.Abs(number - candidateAverage);
      var distanceLow = Math.Abs(number - candidateLow);
      var distanceHigh = Math.Abs(number - candidateHigh);

      var result =
        distanceAverage != 0 && distanceAverage < distanceLow && distanceAverage <= distanceHigh
          ? candidateAverage
          : distanceLow <= distanceHigh
            ? candidateLow
            : candidateHigh;

      return result.ToString();
    }

    private long MakePalindromicByPrefix(long number) => MakePalindromicByPrefix(number, out _, out _, out _);

    private long MakePalindromicByPrefix(long number, out long high, out long low, out long digit)
    {
      high = 1L;
      while (number / high >= 10)
        high *= 10L;

      low = 1L;
      var palindrome = 0L;
      while (true)
      {
        digit = number / high % 10;

        if (low == high)
        {
          palindrome += digit * low;
          break;
        }
        else
        {
          palindrome += digit * (high + low);
        }

        if (low * 10 == high)
          break;

        high /= 10L;
        low *= 10L;
      }

      return palindrome;
    }
  }
}
