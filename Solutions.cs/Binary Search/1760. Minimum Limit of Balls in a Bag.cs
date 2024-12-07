namespace Problem1760
{

  /// <summary>
  /// 1760. Minimum Limit of Balls in a Bag
  /// https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag
  /// 
  /// Difficulty Medium
  /// Acceptance 63.3%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MinimumSize(int[] numbers, int maxOperations)
      => FindMin(1, 1000_000_000, candidate => Check(candidate, numbers, maxOperations));

    private static bool Check(int candidate, int[] numbers, int operations)
    {
      foreach (var number in numbers)
      {
        if (number > candidate)
        {
          operations -= (number - 1) / candidate;

          if (operations < 0)
            return false;
        }
      }

      return true;
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
