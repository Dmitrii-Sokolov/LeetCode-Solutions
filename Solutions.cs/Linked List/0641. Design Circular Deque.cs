namespace Problem641
{

  /// <summary>
  /// 641. Design Circular Deque
  /// https://leetcode.com/problems/design-circular-deque
  /// 
  /// Difficulty Medium
  /// Acceptance 59.4%
  /// 
  /// Array
  /// Linked List
  /// Design
  /// Queue
  /// </summary>
  public class MyCircularDeque
  {
    private readonly int Capacity;
    private readonly LinkedList<int> Container = new();

    public MyCircularDeque(int k)
    {
      Capacity = k;
    }

    public bool InsertFront(int value)
    {
      if (Container.Count < Capacity)
      {
        Container.AddFirst(value);
        return true;
      }

      return false;
    }

    public bool InsertLast(int value)
    {
      if (Container.Count < Capacity)
      {
        Container.AddLast(value);
        return true;
      }

      return false;
    }

    public bool DeleteFront()
    {
      if (Container.Count > 0)
      {
        Container.RemoveFirst();
        return true;
      }

      return false;
    }

    public bool DeleteLast()
    {
      if (Container.Count > 0)
      {
        Container.RemoveLast();
        return true;
      }

      return false;
    }

    public int GetFront() => Container.First?.Value ?? -1;

    public int GetRear() => Container.Last?.Value ?? -1;

    public bool IsEmpty() => Container.Count == 0;

    public bool IsFull() => Container.Count == Capacity;
  }
}
