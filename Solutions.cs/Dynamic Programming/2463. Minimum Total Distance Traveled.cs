namespace Problem2463
{

  /// <summary>
  /// 2463. Minimum Total Distance Traveled
  /// https://leetcode.com/problems/minimum-total-distance-traveled
  /// 
  /// Difficulty Hard
  /// Acceptance 55.3%
  /// 
  /// Array
  /// Dynamic Programming
  /// Sorting
  /// </summary>
  public class Solution
  {
    public long MinimumTotalDistance(IList<int> robotsRaw, int[][] factoriesRaw)
    {
      var robots = robotsRaw.ToList();
      robots.Sort();

      Array.Sort(factoriesRaw, (a, b) => a[0].CompareTo(b[0]));
      var factories = new List<int>();
      foreach (var factory in factoriesRaw)
      {
        while (factory[1]-- > 0)
          factories.Add(factory[0]);
      }

      var minimumDistances = new long[robots.Count + 1, factories.Count + 1];
      for (var robotsCount = 1; robotsCount <= robots.Count; robotsCount++)
      {
        var i = robotsCount;
        while (i-- > 0)
          minimumDistances[robotsCount, robotsCount] += Math.Abs(factories[i] - robots[i]);

        for (var factoriesCount = robotsCount + 1; factoriesCount <= factories.Count; factoriesCount++)
        {
          minimumDistances[robotsCount, factoriesCount] = Math.Min(
            minimumDistances[robotsCount, factoriesCount - 1],
            minimumDistances[robotsCount - 1, factoriesCount - 1] + Math.Abs(factories[factoriesCount - 1] - robots[robotsCount - 1]));
        }
      }

      return minimumDistances[
        robots.Count,
        factories.Count];
    }
  }
}
