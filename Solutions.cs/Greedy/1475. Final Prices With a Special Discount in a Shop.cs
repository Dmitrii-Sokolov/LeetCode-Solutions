namespace Problem1475
{

  /// <summary>
  /// 1475. Final Prices With a Special Discount in a Shop
  /// https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop
  /// 
  /// Difficulty Easy
  /// Acceptance 80.4%
  /// 
  /// Array
  /// Stack
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public int[] FinalPrices(int[] prices)
    {
      for (var i = 0; i < prices.Length; i++)
      {
        var discount = 0;
        for (var j = i + 1; j < prices.Length; j++)
        {
          if (prices[j] <= prices[i])
          {
            discount = prices[j];
            break;
          }
        }

        prices[i] -= discount;
      }

      return prices;
    }
  }
}
