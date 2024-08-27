namespace Problem1514
{

  /// <summary>
  /// 1514. Path with Maximum Probability
  /// https://leetcode.com/problems/path-with-maximum-probability
  /// 
  /// Difficulty Medium
  /// Acceptance 57.3%
  /// 
  /// Array
  /// Graph
  /// Heap(Priority Queue)
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public double MaxProbability(int n, int[][] edgesRaw, double[] succProb, int start, int end)
    {
      var edges = new List<(int Node, double Probability)>[n];
      for (var i = 0; i < edgesRaw.Length; i++)
      {
        var a = edgesRaw[i][0];
        var b = edgesRaw[i][1];
        var p = succProb[i];

        if (edges[a] == null)
          edges[a] = [];

        if (edges[b] == null)
          edges[b] = [];

        edges[a].Add((b, p));
        edges[b].Add((a, p));
      }

      var results = new double[n];
      results[start] = 1d;
      var queue = new Queue<int>();
      queue.Enqueue(start);
      while (queue.TryDequeue(out var from))
      {
        if (edges[from] == null)
          continue;

        foreach (var (node, probability) in edges[from])
        {
          var test = results[from] * probability;
          if (results[node] < test)
          {
            results[node] = test;
            queue.Enqueue(node);
          }
        }
      }

      return results[end];
    }
  }
}
