namespace Problem703
{

  /// <summary>
  /// 703. Kth Largest Element in a Stream
  /// https://leetcode.com/problems/kth-largest-element-in-a-stream
  /// 
  /// Difficulty Easy
  /// Acceptance 57.4%
  /// 
  /// Tree
  /// Design
  /// Binary Search Tree
  /// Heap (Priority Queue)
  /// Binary Tree
  /// Data Stream
  /// </summary>
  public class KthLargest
  {
    private readonly PriorityQueue<int, int> Elements;
    private readonly int Count;

    public KthLargest(int count, int[] numbers)
    {
      Count = count;
      Elements = new PriorityQueue<int, int>(Count + 1);
      foreach (var number in numbers)
      {
        Elements.Enqueue(number, number);
        if (Elements.Count > count)
          Elements.Dequeue();
      }
    }

    public int Add(int number)
    {
      Elements.Enqueue(number, number);
      if (Elements.Count > Count)
        Elements.Dequeue();

      return Elements.Peek();
    }
  }
}
