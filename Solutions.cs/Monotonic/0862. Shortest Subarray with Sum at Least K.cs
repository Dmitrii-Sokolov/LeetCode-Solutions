namespace Problem862
{

  /// <summary>
  /// 862. Shortest Subarray with Sum at Least K
  /// https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k
  /// 
  /// Difficulty Hard
  /// Acceptance 27.4%
  /// 
  /// Array
  /// Binary Search
  /// Queue
  /// Sliding Window
  /// Heap (Priority Queue)
  /// Prefix Sum
  /// Monotonic Queue
  /// </summary>
  public class Solution
  {
    public int ShortestSubarray(int[] numbers, int k)
    {
      var monotonicTail = new List<(int Index, long Prefix)>();
      monotonicTail.Add((-1, 0));
      var result = int.MaxValue;
      var sum = 0L;
      for (var i = 0; i < numbers.Length; i++)
      {
        sum += numbers[i];

        if (TryFindLast(0, monotonicTail.Count - 1, c => monotonicTail[c].Prefix + k <= sum, out var candidate))
        {
          if (result > i - monotonicTail[candidate].Index)
            result = i - monotonicTail[candidate].Index;
        }

        while (monotonicTail.Count > 0 && monotonicTail[^1].Prefix > sum)
          monotonicTail.RemoveAt(monotonicTail.Count - 1);

        monotonicTail.Add((i, sum));
      }

      return result == int.MaxValue ? -1 : result;
    }

    // Find first that's appropriate
    private static bool TryFindLast(int min, int max, Func<int, bool> check, out int result)
    {
      if (!check(min))
      {
        result = 0;
        return false;
      }

      while (max > min)
      {
        var middle = 1 + (max + min >> 1);
        if (check(middle))
          min = middle;
        else
        {
          max = middle - 1;
        }
      }

      result = min;
      return true;
    }
  }
}
