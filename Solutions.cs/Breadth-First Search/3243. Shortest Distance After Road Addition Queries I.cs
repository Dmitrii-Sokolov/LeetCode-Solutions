namespace Problem3243
{

  /// <summary>
  /// 3243. Shortest Distance After Road Addition Queries I
  /// https://leetcode.com/problems/shortest-distance-after-road-addition-queries-i
  /// 
  /// Difficulty Medium
  /// Acceptance 54.1%
  /// 
  /// Array
  /// Breadth-First Search
  /// Graph
  /// </summary>
  public class Solution
  {
    public int[] ShortestDistanceAfterQueries(int n, int[][] roads)
    {
      var cities = new City[n];
      cities[^1] = new City(n - 1);
      for (var i = 0; i < n - 1; i++)
        cities[i] = new City(i, i + 1);

      var result = new int[roads.Length];
      for (var i = 0; i < roads.Length; i++)
        result[i] = RecalculateDistances(cities, roads[i]);

      return result;
    }

    private static int RecalculateDistances(City[] cities, int[] road)
    {
      var from = road[0];
      var to = road[1];

      cities[from].Roads.Add(to);
      if (cities[to].Distance > cities[from].Distance + 1)
      {
        cities[to].Distance = cities[from].Distance + 1;
        BFS(cities, to);
      }

      return cities[^1].Distance;
    }

    private static void BFS(City[] cities, int to)
    {
      var queue = new Queue<int>();
      queue.Enqueue(to);
      var queueCount = queue.Count;
      while (queue.Count > 0)
      {
        var neighborCount = 0;
        for (var i = 0; i < queueCount; i++)
        {
          var next = queue.Dequeue();
          foreach (var roadTo in cities[next].Roads)
          {
            if (cities[roadTo].Distance > cities[next].Distance + 1)
            {
              cities[roadTo].Distance = cities[next].Distance + 1;
              queue.Enqueue(roadTo);
              neighborCount++;
            }
          }
        }

        queueCount = neighborCount;
      }
    }

    private class City(int distance)
    {
      public int Distance { get; set; } = distance;
      public List<int> Roads = [];

      public City(int distance, int roadTo) : this(distance) => Roads.Add(roadTo);
    }
  }
}
