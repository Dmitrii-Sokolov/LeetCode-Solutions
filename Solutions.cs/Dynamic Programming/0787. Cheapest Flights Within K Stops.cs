namespace Problem787
{

  /// <summary>
  /// 787. Cheapest Flights Within K Stops
  /// https://leetcode.com/problems/cheapest-flights-within-k-stops
  /// 
  /// Difficulty Medium
  /// Acceptance 39.5%
  /// 
  /// Dynamic Programming
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// Heap (Priority Queue)
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
      var costs = new int[n];
      for (var p = 0; p < n; p++)
        costs[p] = -1;

      costs[src] = 0;

      for (var i = 0; i < k + 1; i++)
      {
        var costs_new = new int[n];
        for (var p = 0; p < n; p++)
          costs_new[p] = costs[p];

        foreach (var flight in flights)
        {
          var from = flight[0];
          var to = flight[1];
          var price = flight[2];
          var cost = costs[from];

          if (cost != -1)
          {
            var newCost = price + cost;
            if (costs_new[to] == -1)
            {
              costs_new[to] = newCost;
            }
            else
            {
              costs_new[to] = Math.Min(newCost, costs_new[to]);
            }
          }
        }

        costs = costs_new;
      }

      return costs[dst];
    }
  }
}
