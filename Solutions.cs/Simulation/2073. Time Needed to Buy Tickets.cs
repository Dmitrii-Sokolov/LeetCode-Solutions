namespace Problem2073
{

  /// <summary>
  /// 2073. Time Needed to Buy Tickets
  /// https://leetcode.com/problems/time-needed-to-buy-tickets
  /// 
  /// Difficulty Easy
  /// Acceptance 69.9%
  /// 
  /// Array
  /// Queue
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
      var result = 0;
      var needs = tickets[k];

      for (var i = 0; i <= k; i++)
        result += Math.Min(tickets[i], needs);

      for (var i = k + 1; i < tickets.Length; i++)
        result += Math.Min(tickets[i], needs - 1);

      return result;
    }
  }
}
