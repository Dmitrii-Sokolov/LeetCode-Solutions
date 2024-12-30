namespace Problem2466
{

  /// <summary>
  /// 2466. Count Ways To Build Good Strings
  /// https://leetcode.com/problems/count-ways-to-build-good-strings
  /// 
  /// Difficulty Medium
  /// Acceptance 56.2%
  /// 
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    private const long Modulo = 1000_000_007L;

    public int CountGoodStrings(int low, int high, int zero, int one)
    {
      var counts = new long[high + 1];
      counts[0] = 1;

      var (stepBig, stepSmall) = zero > one ? (zero, one) : (one, zero);
      for (var i = 0; i <= high - stepBig; i++)
      {
        counts[i + stepSmall] = (counts[i + stepSmall] + counts[i]) % Modulo;
        counts[i + stepBig] = (counts[i + stepBig] + counts[i]) % Modulo;
      }

      for (var i = high - stepBig + 1; i <= high - stepSmall; i++)
        counts[i + stepSmall] = (counts[i + stepSmall] + counts[i]) % Modulo;

      var result = 0L;

      for (var i = low; i <= high; i++)
        result = (result + counts[i]) % Modulo;

      return (int)result;
    }
  }
}
