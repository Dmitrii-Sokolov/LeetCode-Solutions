namespace Problem826
{

  /// <summary>
  /// 826. Most Profit Assigning Work
  /// https://leetcode.com/problems/most-profit-assigning-work
  /// 
  /// Difficulty Medium
  /// Acceptance 55.9%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] workers)
    {
      var jobs = new (int Profit, int Difficulty)[profit.Length];
      for (var i = 0; i < profit.Length; i++)
        jobs[i] = (profit[i], difficulty[i]);

      Array.Sort(jobs, (a, b) => b.Profit.CompareTo(a.Profit));
      Array.Sort(workers);
      Reverse(workers);

      var wp = 0;
      var jp = 0;
      var result = 0;
      while (jp < profit.Length && wp < workers.Length)
      {
        while (jp < profit.Length && jobs[jp].Difficulty > workers[wp])
        {
          jp++;
        }

        while (jp < profit.Length && wp < workers.Length && jobs[jp].Difficulty <= workers[wp])
        {
          result += jobs[jp].Profit;
          wp++;
        }
      }

      return result;
    }

    private static void Reverse(int[] a)
      => Reverse(a, a.Length);

    private static void Reverse(int[] a, int n)
    {
      for (var i = 0; i < n / 2; i++)
        (a[i], a[n - i - 1]) = (a[n - i - 1], a[i]);
    }
  }
}
