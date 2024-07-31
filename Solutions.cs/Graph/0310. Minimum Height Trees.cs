namespace Problem310
{

  /// <summary>
  /// 310. Minimum Height Trees
  /// https://leetcode.com/problems/minimum-height-trees
  /// 
  /// Difficulty Medium
  /// Acceptance 41.8%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// Topological Sort
  /// </summary>
  public class Solution
  {
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
      if (n == 1)
        return new List<int>() { 0 };

      var ind = new int[n];
      var map = new Dictionary<int, List<int>>();
      foreach (var edge in edges)
      {
        ind[edge[0]]++;
        ind[edge[1]]++;
        if (!map.ContainsKey(edge[0]))
          map[edge[0]] = [];

        if (!map.ContainsKey(edge[1]))
          map[edge[1]] = [];

        map[edge[0]].Add(edge[1]);
        map[edge[1]].Add(edge[0]);
      }

      Queue<int> queue = new();
      for (var i = 0; i < ind.Length; i++)
      {
        if (ind[i] == 1)
          queue.Enqueue(i);
      }

      var processed = 0;
      while (n - processed > 2)
      {
        var size = queue.Count;
        processed += size;
        for (var i = 0; i < size; i++)
        {
          var poll = queue.Dequeue();
          foreach (var adj in map[poll])
          {
            if (--ind[adj] == 1)
              queue.Enqueue(adj);
          }
        }
      }

      var list = new List<int>();
      list.AddRange(queue);
      return list;
    }
  }
}
