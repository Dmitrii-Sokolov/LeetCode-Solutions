namespace Problem1462
{

  /// <summary>
  /// 1462. Course Schedule IV
  /// https://leetcode.com/problems/course-schedule-iv
  /// 
  /// Difficulty Medium
  /// Acceptance 53.7%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// Topological Sort
  /// Floyd Warshall Algorithm
  /// </summary>
  public class Solution
  {
    public IList<bool> CheckIfPrerequisite(int count, int[][] edges, int[][] queries)
    {
      Span<bool> connected = stackalloc bool[count * count];
      foreach (var edge in edges)
        connected[edge[0] * count + edge[1]] = true;

      for (var i = 0; i < count; i++)
      {
        for (var j = 0; j < count; j++)
        {
          for (var k = 0; k < count; k++)
          {
            if (connected[j * count + i] && connected[i * count + k])
              connected[j * count + k] = true;
          }
        }
      }

      var result = new List<bool>(queries.Length);
      for (var i = 0; i < queries.Length; i++)
        result.Add(connected[queries[i][0] * count + queries[i][1]]);

      return result;
    }
  }
}
