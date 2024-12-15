namespace Problem1792
{

  /// <summary>
  /// 1792. Maximum Average Pass Ratio
  /// https://leetcode.com/problems/maximum-average-pass-ratio
  /// 
  /// Difficulty Medium
  /// Acceptance 60.9%
  /// 
  /// Array
  /// Greedy
  /// Heap(Priority Queue)
  /// </summary>
  public class Solution
  {
    public double MaxAverageRatio(int[][] classesRaw, int extraStudents)
    {
      var classes = new PriorityQueue<(int Passed, int Total), float>(classesRaw.Length);
      foreach (var c in classesRaw)
      {
        var passed = c[0];
        var total = c[1];
        var delta = (float)(passed - total) / total / (total + 1);
        classes.Enqueue((passed, total), delta);
      }

      while (extraStudents-- > 0)
      {
        var (passed, total) = classes.Dequeue();
        total++;
        passed++;
        var delta = (float)(passed - total) / total / (total + 1);
        classes.Enqueue((passed, total), delta);
      }

      var result = 0d;
      while (classes.Count > 0)
      {
        var (passed, total) = classes.Dequeue();
        result += (double)passed / total;
      }

      result /= classesRaw.Length;

      return result;
    }
  }
}
