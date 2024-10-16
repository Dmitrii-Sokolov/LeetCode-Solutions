namespace Problem1405
{

  /// <summary>
  /// 1405. Longest Happy String
  /// https://leetcode.com/problems/longest-happy-string
  /// 
  /// Difficulty Medium
  /// Acceptance 59.0%
  /// 
  /// String
  /// Greedy
  /// Heap(Priority Queue)
  /// </summary>
  public class Solution
  {
    private static int MaxBlockLength = 2;

    public string LongestDiverseString(int a, int b, int c)
    {
      var result = new System.Text.StringBuilder();
      var queue = new PriorityQueue<(char c, int count), int>();
      Enqueue(queue, ('a', a));
      Enqueue(queue, ('b', b));
      Enqueue(queue, ('c', c));

      (char c, int count) previous = ('d', 0);
      while (queue.Count > 0)
      {
        var next = queue.Dequeue();
        var count = Math.Min(next.count, MaxBlockLength);
        if (next.count < previous.count)
          count = 1;
        result.Append(next.c, count);
        next.count -= count;

        Enqueue(queue, previous);
        previous = next;
      }

      return result.ToString();
    }

    private static void Enqueue(PriorityQueue<(char c, int count), int> queue, (char c, int count) previous)
    {
      if (previous.count > 0)
        queue.Enqueue(previous, -previous.count);
    }
  }
}
