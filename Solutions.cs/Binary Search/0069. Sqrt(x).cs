namespace Problem69
{

  /// <summary>
  /// 69. Sqrt(x)
  /// https://leetcode.com/problems/sqrtx
  /// 
  /// Difficulty Easy
  /// Acceptance 39.1%
  /// 
  /// Math
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MySqrt(int x)
    {
      var min = 0;
      var max = 1;
      var test = x;
      while (test > 0)
      {
        test = test >> 2;
        max = max << 1;
      }

      while (min < max)
      {
        var middle = (max + min) >> 1;
        var middle2 = middle * (long)middle;

        if (middle2 < x)
        {
          if (max - min == 1)
            return max * max <= x ? max : min;
          min = middle;
        }
        else if (middle2 > x)
        {
          max = middle - 1;
        }
        else
        {
          return middle;
        }
      }

      return min;
    }
  }
}
