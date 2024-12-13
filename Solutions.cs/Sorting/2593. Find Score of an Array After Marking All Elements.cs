namespace Problem2593
{

  /// <summary>
  /// 2593. Find Score of an Array After Marking All Elements
  /// https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements
  /// 
  /// Difficulty Medium
  /// Acceptance 61.8%
  /// 
  /// Heap (Priority Queue)
  /// Sorting
  /// Array
  /// Simulation
  /// Hash Table
  /// Ordered Set
  /// Ordered Map
  /// Greedy
  /// Monotonic Stack
  /// Sliding Window
  /// Two Pointers
  /// Stack
  /// Queue
  /// Data Stream
  /// Doubly-Linked List
  /// Hash Function
  /// Bit Manipulation
  /// Dynamic Programming
  /// Design
  /// Tree
  /// Divide and Conquer
  /// String
  /// Radix Sort
  /// Iterator
  /// </summary>
  public class Solution
  {
    public long FindScore(int[] numbers)
    {
      var indexes = new (int Index, int Number)[numbers.Length];
      for (var i = 0; i < numbers.Length; i++)
        indexes[i] = (i, numbers[i]);

      Array.Sort(indexes,
        (a, b) => a.Number == b.Number
        ? a.Index.CompareTo(b.Index)
        : a.Number.CompareTo(b.Number));

      var result = 0L;

      for (var i = 0; i < numbers.Length; i++)
      {
        var index = indexes[i].Index;

        if (numbers[index] != -1)
        {
          result += numbers[index];

          numbers[index] = -1;

          if (index > 0)
            numbers[index - 1] = -1;

          if (index < numbers.Length - 1)
            numbers[index + 1] = -1;
        }
      }

      return result;
    }
  }
}
