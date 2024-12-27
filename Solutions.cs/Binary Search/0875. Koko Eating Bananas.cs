namespace Problem0875
{

  /// <summary>
  /// 875. Koko Eating Bananas
  /// https://leetcode.com/problems/koko-eating-bananas/description/
  /// 
  /// Difficulty Medium
  /// Acceptance 48.7%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MinEatingSpeed(int[] piles, int h)
    {
      if (piles.Length == h)
        return piles.Max();

      var sum = 0L;
      foreach (var pile in piles)
        sum += pile;

      var min = DivCeil(sum - 1, h);

      // Worst case: 
      // pilesCount hours for 1 banana each
      // then (h - pilesCount) hours for max banana each
      // sum = pilesCount * 1 + (h - pilesCount) * max
      // sum - pilesCount = (h - pilesCount) * max
      // max = (sum - pilesCount) / (h - pilesCount)
      var max = DivCeil(sum - piles.Length, h - piles.Length);

      return FindMin((int)min, (int)max, candidate =>
      {
        var test = h;
        foreach (var pile in piles)
        {
          test -= DivCeil(pile, candidate);
          if (test < 0)
            return false;
        }

        return true;
      });
    }

    private static int DivCeil(int a, int b) => 1 + (a - 1) / b;
    private static long DivCeil(long a, long b) => 1 + (a - 1) / b;

    // Find first that's appropriate
    private static int FindMin(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = (int)(max + (long)min >> 1);
        if (check(middle))
          max = middle;
        else
        {
          min = middle + 1;
        }
      }

      return min;
    }
  }
}
