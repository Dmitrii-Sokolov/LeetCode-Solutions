namespace Problem2530
{

  /// <summary>
  /// 2530. Maximal Score After Applying K Operations
  /// https://leetcode.com/problems/maximal-score-after-applying-k-operations
  /// 
  /// Difficulty Medium
  /// Acceptance 54.2%
  /// 
  /// Array
  /// Greedy
  /// Heap(Priority Queue)
  /// </summary>
  public class Solution
  {
    public long MaxKelements(int[] numbers, int k)
    {
      var result = 0L;
      var queue = new PriorityQueue<int, int>();
      foreach (var number in numbers)
        queue.Enqueue(number, -number);

      while (k > 0)
      {
        var number = queue.Dequeue();
        result += number;
        number = (number + 2) / 3;
        queue.Enqueue(number, -number);
        k--;
      }

      return result;
    }
  }
}
