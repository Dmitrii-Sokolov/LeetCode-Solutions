namespace Problem2064
{

  /// <summary>
  /// 2064. Minimized Maximum of Products Distributed to Any Store
  /// https://leetcode.com/problems/minimized-maximum-of-products-distributed-to-any-store
  /// 
  /// Difficulty Medium
  /// Acceptance 57.3%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MinimizedMaximum(int n, int[] quantities)
    {
      return FindMin(1, quantities.Max(), Check);
      bool Check(int candidate)
      {
        var test = n;
        foreach (var quantity in quantities)
        {
          test -= 1 + (quantity - 1) / candidate;

          if (test < 0)
            return false;
        }

        return true;
      }
    }

    // Find first that's appropriate
    private static int FindMin(int min, int max, Func<int, bool> check)
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
