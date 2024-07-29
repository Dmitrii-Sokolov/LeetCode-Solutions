namespace Problem2976
{

  /// <summary>
  /// 2976. Minimum Cost to Convert String I
  /// https://leetcode.com/problems/minimum-cost-to-convert-string-i
  /// 
  /// Difficulty Medium
  /// Acceptance 54.6%
  /// 
  /// Floyd Warshall Algorithm
  /// 
  /// Array
  /// String
  /// Graph
  /// Shortest Path
  /// </summary>
  public class Solution
  {
    private const int N = 26;
    private const int NoWay = -1;

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
      var costs = new long[N, N];
      for (var k = 0; k < N; k++)
      {
        for (var i = 0; i < N; i++)
          costs[k, i] = NoWay;
      }

      for (var k = 0; k < N; k++)
        costs[k, k] = 0;

      var edgesCount = cost.Length;
      for (var i = 0; i < edgesCount; i++)
      {
        var from = original[i] - 'a';
        var to = changed[i] - 'a';
        if (costs[from, to] < 0 || costs[from, to] > cost[i])
          costs[from, to] = cost[i];
      }

      //Floyd Warshall Algorithm
      for (var k = 0; k < N; k++)
      {
        for (var i = 0; i < N; i++)
        {
          for (var j = 0; j < N; j++)
          {
            if (costs[i, k] > 0 && costs[k, j] > 0 &&
              (costs[i, j] > costs[i, k] + costs[k, j] || costs[i, j] < 0))
              costs[i, j] = costs[i, k] + costs[k, j];
          }
        }
      }

      var result = 0L;
      var charCount = source.Length;
      for (var i = 0; i < charCount; i++)
      {
        var from = source[i] - 'a';
        var to = target[i] - 'a';
        if (costs[from, to] >= 0)
          result += costs[from, to];
        else
        {
          return -1;
        }
      }
      return result;
    }
  }
}
