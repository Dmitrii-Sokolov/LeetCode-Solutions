namespace Problem264
{

  /// <summary>
  /// 264. Ugly Number II
  /// https://leetcode.com/problems/ugly-number-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 47.0%
  /// 
  /// Hash Table
  /// Math
  /// Dynamic Programming
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    private readonly static int[] Multipliers = { 2, 3, 5 };

    public int NthUglyNumber(int n)
    {
      var queue = new PriorityQueue<long, long>();
      queue.Enqueue(1, 1);
      var numbers = new HashSet<long>();

      while (n > 0)
      {
        n--;
        var next = queue.Dequeue();
        if (n == 0)
          return (int)next;

        foreach (var m in Multipliers)
        {
          var number = next * m;
          if (numbers.Add(number))
            queue.Enqueue(number, number);
        }
      }

      return 0;
    }
  }
}
