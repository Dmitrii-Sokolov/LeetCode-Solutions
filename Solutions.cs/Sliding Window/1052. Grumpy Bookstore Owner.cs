namespace Problem1052
{

  /// <summary>
  /// 1052. Grumpy Bookstore Owner
  /// https://leetcode.com/problems/grumpy-bookstore-owner
  /// 
  /// Difficulty Medium
  /// Acceptance 64.3%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
      var good = 0;
      var current = 0;
      for (var i = 0; i < minutes; i++)
      {
        if (grumpy[i] == 0)
        {
          good += customers[i];
          customers[i] = 0;
        }

        current += customers[i];
      }

      var max = current;
      for (var i = minutes; i < customers.Length; i++)
      {
        if (grumpy[i] == 0)
        {
          good += customers[i];
          customers[i] = 0;
        }

        current += customers[i];
        current -= customers[i - minutes];
        max = Math.Max(max, current);
      }

      return max + good;
    }
  }
}
