namespace Problem633
{

  /// <summary>
  /// 633. Sum of Square Numbers
  /// https://leetcode.com/problems/sum-of-square-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 36.6%
  /// 
  /// Math
  /// Two Pointers
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public bool JudgeSquareSum(int c)
    {
      var a = (int)Math.Floor(Math.Sqrt(c));
      var a2 = a * a;
      var b = 0;
      var b2 = b * b;

      while (b <= a)
      {
        var diff = c - a2 - b2;
        if (diff < 0)
        {
          a--;
          a2 = a * a;
        }
        else if (diff > 0)
        {
          b++;
          b2 = b * b;
        }
        else
        {
          return true;
        }
      }

      return false;
    }
  }
}
