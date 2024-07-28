namespace Problem857
{

  /// <summary>
  /// 857. Minimum Cost to Hire K Workers
  /// https://leetcode.com/problems/minimum-cost-to-hire-k-workers
  /// 
  /// Difficulty Hard 63.4%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Heap(Priority Queue)
  /// </summary>
  class Solution
  {
    public double mincostToHireWorkers(int[] qualities, int[] wage, int k)
    {
      var n = qualities.length;
      var people = new Person[n];

      for (var i = 0; i < n; i++)
      {
        people[i] = new Person(qualities[i], wage[i]);
      }

      Arrays.sort(people);

      int quality = 0;
      double cost = 1e15;
      PriorityQueue<Integer> queue = new PriorityQueue<>();

      for (var person : people)
      {
        queue.add(-person.quality);
        quality += person.quality;

        if (queue.size() > k)
        {
          quality += queue.poll();
        }

        if (queue.size() == k)
        {
          cost = Math.min(cost, quality * person.scalar);
        }
      }

      return cost;
    }

    private class Person implements Comparable<Person> {
        public int quality;
    public double scalar;

    public Person(int quality, int wage)
    {
      this.quality = quality;
      scalar = wage * 1.0 / quality;
    }

    @Override
        public int compareTo(Person other)
    {
      return Double.compare(scalar, other.scalar);
    }
  }
}
}
