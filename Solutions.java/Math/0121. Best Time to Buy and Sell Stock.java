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
class Solution
{
  public int maxProfit(int[] prices)
  {
    var min = Integer.MAX_VALUE;
    var result = 0;

    for (var p : prices)
    {
      min = Math.min(min, p);
      result = Math.max(p - min, result);
    }

    return result;

  }
}
