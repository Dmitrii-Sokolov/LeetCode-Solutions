namespace Problem1523
{

  /// <summary>
  /// 1523. Count Odd Numbers in an Interval Range
  /// https://leetcode.com/problems/count-odd-numbers-in-an-interval-range
  /// 
  /// Difficulty Easy
  /// Acceptance 50.0%
  /// 
  /// Math
  /// </summary>
  public class Solution
  {
    public int CountOdds(int low, int high)
    {
      return (high / 2) - (low / 2) + (high % 2);
    }
  }
}
