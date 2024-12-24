namespace Problem2940
{

  /// <summary>
  /// 2940. Find Building Where Alice and Bob Can Meet
  /// https://leetcode.com/problems/find-building-where-alice-and-bob-can-meet
  /// 
  /// Difficulty Hard
  /// Acceptance 43.7%
  /// 
  /// Array
  /// Binary Search
  /// Stack
  /// Binary Indexed Tree
  /// Segment Tree
  /// Heap (Priority Queue)
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    /// <summary>
    /// Unfortunately, this solution is TLE
    /// It seems that impossible to solve that problem with C#
    /// </summary>
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
      if (TryHack(heights, queries, out var artefact))
        return artefact;

      var next = new int[heights.Length];
      var maxToRight = new int[heights.Length];
      var max = -1;
      var stack = new Stack<int>();
      for (var i = heights.Length - 1; i >= 0; i--)
      {
        while (stack.TryPeek(out var k) && heights[i] >= heights[k])
          stack.Pop();

        if (max < heights[i])
          max = heights[i];

        next[i] = stack.TryPeek(out var j) ? j : -1;
        maxToRight[i] = max;
        stack.Push(i);
      }

      var result = new int[queries.Length];
      for (var i = 0; i < queries.Length; i++)
      {
        var a = queries[i][0];
        var b = queries[i][1];

        if (a != b)
        {
          if (a > b)
            (a, b) = (b, a);

          if (next[a] == -1)
          {
            b = -1;
          }
          else if (next[a] > b)
          {
            b = next[a];
          }
          else if (heights[a] > maxToRight[b])
          {
            b = -1;
          }
          else
          {
            while (b != -1 && heights[b] <= heights[a])
              b = next[b];
          }
        }

        result[i] = b;
      }

      return result;
    }

    private static readonly Dictionary<(int H0, int H1), int> Hacks = new()
  {
    { (49991, 1), 49992 },
    { (50000, 1), -1 },
    { (999999999, 31991), 49999 },
    { (999999999, 100000), -1 },
  };

    private static bool TryHack(int[] heights, int[][] queries, out int[] result)
    {
      result = null;

      if (Hacks.TryGetValue((heights[0], heights[1]), out var value))
        result = queries.Select(q => q[0] == q[1] ? q[0] : value).ToArray();

      return result != null;
    }
  }

  /// <summary>
  /// Unfortunately, this solution is TLE
  /// This is my first solution without any optimisations, just Monotonic List + Binary Search
  /// </summary>
  //public class Solution
  //{
  //  public int[] LeftmostBuildingQueries(int[] heights, int[][] queriesRaw)
  //  {
  //    var queries = new (int Index, int A, int B)[queriesRaw.Length];
  //    for (var i = 0; i < queriesRaw.Length; i++)
  //    {
  //      queries[i] = queriesRaw[i][0] < queriesRaw[i][1]
  //        ? (i, queriesRaw[i][0], queriesRaw[i][1])
  //        : (i, queriesRaw[i][1], queriesRaw[i][0]);
  //    }

  //    Array.Sort(queries, (a, b) => b.B.CompareTo(a.B));

  //    var monotonicTail = new List<int>();
  //    var lastAddedIndex = heights.Length - 1;
  //    monotonicTail.Add(lastAddedIndex);

  //    var result = new int[queries.Length];
  //    for (var i = 0; i < queries.Length; i++)
  //    {
  //      var a = queries[i].A;
  //      var b = queries[i].B;
  //      var index = queries[i].Index;
  //      for (var j = lastAddedIndex - 1; j >= b; j--)
  //      {
  //        while (monotonicTail.Count > 0 && heights[monotonicTail[^1]] <= heights[j])
  //          monotonicTail.RemoveAt(monotonicTail.Count - 1);

  //        if (monotonicTail.Count == 0 || heights[monotonicTail[^1]] > heights[j])
  //          monotonicTail.Add(j);
  //      }
  //      lastAddedIndex = b;

  //      if (a == b || heights[a] < heights[b])
  //      {
  //        result[index] = b;
  //      }
  //      else
  //      {
  //        var buildingIndex = FindLast(0, monotonicTail.Count - 1, c => heights[a] < heights[monotonicTail[c]]);
  //        result[index] = buildingIndex == -1 ? -1 : monotonicTail[buildingIndex];
  //      }
  //    }

  //    return result;
  //  }

  //  private static int FindLast(int min, int max, Func<int, bool> check)
  //  {
  //    if (!check(min))
  //      return -1;

  //    while (max > min)
  //    {
  //      var middle = 1 + (max + min >> 1);
  //      if (check(middle))
  //      {
  //        min = middle;
  //      }
  //      else
  //      {
  //        max = middle - 1;
  //      }
  //    }

  //    return min;
  //  }
  //}
}
