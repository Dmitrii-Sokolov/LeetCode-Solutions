namespace Problem502
{

  /// <summary>
  /// 502. IPO
  /// https://leetcode.com/problems/ipo
  /// 
  /// Difficulty Hard
  /// Acceptance 53.2%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// Heap(Priority Queue)
  /// </summary>
  public class Solution
  {
    public int FindMaximizedCapital(int k, int wealth, int[] profits, int[] capitals)
    {
      var projects = new LinkedList<(int Profit, int Capital)>();
      foreach (var project in Enumerable.Range(0, profits.Length).Select(i => (profits[i], capitals[i])).OrderBy(p => -p.Item1))
        projects.AddLast(project);

      for (var t = 0; t < k; t++)
      {
        var project = projects.First;
        var success = false;

        while (project != null)
        {
          var (profit, capital) = project.Value;
          if (capital <= wealth)
          {
            projects.Remove(project);
            wealth += profit;
            success = true;
            break;
          }

          project = project.Next;
        }

        if (!success)
          return wealth;
      }

      return wealth;
    }
  }
}
