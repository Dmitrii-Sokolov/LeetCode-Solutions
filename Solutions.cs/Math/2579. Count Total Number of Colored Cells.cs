namespace Problem2579
{

  /// <summary>
  /// 2579. Count Total Number of Colored Cells
  /// https://leetcode.com/problems/count-total-number-of-colored-cells
  /// 
  /// Difficulty Medium
  /// Acceptance 64.3%
  /// 
  /// Math
  /// </summary>
  public class Solution
  {
    public long ColoredCells(long n) => n * (n - 1) * 2 + 1;
  }
}
