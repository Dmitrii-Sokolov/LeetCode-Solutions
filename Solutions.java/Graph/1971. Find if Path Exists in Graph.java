/// <summary>
/// 1971. Find if Path Exists in Graph
/// https://leetcode.com/problems/find-if-path-exists-in-graph
/// 
/// Difficulty Easy
/// Acceptance 54.1%
/// 
/// Depth-First Search
/// Breadth-First Search
/// Union Find
/// Graph
/// </summary>
class Solution
{
  public boolean validPath(int n, int[][] edges, int source, int destination)
  {
    if (source == destination)
      return true;

    var connected = new HashSet<Integer>();
    var visit = new Stack<Integer>();
    visit.add(destination);

    while (!visit.isEmpty())
    {
      var node = visit.pop();
      for (var i = 0; i < edges.length; i++)
      {
        var edge = edges[i];
        if (edge[0] != node && edge[1] != node)
          continue;
        
        var next = edge[0] == node ? edge [1] : edge[0];
        if (connected.contains(next))
          continue;
        
        if (next == source)
          return true;
        
        visit.push(next);
        connected.add(next);
      }
    }

    return false;
  }
}
