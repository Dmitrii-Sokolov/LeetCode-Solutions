namespace Problem834
{

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
  public class Solution
  {
    private int N;
    private int[][] Map;
    private int[] SubResult;
    private int[] Count;
    private int[] Result;

    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
      if (n == 1)
        return new int[1];

      N = n;
      Map = new int[n][];
      SubResult = new int[n];
      Count = new int[n];
      Result = new int[n];

      foreach (var edge in edges)
      {
        Count[edge[0]]++;
        Count[edge[1]]++;
      }
      for (var i = 0; i < n; i++)
      {
        Map[i] = new int[Count[i]];
      }
      foreach (var edge in edges)
      {
        Map[edge[0]][--Count[edge[0]]] = edge[1];
        Map[edge[1]][--Count[edge[1]]] = edge[0];
      }

      CheckFirst(0, -1);

      Result[0] = SubResult[0];

      CheckSecond(0, -1);

      return Result;
    }

    private void CheckFirst(int node, int parent)
    {
      Count[node] = 1;
      foreach (var child in Map[node])
      {
        if (child != parent)
        {
          CheckFirst(child, node);

          Count[node] += Count[child];
          SubResult[node] += SubResult[child];
        }
      }

      SubResult[node] += Count[node] - 1;
    }

    private void CheckSecond(int node, int parent)
    {
      foreach (var child in Map[node])
      {
        if (child != parent)
        {
          Result[child] = Result[node] - (2 * Count[child]) + N;
          CheckSecond(child, node);
        }
      }
    }
  }
}
