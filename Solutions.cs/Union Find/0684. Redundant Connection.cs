namespace Problem684
{

  /// <summary>
  /// 684. Redundant Connection
  /// https://leetcode.com/problems/redundant-connection
  /// 
  /// Difficulty Medium
  /// Acceptance 64.3%
  /// 
  /// Depth-First Search
  /// Breadth-First Search
  /// Union Find
  /// Graph
  /// </summary>
  public class Solution
  {
    public int[] FindRedundantConnection(int[][] edges)
    {
      var nodesCount = edges.Length;
      Span<int> childrenCount = stackalloc int[nodesCount];
      Span<int> parents = stackalloc int[nodesCount];
      for (var i = 0; i < nodesCount; i++)
        parents[i] = i;

      foreach (var edge in edges)
      {
        var node0 = edge[0] - 1;
        while (parents[node0] != node0)
          node0 = parents[node0];

        var node1 = edge[1] - 1;
        while (parents[node1] != node1)
          node1 = parents[node1];

        if (node0 == node1)
          return edge;

        if (childrenCount[node0] < childrenCount[node1])
        {
          parents[node0] = node1;
          childrenCount[node1] += childrenCount[node0];
        }
        else
        {
          parents[node1] = node0;
          childrenCount[node0] += childrenCount[node1];
        }
      }

      return null;
    }
  }
}
