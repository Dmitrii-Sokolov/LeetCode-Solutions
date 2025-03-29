namespace Problem2523
{

  /// <summary>
  /// 2523. Closest Prime Numbers in Range
  /// https://leetcode.com/problems/closest-prime-numbers-in-range
  /// 
  /// Difficulty Medium
  /// Acceptance 45.7%
  /// 
  /// Math
  /// Number Theory
  /// </summary>
  public class Solution
  {
    public int[] ClosestPrimes(int left, int right)
    {
      if (left <= 2 && right >= 3)
        return [2, 3];

      if (right - left < 2)
        return [-1, -1];

      var lastPrime = 0;
      var result = (int[])[-1, -1];
      var minDifference = int.MaxValue;
      for (var number = left; number <= right; number++)
      {
        if (IsPrime(number))
        {
          if (lastPrime != 0 && number - lastPrime < minDifference)
          {
            minDifference = number - lastPrime;
            result = [lastPrime, number];

            if (minDifference == 2)
              return result;
          }

          lastPrime = number;
        }
      }

      return result;
    }

    private static bool IsPrime(int number)
    {
      if (number == 3)
        return true;

      if (number % 2 == 0 || number % 3 == 0)
        return false;

      for (var i = 5; i * i <= number; i += 6)
      {
        if (number % i == 0 || number % (i + 2) == 0)
          return false;
      }

      return true;
    }
  }
}
