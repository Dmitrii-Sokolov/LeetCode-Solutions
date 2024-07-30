namespace Problem621
{

  /// <summary>
  /// 621. Task Scheduler
  /// https://leetcode.com/problems/task-scheduler
  /// 
  /// Difficulty Medium
  /// Acceptance 60.2%
  /// 
  /// Array
  /// Hash Table
  /// Greedy
  /// Sorting
  /// Heap (Priority Queue)
  /// Counting
  /// </summary>
  public class Solution
  {
    private const int A = 65;
    private const int Z = 90;

    public int LeastInterval(char[] tasks, int n)
    {
      if (n == 0)
        return tasks.Length;

      var freq = new int[Z - A + 1];

      foreach (var t in tasks)
        freq[t - A]++;


      var counter = tasks.Length;
      var step = n + 1;
      var result = 0;

      while (counter > 0)
      {
        //TODO not all letters
        Array.Sort(freq);

        var slots = step;
        var i = freq.Length;
        while (i > 0 && slots > 0)
        {
          i--;

          if (freq[i] > 0)
          {
            counter--;
            freq[i]--;
            slots--;
          }
        }

        if (counter > 0)
        {
          result += step;
        }
        else
        {
          result += step - slots;
        }
      }

      return result;
    }
  }
}
