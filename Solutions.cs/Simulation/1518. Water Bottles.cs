namespace Problem1518
{

  /// <summary>
  /// 1518. Water Bottles
  /// https://leetcode.com/problems/water-bottles
  /// 
  /// Difficulty Easy
  /// Acceptance 71.0%
  /// 
  /// Math
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int NumWaterBottles(int numBottles, int numExchange)
    {
      var result = numBottles;

      while (numBottles >= numExchange)
      {
        var full = numBottles / numExchange;
        numBottles = (numBottles % numExchange) + full;
        result += full;
      }

      return result;
    }
  }
}
