namespace Problem632
{

  /// <summary>
  /// 632. Smallest Range Covering Elements from K Lists
  /// https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists
  /// 
  /// Difficulty Hard
  /// Acceptance 64.7%
  /// 
  /// Array
  /// Hash Table
  /// Greedy
  /// Sliding Window
  /// Sorting
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public int[] SmallestRange(IList<IList<int>> nums)
    {
      var queue = new PriorityQueue<(int row, int index, int value), int>();
      var max = int.MinValue;
      for (var i = 0; i < nums.Count; i++)
      {
        var value = nums[i][0];
        queue.Enqueue((i, 1, value), value);
        if (value > max)
          max = value;
      }

      int[] result = [queue.Peek().value, max];
      while (true)
      {
        var (row, nextIndex, min) = queue.Dequeue();
        if (max - min < result[1] - result[0])
          result = [min, max];

        if (nextIndex == nums[row].Count)
          return result;

        var nextValue = nums[row][nextIndex];
        queue.Enqueue((row, nextIndex + 1, nextValue), nextValue);

        if (nextValue > max)
          max = nextValue;
      }
    }
  }
}
