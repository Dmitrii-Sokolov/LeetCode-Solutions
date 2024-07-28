namespace Problem2392
{

  /// <summary>
  /// 2392. Build a Matrix With Conditions
  /// https://leetcode.com/problems/build-a-matrix-with-conditions
  /// 
  /// Difficulty Hard 79.6%
  /// 
  /// Array
  /// Graph
  /// Topological Sort
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] columnConditions)
    {
      var rows = GetOrder(k, rowConditions);
      if (rows == null)
        return new int[0][];

      var columns = GetOrder(k, columnConditions);
      if (columns == null)
        return new int[0][];

      var result = new int[k][];
      for (var i = 0; i < k; i++)
        result[i] = new int[k];

      for (var i = 0; i < k; i++)
      {
        var x = columns[i];
        var y = rows[i];
        result[y][x] = i + 1;
      }

      // result[0] = rows;
      // result[1] = columns;

      return result;
    }

    private int[] GetOrder(int k, int[][] conditions)
    {
      var befores = Enumerable.Range(0, k).Select(_ => new HashSet<int>()).ToArray();
      var afters = Enumerable.Range(0, k).Select(_ => new HashSet<int>()).ToArray();

      foreach (var condition in conditions)
      {
        var before = condition[0] - 1;
        var after = condition[1] - 1;

        afters[before].Add(after);
        befores[after].Add(before);
      }

      var list = new List<int>(k);
      var available = new HashSet<int>();

      while (list.Count < k)
      {
        var first = FindFirst(befores, available);
        if (first == -1)
          return null;

        list.Add(first);
        available.Add(first);

        foreach (var after in afters[first])
        {
          if (available.Contains(after))
            return null;

          befores[after].Remove(first);
        }
      }

      var result = new int[k];
      for (var i = 0; i < k; i++)
        result[list[i]] = i;

      return result;
    }

    private static int FindFirst(HashSet<int>[] before, HashSet<int> available)
    {
      for (var i = 0; i < before.Length; i++)
      {
        if (!available.Contains(i) && before[i].Count == 0)
          return i;
      }

      return -1;
    }
  }
}
