namespace Problem1381
{

  /// <summary>
  /// 1381. Design a Stack With Increment Operation
  /// https://leetcode.com/problems/design-a-stack-with-increment-operation
  /// 
  /// Difficulty Medium
  /// Acceptance 78.7%
  /// 
  /// Array
  /// Stack
  /// Design
  /// </summary>
  public class CustomStack
  {
    private readonly LinkedList<int> Stack = new();
    private int FreeCount;

    public CustomStack(int maxSize) => FreeCount = maxSize;

    public void Push(int x)
    {
      if (FreeCount > 0)
      {
        Stack.AddFirst(x);
        FreeCount--;
      }
    }

    public int Pop()
    {
      if (Stack.Count > 0)
      {
        var result = Stack.First.Value;
        Stack.RemoveFirst();
        FreeCount++;
        return result;
      }

      return -1;
    }

    public void Increment(int k, int val)
    {
      var node = Stack.Last;
      while (node != null && k > 0)
      {
        node.Value += val;
        node = node.Previous;
        k--;
      }
    }
  }
}
