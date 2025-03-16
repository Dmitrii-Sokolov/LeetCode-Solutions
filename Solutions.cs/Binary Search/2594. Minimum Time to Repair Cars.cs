namespace Problem2594
{

  /// <summary>
  /// 2594. Minimum Time to Repair Cars
  /// https://leetcode.com/problems/minimum-time-to-repair-cars
  /// 
  /// Difficulty Medium
  /// Acceptance 54.2%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public long RepairCars(int[] ranksRaw, int cars)
    {
      var ranks = new int[101];
      var maxRank = int.MinValue;
      var minRank = int.MaxValue;
      foreach (var rank in ranksRaw)
      {
        ranks[rank]++;

        if (maxRank < rank)
          maxRank = rank;

        if (minRank > rank)
          minRank = rank;
      }

      var mechanicsCount = ranksRaw.Length;
      var carsPerMechanic = cars / mechanicsCount;
      var minMinutes = (long)minRank * carsPerMechanic * carsPerMechanic;
      var maxMinutes = (long)maxRank * (carsPerMechanic + 1) * (carsPerMechanic + 1);
      return FindMin(minMinutes, maxMinutes, c => Check(c, ranks, cars));
    }

    private static bool Check(long c, int[] ranks, int cars)
    {
      for (var i = 1; i < ranks.Length; i++)
      {
        cars -= ranks[i] * (int)Math.Sqrt(c / i);

        if (cars <= 0)
          return true;
      }

      return false;
    }

    private static long FindMin(long min, long max, Func<long, bool> check)
    {
      while (max > min)
      {
        var middle = max + min >> 1;
        if (check(middle))
        {
          max = middle;
        }
        else
        {
          min = middle + 1;
        }
      }

      return min;
    }
  }
}
