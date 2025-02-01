namespace Problem2493
{

  /// <summary>
  /// 2493. Divide Nodes Into the Maximum Number of Groups
  /// https://leetcode.com/problems/divide-nodes-into-the-maximum-number-of-groups
  /// 
  /// Difficulty Hard
  /// Acceptance 56.9%
  /// 
  /// Breadth-First Search
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public int MagnificentSets(int n, int[][] edges)
    {
      var result = 0;

      var graph = new List<int>[n];
      for (var i = 0; i < n; i++)
        graph[i] = [];

      foreach (var edge in edges)
      {
        var node0 = edge[0] - 1;
        var node1 = edge[1] - 1;
        graph[node0].Add(node1);
        graph[node1].Add(node0);
      }

      var queue = new Queue<int>();
      Span<bool> visited = stackalloc bool[n];
      Span<int> states = stackalloc int[n];
      Span<int> subgraph = stackalloc int[n];
      var subgraphSize = 0;
      for (var i = 0; i < n; i++)
      {
        if (!visited[i])
        {
          subgraphSize = 0;
          queue.Enqueue(i);
          states[i] = 1;
          while (queue.Count > 0)
          {
            var count = queue.Count;
            while (count-- > 0)
            {
              var node = queue.Dequeue();
              subgraph[subgraphSize++] = node;
              visited[node] = true;
              foreach (var next in graph[node])
              {
                if (states[next] == 0)
                {
                  states[next] = -states[node];
                  queue.Enqueue(next);
                }
                else if (states[next] == states[node])
                {
                  return -1;
                }
              }
            }
          }

          var diameter = 0;
          for (var k = 0; k < subgraphSize; k++)
          {
            for (var j = 0; j < subgraphSize; j++)
              visited[subgraph[j]] = false;

            var start = subgraph[k];
            visited[start] = true;
            queue.Enqueue(start);
            var chord = 0;
            while (queue.Count > 0)
            {
              var count = queue.Count;
              chord++;
              while (count-- > 0)
              {
                var node = queue.Dequeue();
                foreach (var next in graph[node])
                {
                  if (!visited[next])
                  {
                    visited[next] = true;
                    queue.Enqueue(next);
                  }
                }
              }
            }

            if (diameter < chord)
              diameter = chord;
          }

          result += diameter;
        }
      }

      return result;
    }
  }
}
