namespace Problem2349
{

  /// <summary>
  /// 2349. Design a Number Container System
  /// https://leetcode.com/problems/design-a-number-container-system
  /// 
  /// Difficulty Medium
  /// Acceptance 52.2%
  /// 
  /// Hash Table
  /// Design
  /// Heap(Priority Queue)
  /// Ordered Set
  /// </summary>
  public class NumberContainers
  {
    private readonly Dictionary<int, int> Numbers = [];
    private readonly Dictionary<int, PriorityQueue<int, int>> Indexes = [];

    public void Change(int index, int number)
    {
      if (!Indexes.TryGetValue(number, out var queue))
      {
        queue = new();
        Indexes[number] = queue;
      }

      Numbers[index] = number;
      queue.Enqueue(index, index);
    }

    public int Find(int number)
    {
      if (Indexes.TryGetValue(number, out var queue))
      {
        while (queue.TryPeek(out var index, out _) && Numbers[index] != number)
          queue.Dequeue();

        return queue.Count > 0 ? queue.Peek() : -1;
      }
      else
      {
        return -1;
      }
    }
  }
}
