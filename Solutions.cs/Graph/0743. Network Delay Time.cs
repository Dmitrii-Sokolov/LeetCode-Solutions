namespace Problem743
{

  /// <summary>
  /// 743. Network Delay Time
  /// https://leetcode.com/problems/network-delay-time
  /// 
  /// Difficulty Medium
  /// Acceptance 54.9%
  /// 
  /// Depth-First Search
  /// Breadth - First Search
  /// Graph
  /// Heap (Priority Queue)
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public int NetworkDelayTime(int[][] times, int count, int k)
    {
      var edges = new Dictionary<int, List<(int Node, int Delay)>>();
      foreach (var time in times)
      {
        var a = time[0];
        var b = time[1];
        var t = time[2];

        AddEdge(edges, a, b, t);
      }

      var visited = new HashSet<int>();
      var queue = new PriorityQueue<int, int>();
      queue.Enqueue(k, 0);
      while (queue.TryDequeue(out var node, out var delay))
      {
        if (visited.Contains(node))
          continue;

        visited.Add(node);

        if (visited.Count == count)
          return delay;

        if (edges.TryGetValue(node, out var neighbours))
        {
          foreach (var neighbour in neighbours)
            queue.Enqueue(neighbour.Node, neighbour.Delay + delay);
        }
      }

      return -1;
    }

    private static void AddEdge(Dictionary<int, List<(int Node, int Delay)>> edges, int from, int to, int delay)
    {
      if (!edges.TryGetValue(from, out var list))
      {
        list = [];
        edges.Add(from, list);
      }

      list.Add((to, delay));
    }
  }
}
