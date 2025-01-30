namespace Problem785
{

  /// <summary>
  /// 785. Is Graph Bipartite
  /// https://leetcode.com/problems/is-graph-bipartite
  /// 
  /// Difficulty Medium
  /// Acceptance 57.0%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public bool IsBipartite(int[][] graph)
    {
      var stackPointer = -1;
      Span<int> stack = stackalloc int[graph.Length];
      Span<int> states = stackalloc int[graph.Length];
      for (var firstNode = 0; firstNode < graph.Length; firstNode++)
      {
        if (states[firstNode] == 0)
        {
          stack[++stackPointer] = firstNode;
          states[firstNode] = 1;
          while (stackPointer > -1)
          {
            var node = stack[stackPointer--];
            var state = states[node];
            foreach (var neighbor in graph[node])
            {
              if (states[neighbor] == 0)
              {
                states[neighbor] = -state;
                stack[++stackPointer] = neighbor;
              }
              else if (states[neighbor] == state)
              {
                return false;
              }
            }
          }
        }
      }

      return true;
    }
  }
}
