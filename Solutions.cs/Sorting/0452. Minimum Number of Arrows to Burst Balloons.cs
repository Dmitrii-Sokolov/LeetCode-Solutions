namespace Problem452
{

  /// <summary>
  /// 452. Minimum Number of Arrows to Burst Balloons
  /// https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons
  /// 
  /// Difficulty Medium
  /// Acceptance 59.2%
  /// 
  /// Array
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int FindMinArrowShots(int[][] points)
    {
      Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
      //points = points.OrderBy(a => a[0]).ToArray();
      var counter = 1;
      var end = points[0][1];

      for (var i = 0; i < points.Length; i++)
      {
        if (points[i][0] > end)
        {
          counter++;
          end = points[i][1];
        }

        //var first = i;
        //while(i + 1 < points.Length &&
        //    Enumerable.Range(first, i - first + 1).All(k => IsIntersect(points[k], points[i + 1])))
        //    i++;
      }

      return counter;
    }

    private bool IsIntersect(int[] a, int[] b)
        => (a[0] <= b[0] && b[0] <= a[1]) ||
        (b[0] <= a[0] && a[0] <= b[1]);
  }
}
