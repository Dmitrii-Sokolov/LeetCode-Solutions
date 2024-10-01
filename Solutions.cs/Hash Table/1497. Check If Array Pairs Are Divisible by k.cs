namespace Problem1497
{

  /// <summary>
  /// 1497. Check If Array Pairs Are Divisible by k
  /// https://leetcode.com/problems/check-if-array-pairs-are-divisible-by-k
  /// 
  /// Difficulty Medium
  /// Acceptance 41.8%
  /// 
  /// Array
  /// Hash Table
  /// Counting
  /// </summary>
  public class Solution
  {
    public bool CanArrange(int[] numbers, int divisor)
    {
      var remainders = new int[divisor];
      var sum = 0;
      foreach (var number in numbers)
      {
        var remainder = Mod(number, divisor);
        sum = (sum + remainder) % divisor;
        remainders[remainder]++;
      }

      if (sum != 0)
        return false;

      if (remainders[0] % 2 != 0)
        return false;

      if (divisor % 2 == 0 && remainders[divisor / 2] % 2 != 0)
        return false;

      for (var number = 1; number <= divisor / 2; number++)
      {
        if (remainders[number] != remainders[divisor - number])
          return false;
      }

      return true;
    }

    private static int Mod(int x, int m) => (x % m + m) % m;
  }
}
