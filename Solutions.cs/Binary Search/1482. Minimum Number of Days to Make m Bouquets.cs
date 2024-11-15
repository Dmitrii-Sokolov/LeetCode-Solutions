namespace Problem1482
{

  /// <summary>
  /// 1482. Minimum Number of Days to Make m Bouquets
  /// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets
  /// 
  /// Difficulty Medium
  /// Acceptance 56.0%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MinDays(int[] bloomDay, int m, int k)
    {
      if (m > bloomDay.Length / k)
        return -1;

      var min = int.MaxValue;
      var max = 0;

      foreach (var d in bloomDay)
      {
        if (d < min)
          min = d;

        if (d > max)
          max = d;
      }

      while (min < max)
      {
        var middle = (min + max) >> 1;

        if (Check(bloomDay, m, k, middle))
        {
          max = middle;
        }
        else
        {
          min = middle + 1;
        }
      }

      return max;
    }

    private static bool Check(int[] bloomDay, int m, int k, int x)
    {
      var adj = 0;
      var n = bloomDay.Length;
      var i = 0;

      while (true)
      {
        while (i < n && bloomDay[i] > x)
        {
          i++;
        }

        if (i >= n)
          return false;

        while (i < n && bloomDay[i] <= x)
        {
          adj++;
          i++;
        }

        m -= adj / k;
        adj = 0;

        if (m <= 0)
          return true;

        if (m > (n - i - 1) / k || i >= n)
          return false;
      }
    }
  }
}
