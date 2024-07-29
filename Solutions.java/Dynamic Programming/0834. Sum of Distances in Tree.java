/// <summary>
/// 834. Sum of Distances in Tree
/// https://leetcode.com/problems/sum-of-distances-in-tree
/// 
/// Difficulty Hard
/// Acceptance 65.3%
/// 
/// Dynamic Programming
/// Tree
/// Depth-First Search
/// Graph
/// </summary>
class Solution
{
  int n;
  int[][] map;
  int[] subResult;
  int[] count;
  int[] result;

  public int[] sumOfDistancesInTree(int n, int[][] edges)
  {
    if (n == 1)
      return new int[1];

    this.n = n;
    map = new int[n][];
    subResult = new int[n];
    count = new int[n];
    result = new int[n];

    for (var edge : edges)
    {
      count[edge[0]]++;
      count[edge[1]]++;
    }
    for (var i = 0; i < n; i++)
    {
      map[i] = new int[count[i]];
    }
    for (var edge : edges)
    {
      map[edge[0]][--count[edge[0]]] = edge[1];
      map[edge[1]][--count[edge[1]]] = edge[0];
    }

    CheckFirst(0, -1);

    result[0] = subResult[0];

    CheckSecond(0, -1);

    return result;
  }

  private void CheckFirst(int node, int parent)
  {
    count[node] = 1;
    for (var child : map[node])
    {
      if (child != parent)
      {
        CheckFirst(child, node);

        count[node] += count[child];
        subResult[node] += subResult[child];
      }
    }

    subResult[node] += count[node] - 1;
  }

  private void CheckSecond(int node, int parent)
  {
    for (var child : map[node])
    {
      if (child != parent)
      {
        result[child] = result[node] - 2 * count[child] + n;
        CheckSecond(child, node);
      }
    }
  }
}
