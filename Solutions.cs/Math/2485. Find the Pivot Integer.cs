namespace Problem2485
{

  /// <summary>
  /// 2485. Find the Pivot Integer
  /// https://leetcode.com/problems/find-the-pivot-integer
  /// 
  /// Difficulty Easy
  /// Acceptance 83.9%
  /// 
  /// Math
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int PivotInteger(int n)
    {
      var pivot = (int)Math.Round(Math.Sqrt(((n * n) + n) / 2));
      if ((pivot * pivot) + pivot == (pivot + n) * (n - pivot + 1))
        return pivot;

      return -1;
    }
  }
}
