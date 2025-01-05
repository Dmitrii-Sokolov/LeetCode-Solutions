namespace Problem1732
{

  /// <summary>
  /// 1732. Find the Highest Altitude
  /// https://leetcode.com/problems/find-the-highest-altitude
  /// 
  /// Difficulty Easy
  /// Acceptance 83.7%
  /// 
  /// Array
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int LargestAltitude(int[] gain)
    {
      var altitude = 0;
      var result = 0;
      foreach (var delta in gain)
      {
        altitude += delta;

        if (result < altitude)
          result = altitude;
      }

      return result;
    }
  }
}
