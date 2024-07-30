namespace Problem1642
{

  /// <summary>
  /// 1642. Furthest Building You Can Reach
  /// https://leetcode.com/problems/furthest-building-you-can-reach
  /// 
  /// Difficulty Medium
  /// Acceptance 49.8%
  /// 
  /// Array
  /// Greedy
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
      var costs = new PriorityQueue<int, int>();
      for (var i = 0; i < heights.Length - 1; i++)
      {
        var cost = heights[i + 1] - heights[i];
        if (cost <= 0)
          continue;

        costs.Enqueue(cost, cost);

        if (ladders > 0)
        {
          ladders--;
        }
        else
        {
          bricks -= costs.Dequeue();

          if (bricks < 0)
            return i;
        }
      }

      return heights.Length - 1;
    }
  }
}
