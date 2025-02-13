namespace Problem3066
{

  /// <summary>
  /// 3066. Minimum Operations to Exceed Threshold Value II
  /// https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 40.7%
  /// 
  /// Array
  /// Heap(Priority Queue)
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int MinOperations(int[] numbers, int k)
    {
      var queue = new PriorityQueue<int, int>();
      foreach (var number in numbers)
      {
        if (number < k)
          queue.Enqueue(number, number);
      }

      var result = 0;
      while (queue.Count > 1)
      {
        var a = queue.Dequeue();
        var b = queue.Dequeue();
        var c = a * 2;
        if (c < k - b)
          queue.Enqueue(c + b, c + b);

        result++;
      }

      return result + queue.Count;
    }
  }
}
