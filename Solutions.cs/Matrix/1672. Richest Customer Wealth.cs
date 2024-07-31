namespace Problem1672
{

  /// <summary>
  /// 1672. Richest Customer Wealth
  /// https://leetcode.com/problems/richest-customer-wealth
  /// 
  /// Difficulty Easy
  /// Acceptance 88.1%
  /// 
  /// Array
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int MaximumWealth(int[][] accounts)
    {
      var result = 0;
      for (var i = 0; i < accounts.Length; i++)
      {
        var wealth = 0;
        for (var k = 0; k < accounts[i].Length; k++)
          wealth += accounts[i][k];
        result = Math.Max(wealth, result);
      }

      return result;
    }
  }
}
