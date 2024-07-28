namespace Problem1791
{

  /// <summary>
  /// 1791. Find Center of Star Graph
  /// https://leetcode.com/problems/find-center-of-star-graph/description/
  /// 
  /// Difficulty Easy 86.7%
  /// 
  /// Graph
  /// </summary>
  class Solution
  {
    public int findCenter(int[][] edges)
    {
      return edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];
    }
  }
}
