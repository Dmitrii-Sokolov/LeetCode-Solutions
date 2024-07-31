namespace Problem857
{

  /// <summary>
  /// 857. Minimum Cost to Hire K Workers
  /// https://leetcode.com/problems/minimum-cost-to-hire-k-workers
  /// 
  /// Difficulty Hard
  /// Acceptance 63.4%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Heap(Priority Queue)
  /// </summary>
  public class Solution
  {
    public double MincostToHireWorkers(int[] qualities, int[] wage, int k)
    {
      var n = qualities.Length;
      var people = new (int Quality, double Scalar)[qualities.Length];

      for (var i = 0; i < qualities.Length; i++)
        people[i] = (qualities[i], (double)wage[i] / qualities[i]);

      Array.Sort(people, (a, b) => a.Scalar.CompareTo(b.Scalar));

      var quality = 0;
      var cost = 1e15;
      var queue = new PriorityQueue<int, int>();

      foreach (var person in people)
      {
        queue.Enqueue(-person.Quality, -person.Quality);
        quality += person.Quality;

        if (queue.Count > k)
          quality += queue.Dequeue();

        if (queue.Count == k)
          cost = Math.Min(cost, quality * person.Scalar);
      }

      return cost;
    }
  }
}
