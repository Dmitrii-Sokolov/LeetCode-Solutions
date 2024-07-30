namespace Problem57
{

  /// <summary>
  /// 57. Insert Interval
  /// https://leetcode.com/problems/insert-interval
  /// 
  /// Difficulty Medium
  /// Acceptance 41.9%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
      var result = new List<int[]>();

      foreach (var interval in intervals)
      {
        if (newInterval == null)
        {
          result.Add(interval);
        }
        else if (IsIntersect(interval, newInterval))
        {
          newInterval = Combine(interval, newInterval);
        }
        else
        {
          if (newInterval[0] < interval[0])
          {
            result.Add(newInterval);
            newInterval = null;
          }

          result.Add(interval);
        }
      }

      if (newInterval != null)
        result.Add(newInterval);

      return result.ToArray();
    }

    private bool IsIntersect(int[] a, int[] b)
        => (b[0] <= a[0] && a[0] <= b[1]) ||
        (a[0] <= b[0] && b[0] <= a[1]);

    private int[] Combine(int[] a, int[] b)
        => new int[2] { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
  }
}
