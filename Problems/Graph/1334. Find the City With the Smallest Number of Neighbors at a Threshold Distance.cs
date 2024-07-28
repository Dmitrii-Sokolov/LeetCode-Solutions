namespace Problem1334
{

  /// <summary>
  /// 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance
  /// https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance
  /// 
  /// Difficulty Medium 68.1%
  /// 
  /// Dynamic Programming
  /// Graph
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    public int FindTheCity(int n, int[][] edgesArray, int distanceThreshold)
    {
      var distances = new int[n, n];
      for (var k = 0; k < n; k++)
      {
        for (var i = 0; i < n; i++)
          distances[k, i] = distanceThreshold + 1;
      }

      foreach (var edge in edgesArray)
      {
        distances[edge[0], edge[1]] = edge[2];
        distances[edge[1], edge[0]] = edge[2];
      }

      //Floyd Warshall Algorithm
      for (var k = 0; k < n; k++)
      {
        for (var i = 0; i < n; i++)
        {
          for (var j = 0; j < n; j++)
          {
            if (distances[i, k] + distances[k, j] < distances[i, j])
              distances[i, j] = distances[i, k] + distances[k, j];
          }
        }
      }

      //return Enumerable.Range(0, n)
      //  .Select(i =>
      //    (Enumerable.Range(0, n)
      //    .Where(k => distances[i, k] <= distanceThreshold)
      //    .Count(), i))
      //  .Aggregate((a, b) => (a.Item2 <= b.Item2) ? a : b).i;

      var reachableCities = new int[n];
      for (var i = 0; i < n; i++)
        reachableCities[i] = Enumerable.Range(0, n).Where(k => i != k && distances[i, k] <= distanceThreshold).Count();

      var result = 0;
      for (var i = 1; i < n; i++)
      {
        if (reachableCities[i] <= reachableCities[result])
          result = i;
      }
      return result;
    }
  }
}
