namespace Problem121
{

  /// <summary>
  /// 121. Best Time to Buy and Sell Stock
  /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock
  /// 
  /// Difficulty Easy
  /// Acceptance 53.9%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MaxProfit(int[] prices)
    {
      var min = int.MaxValue;
      var result = 0;

      foreach (var p in prices)
      {
        min = Math.Min(min, p);
        result = Math.Max(p - min, result);
      }

      return result;
    }
  }
}
