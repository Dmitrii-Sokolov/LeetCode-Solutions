namespace Problem2226
{

  /// <summary>
  /// 2226. Maximum Candies Allocated to K Children
  /// https://leetcode.com/problems/maximum-candies-allocated-to-k-children
  /// 
  /// Difficulty Medium
  /// Acceptance 43.4%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MaximumCandies(int[] candies, long k)
    {
      var max = 0;
      foreach (var count in candies)
      {
        if (max < count)
          max = count;
      }

      return FindMax(0, max, c => Check(c, candies, k));
    }

    private bool Check(int c, int[] candies, long k)
    {
      foreach (var count in candies)
        k -= count / c;

      return k <= 0;
    }

    private static int FindMax(int min, int max, Func<int, bool> check)
    {
      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (check(middle))
        {
          min = middle;
        }
        else
        {
          max = middle - 1;
        }
      }

      return min;
    }
  }
}
