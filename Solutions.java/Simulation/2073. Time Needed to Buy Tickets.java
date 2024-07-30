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
class Solution
{
  public int timeRequiredToBuy(int[] tickets, int k)
  {
    var result = 0;
    var needs = tickets[k];

    for (var i = 0; i <= k; i++)
      result += Math.min(tickets[i], needs);

    for (var i = k + 1; i < tickets.length; i++)
      result += Math.min(tickets[i], needs - 1);

    return result;
  }
}
