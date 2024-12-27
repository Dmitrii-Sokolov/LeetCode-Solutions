namespace Problem2699
{

  /// <summary>
  /// 2699. Modify Graph Edge Weights
  /// https://leetcode.com/problems/modify-graph-edge-weights
  /// 
  /// Difficulty Hard
  /// Acceptance 43.0%
  /// 
  /// Graph
  /// Heap(Priority Queue)
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public int[][] ModifiedGraphEdges(int n, int[][] edgesRaw, int source, int target, int desiredLength)
    {
      var edges = Enumerable.Range(0, n).Select(_ => new List<(int Node, int Weight)>()).ToArray();
      foreach (var edge in edgesRaw)
      {
        var a = edge[0];
        var b = edge[1];
        var w = edge[2];

        edges[a].Add((b, w));
        edges[b].Add((a, w));
      }

      var unmodifiedPath = FindMinUnmodifiedPath(source, target, edges, desiredLength, desiredLength);
      if (unmodifiedPath == desiredLength)
      {
        // Any modification is appropriate
        foreach (var edge in edgesRaw)
        {
          if (edge[2] == -1)
            edge[2] = desiredLength;
        }

        return edgesRaw;
      }
      else if (unmodifiedPath < desiredLength)
      {
        // Any modification is not appropriate
        return [];
      }

      var onesPath = FindMinUnmodifiedPath(source, target, edges, desiredLength, 1);
      if (onesPath > desiredLength)
        // Any modification is too large
        return [];

      var distancesToSource = Enumerable.Repeat(int.MaxValue, n).ToArray();
      distancesToSource[source] = 0;
      ComputeDistances(source, edges, distancesToSource);

      var distancesToTarget = Enumerable.Repeat(int.MaxValue, n).ToArray();
      distancesToTarget[target] = 0;
      ComputeDistances(target, edges, distancesToTarget);

      foreach (var edge in edgesRaw)
      {
        var a = edge[0];
        var b = edge[1];
        var w = edge[2];

        if (w == -1)
        {
          var weight = 1;

          if (distancesToSource[a] != int.MaxValue && distancesToTarget[b] != int.MaxValue)
          {
            if (weight < desiredLength - distancesToSource[a] - distancesToTarget[b])
              weight = desiredLength - distancesToSource[a] - distancesToTarget[b];
          }

          (a, b) = (b, a);

          if (distancesToSource[a] != int.MaxValue && distancesToTarget[b] != int.MaxValue)
          {
            if (weight < desiredLength - distancesToSource[a] - distancesToTarget[b])
              weight = desiredLength - distancesToSource[a] - distancesToTarget[b];
          }

          edge[2] = weight;

          ModifyWeight(a, b, weight, edges);
          ModifyWeight(b, a, weight, edges);

          ComputeDistances(a, edges, distancesToSource);
          ComputeDistances(a, edges, distancesToTarget);
          ComputeDistances(b, edges, distancesToSource);
          ComputeDistances(b, edges, distancesToTarget);
        }
      }

      return edgesRaw;
    }

    private static void ModifyWeight(int from, int to, int weight, List<(int Node, int Weight)>[] edges)
    {
      for (var i = 0; i < edges[from].Count; i++)
      {
        var edge = edges[from][i];
        if (edge.Node == to)
        {
          edge.Weight = weight;
          edges[from][i] = edge;
          return;
        }
      }
    }

    private static void ComputeDistances(int from, List<(int Node, int Weight)>[] edges, int[] distances)
    {
      if (distances[from] == int.MaxValue)
        return;

      var queue = new Queue<int>();
      queue.Enqueue(from);
      while (queue.TryDequeue(out var node))
      {
        foreach (var neighbour in edges[node])
        {
          if (neighbour.Weight > 0)
          {
            if (distances[neighbour.Node] > distances[node] + neighbour.Weight)
            {
              distances[neighbour.Node] = distances[node] + neighbour.Weight;
              queue.Enqueue(neighbour.Node);
            }
          }
        }
      }
    }

    private static int FindMinUnmodifiedPath(
      int source,
      int destination,
      List<(int Node, int Weight)>[] edges,
      int maxMass,
      int negativeWeight)
    {
      var visited = new HashSet<int>();
      var queue = new PriorityQueue<int, int>();
      queue.Enqueue(source, 0);
      while (queue.TryDequeue(out var node, out var mass))
      {
        if (visited.Contains(node))
          continue;

        if (node == destination)
          return mass;

        visited.Add(node);

        foreach (var neighbour in edges[node])
        {
          var nextMass = mass + (neighbour.Weight >= 0 ? neighbour.Weight : negativeWeight);
          if (nextMass <= maxMass)
            queue.Enqueue(neighbour.Node, nextMass);
        }
      }

      return int.MaxValue;
    }
  }
}
