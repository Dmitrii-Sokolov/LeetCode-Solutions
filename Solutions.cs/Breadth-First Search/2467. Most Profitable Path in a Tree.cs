namespace Problem2467
{

  /// <summary>
  /// 2467. Most Profitable Path in a Tree
  /// https://leetcode.com/problems/most-profitable-path-in-a-tree/description/?envType=daily-question&envId=2025-02-24
  /// 
  /// Difficulty Medium
  /// Acceptance 59.3%
  /// 
  /// Array
  /// Tree
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// </summary>
  public class Solution
  {
    public int MostProfitablePath(int[][] edgesRaw, int bob, int[] amount)
    {
      var edges = ConstructEdges(edgesRaw);

      var bobPath = ComputeBobPath(edges, bob, amount);

      return ComputeAliceProfit(edges, amount, bobPath);
    }

    private int ComputeAliceProfit(Dictionary<int, List<int>> edges, int[] amount, Dictionary<int, int> bobPath)
    {
      Span<bool> visited = stackalloc bool[amount.Length];
      var maxProfit = int.MinValue;
      var step = -1;
      var queue = new Queue<(int Node, int Profit)>();
      queue.Enqueue((0, 0));
      while (queue.Count > 0)
      {
        step++;
        var count = queue.Count;
        while (count-- > 0)
        {
          var (node, profit) = queue.Dequeue();
          visited[node] = true;
          if (bobPath.TryGetValue(node, out var bobStep))
          {
            if (bobStep == step)
            {
              profit += amount[node] / 2;
            }
            else if (bobStep >= step)
            {
              profit += amount[node];
            }
          }
          else
          {
            profit += amount[node];
          }

          var neighbors = edges[node];
          if (neighbors.Count == 1 && node != 0)
          {
            if (maxProfit < profit)
              maxProfit = profit;
          }

          foreach (var next in neighbors)
          {
            if (!visited[next])
              queue.Enqueue((next, profit));
          }
        }
      }

      return maxProfit;
    }

    private static Dictionary<int, int> ComputeBobPath(Dictionary<int, List<int>> edges, int bob, int[] amount)
    {
      Span<int> origins = stackalloc int[amount.Length];
      origins[0] = -2;
      for (var i = 1; i < amount.Length; i++)
        origins[i] = -1;

      var queue = new Queue<int>();
      queue.Enqueue(0);
      while (queue.Count > 0 && origins[bob] == -1)
      {
        var count = queue.Count;
        while (count-- > 0 && origins[bob] == -1)
        {
          var node = queue.Dequeue();
          var neighbors = edges[node];
          foreach (var next in neighbors)
          {
            if (origins[next] == -1)
            {
              origins[next] = node;
              queue.Enqueue(next);
            }
          }
        }
      }

      var step = 0;
      var path = new Dictionary<int, int>();
      var current = bob;
      while (current != -2)
      {
        path[current] = step++;
        current = origins[current];
      }

      return path;
    }

    private static Dictionary<int, List<int>> ConstructEdges(int[][] edgesRaw)
    {
      var edges = new Dictionary<int, List<int>>();
      foreach (var edge in edgesRaw)
        Connect(edges, edge);

      return edges;
    }

    private static void Connect(Dictionary<int, List<int>> edges, int[] edge)
    {
      Connect(edges, edge[0], edge[1]);
      Connect(edges, edge[1], edge[0]);
    }

    private static void Connect(Dictionary<int, List<int>> edges, int a, int b)
    {
      if (!edges.TryGetValue(a, out var listA))
      {
        listA = [];
        edges[a] = listA;
      }

      listA.Add(b);
    }
  }
}
