namespace Problem1942
{

  /// <summary>
  /// 1942. The Number of the Smallest Unoccupied Chair
  /// https://leetcode.com/problems/the-number-of-the-smallest-unoccupied-chair
  /// 
  /// Difficulty Medium
  /// Acceptance 52.1%
  /// 
  /// Array
  /// Hash Table
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public int SmallestChair(int[][] friends, int targetFriend)
    {
      var targetArrival = friends[targetFriend][0];
      Array.Sort(friends, (a, b) => a[0].CompareTo(b[0]));
      var availableChairs = new PriorityQueue<int, int>();
      var occupiedChairs = new PriorityQueue<int, int>();
      for (var i = 0; i < friends.Length; i++)
      {
        var arrival = friends[i][0];
        var leaving = friends[i][1];

        while (occupiedChairs.Count > 0 && occupiedChairs.TryPeek(out var index, out var time) && time <= arrival)
          availableChairs.Enqueue(index, occupiedChairs.Dequeue());

        var chair = availableChairs.Count > 0 ? availableChairs.Dequeue() : occupiedChairs.Count;
        if (arrival == targetArrival)
          return chair;

        occupiedChairs.Enqueue(chair, leaving);
      }

      return -1;
    }
  }
}
