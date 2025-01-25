namespace Problem2948
{

  /// <summary>
  /// 2948. Make Lexicographically Smallest Array by Swapping Elements
  /// https://leetcode.com/problems/make-lexicographically-smallest-array-by-swapping-elements
  /// 
  /// Difficulty Medium
  /// Acceptance 51.1%
  /// 
  /// Array
  /// Union Find
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] LexicographicallySmallestArray(int[] numbers, int limit)
    {
      var sortedClone = numbers.ToArray();
      Array.Sort(sortedClone);

      var queues = new Dictionary<int, Queue<int>>();
      var queue = new Queue<int>();

      for (var i = 0; i < numbers.Length; i++)
      {
        queues[sortedClone[i]] = queue;
        queue.Enqueue(sortedClone[i]);

        if (i == numbers.Length - 1 || sortedClone[i + 1] - limit > sortedClone[i])
          queue = new Queue<int>();
      }

      for (var i = 0; i < numbers.Length; i++)
        numbers[i] = queues[numbers[i]].Dequeue();

      return numbers;
    }
  }
}
