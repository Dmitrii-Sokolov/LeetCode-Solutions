namespace Problem134
{

  /// <summary>
  /// 134. Gas Station
  /// https://leetcode.com/problems/gas-station
  /// 
  /// Difficulty Medium
  /// Acceptance 45.6%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
      long current = 0;
      long min = 0;
      var minIndex = 0;

      for (var i = 0; i < gas.Length; i++)
      {
        if (current < min)
        {
          min = current;
          minIndex = i;
        }
        current = current + gas[i] - cost[i];
      }

      return current < 0 ? -1 : minIndex;
    }
  }
}
