namespace Problem1701
{

  /// <summary>
  /// 1701. Average Waiting Time
  /// https://leetcode.com/problems/average-waiting-time
  /// 
  /// Difficulty Medium
  /// Acceptance 73.1%
  /// 
  /// Array
  /// Simulation
  /// </summary>
  public class Solution
  {
    public double AverageWaitingTime(int[][] customers)
    {
      var waiting = 0d;
      var time = 0d;

      foreach (var customer in customers)
      {
        if (time < customer[0])
        {
          waiting += customer[1];
          time = customer[0] + customer[1];
        }
        else
        {
          waiting += time - customer[0] + customer[1];
          time += customer[1];
        }
      }

      return waiting / customers.Length;
    }
  }
}
