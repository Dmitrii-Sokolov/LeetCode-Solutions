namespace Problem122
{

  /// <summary>
  /// 122. Best Time to Buy and Sell Stock II
  /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 67.2%
  /// 
  /// Array
  /// Dynamic Programming
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MaxProfit(int[] prices)
    {
      var result = 0;

      for (var i = 0; i < prices.Length - 1; i++)
      {
        var delta = prices[i + 1] - prices[i];
        if (delta > 0)
          result += delta;
      }

      return result;
    }
  }
}
