namespace Problem933
{

  /// <summary>
  /// 933. Number of Recent Calls
  /// https://leetcode.com/problems/number-of-recent-calls
  /// 
  /// Difficulty Easy
  /// Acceptance 76.8%
  /// 
  /// Design
  /// Queue
  /// Data Stream
  /// </summary>
  public class RecentCounter
  {
    private const int Window = 3000;

    private Queue<int> Queue = new();

    public int Ping(int t)
    {
      Queue.Enqueue(t);
      while (Queue.Peek() + Window < t)
        Queue.Dequeue();

      return Queue.Count;
    }
  }
}
