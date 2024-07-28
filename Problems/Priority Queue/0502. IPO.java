namespace Problem502
{

  /// <summary>
  /// 502. IPO
  /// https://leetcode.com/problems/ipo
  /// 
  /// Difficulty Hard 53.2%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Heap(Priority Queue)
  /// </summary>
  class Solution
  {
    public int findMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
      var n = profits.length;
      var projects = new LinkedList<Project>();
      for (var i = 0; i < n; i++)
      {
        projects.add(new Project(profits[i], capital[i]));
      }
      projects.sort((p0, p1)->Integer.compare(p1.profit, p0.profit));

      for (var t = 0; t < k; t++)
      {
        var iterator = projects.iterator();
        var succes = false;

        while (iterator.hasNext())
        {
          var node = iterator.next();
          if (node.capital <= w)
          {
            iterator.remove();
            w += node.profit;
            succes = true;
            break;
          }
        }

        if (!succes)
        {
          return w;
        }
      }

      return w;
    }

    private record Project(int profit, int capital)
    {
    }
  }
}
