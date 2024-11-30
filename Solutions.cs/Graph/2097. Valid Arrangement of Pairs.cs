namespace Problem2097
{

  /// <summary>
  /// 2097. Valid Arrangement of Pairs
  /// https://leetcode.com/problems/valid-arrangement-of-pairs
  /// 
  /// Difficulty Hard
  /// Acceptance 55.0%
  /// 
  /// Depth-First Search
  /// Graph
  /// Eulerian Circuit
  /// Hierholzer's algorithm
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public int[][] ValidArrangement(int[][] pairs)
    {
      var edges = new Dictionary<int, List<int>>();
      var edgeCount = new Dictionary<int, int>();
      foreach (var pair in pairs)
      {
        var from = pair[0];
        var to = pair[1];
        if (!edges.TryGetValue(from, out var list))
        {
          list = [];
          edges.Add(from, list);
        }

        list.Add(to);

        edgeCount[from] = edgeCount.GetValueOrDefault(from, 0) + 1;
        edgeCount[to] = edgeCount.GetValueOrDefault(to, 0) - 1;
      }

      var current = pairs[0][0];
      foreach (var pair in edgeCount)
      {
        if (pair.Value > 0)
        {
          current = pair.Key;
          break;
        }
      }

      var path = new Stack<int>();
      var counter = 0;
      path.Push(current);
      while (path.Count > 0)
      {
        if (edges.TryGetValue(current, out var list) && list.Count > 0)
        {
          path.Push(current);
          var last = edges[current].Count - 1;
          var next = edges[current][last];
          edges[current].RemoveAt(last);
          current = next;
        }
        else
        {
          var order = pairs.Length - ++counter;
          if (order >= 0)
            pairs[order][1] = current;

          if (order < pairs.Length - 1)
            pairs[order + 1][0] = current;

          current = path.Pop();
        }
      }

      return pairs;
    }
  }
}
