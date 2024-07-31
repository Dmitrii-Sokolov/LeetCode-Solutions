namespace Problem1491
{

  /// <summary>
  /// 1491. Average Salary Excluding the Minimum and Maximum Salary
  /// https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary
  /// 
  /// Difficulty Easy
  /// Acceptance 63.5%
  /// 
  /// Array
  /// Sorting
  /// </summary>
  public class Solution
  {
    public double Average(int[] salary)
    {
      var min = 1000000;
      var max = 1000;
      var sum = 0;
      var count = salary.Length;
      foreach (var s in salary)
      {
        min = Math.Min(min, s);
        max = Math.Max(max, s);
        sum += s;
      }

      return (sum - min - max) * 1.0 / (count - 2);
    }
  }
}
