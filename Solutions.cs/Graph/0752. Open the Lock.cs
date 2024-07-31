namespace Problem752
{

  /// <summary>
  /// 752. Open the Lock
  /// https://leetcode.com/problems/open-the-lock
  /// 
  /// Difficulty Medium
  /// Acceptance 60.3%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Breadth-First Search
  /// </summary>
  public class Solution
  {
    public int OpenLock(string[] deadends, string target)
    {
      var t = int.Parse(target);
      var ends = new HashSet<int>();

      for (var i = 0; i < deadends.Length; i++)
      {
        ends.Add(int.Parse(deadends[i]));
      }

      if (ends.Contains(0))
        return -1;

      var shorts = new int[10000];
      var currents = new List<int>();
      currents.Add(0);
      shorts[0] = 1;

      while (currents.Count > 0)
      {
        var nexts = new List<int>();

        for (var i = 0; i < currents.Count; i++)
        {
          var current = currents[i];
          var cost = shorts[current];

          if (current == t)
            return cost - 1;

          Check(shorts, ends, nexts, cost, (10 * (current / 10)) + Mod(current - 1, 10));
          Check(shorts, ends, nexts, cost, (10 * (current / 10)) + Mod(current + 1, 10));

          Check(shorts, ends, nexts, cost, (100 * (current / 100)) + Mod(current - 10, 100));
          Check(shorts, ends, nexts, cost, (100 * (current / 100)) + Mod(current + 10, 100));

          Check(shorts, ends, nexts, cost, (1000 * (current / 1000)) + Mod(current - 100, 1000));
          Check(shorts, ends, nexts, cost, (1000 * (current / 1000)) + Mod(current + 100, 1000));

          Check(shorts, ends, nexts, cost, Mod(current - 1000, 10000));
          Check(shorts, ends, nexts, cost, Mod(current + 1000, 10000));
        }

        currents = nexts;
      }

      return -1;
    }

    private void Check(int[] shorts, HashSet<int> ends, List<int> nexts, int cost, int next)
    {
      if (!ends.Contains(next) && shorts[next] == 0)
      {
        shorts[next] = cost + 1;
        nexts.Add(next);
      }
    }

    private static int Mod(int x, int m) => ((x % m) + m) % m;
  }
}
