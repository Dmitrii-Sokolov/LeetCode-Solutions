namespace Problem802
{

  /// <summary>
  /// 802. Find Eventual Safe States
  /// https://leetcode.com/problems/find-eventual-safe-states
  /// 
  /// Difficulty Medium
  /// Acceptance 65.7%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Graph
  /// Topological Sort
  /// </summary>
  public class Solution
  {
    private enum State
    {
      Unvisited,
      Unsafe,
      Safe
    }

    public IList<int> EventualSafeNodes(int[][] graph)
    {
      var states = new State[graph.Length];
      var result = new List<int>();
      for (var i = 0; i < graph.Length; i++)
      {
        if (IsSafe(i, states, graph))
          result.Add(i);
      }

      return result;
    }

    private static bool IsSafe(int node, State[] states, int[][] graph)
    {
      if (states[node] != State.Unvisited)
        return states[node] == State.Safe;

      states[node] = State.Unsafe;
      foreach (var next in graph[node])
      {
        if (!IsSafe(next, states, graph))
          return false;
      }

      states[node] = State.Safe;
      return true;
    }
  }
}
