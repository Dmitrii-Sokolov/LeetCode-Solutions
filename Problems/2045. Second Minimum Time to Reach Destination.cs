namespace Problem2045
{
  /// <summary>
  /// 2045. Second Minimum Time to Reach Destination
  /// https://leetcode.com/problems/second-minimum-time-to-reach-destination
  /// Difficulty Hard 47.0%
  /// 
  /// Breadth-First Search
  /// Graph
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public int SecondMinimum(int n, int[][] edgesRaw, int time, int change)
    {
      var edges = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
      foreach (var edge in edgesRaw)
      {
        var v0 = edge[0] - 1;
        var v1 = edge[1] - 1;

        edges[v0].Add(v1);
        edges[v1].Add(v0);
      }

      var steps = FindPath(n, edges);
      var period = change * 2;
      var timeShift = time % period;
      var stepsPerWaiting = timeShift == 0 ? 0 : change % timeShift == 0 ? change / timeShift : change / timeShift + 1;
      var waiting = period - stepsPerWaiting * timeShift;
      var waitingCount = stepsPerWaiting == 0 ? 0 : (steps - 1) / stepsPerWaiting;
      var result = time * steps + waiting * waitingCount;
      return result;
    }

    private static int FindPath(int n, List<int>[] edges)
    {
      var distances1 = Enumerable.Repeat(int.MaxValue, n).ToArray();
      var distances2 = Enumerable.Repeat(int.MaxValue, n).ToArray();
      var queue = new Queue<(int node, int distance)>();
      queue.Enqueue((n - 1, 0));
      while (queue.Count > 0)
      {
        var (node, distance) = queue.Dequeue();
        distance++;
        foreach (var neighbour in edges[node])
        {
          if (distances1[neighbour] == int.MaxValue)
          {
            distances1[neighbour] = distance;
            queue.Enqueue((neighbour, distance));
          }
          else if (distances1[neighbour] != distance && distances2[neighbour] == int.MaxValue)
          {
            if (neighbour == 0)
              return distance;

            distances2[neighbour] = distance;
            queue.Enqueue((neighbour, distance));
          }
        }
      }

      return distances2[0];
    }
  }
}
