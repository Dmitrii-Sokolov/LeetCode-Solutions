namespace Problem1518
{

  /// <summary>
  /// 1518. Water Bottles
  /// https://leetcode.com/problems/water-bottles/description/
  /// 
  /// Difficulty Easy 71.0%
  /// 
  /// Math
  /// Simulation
  /// </summary>
  class Solution
  {
    public int numWaterBottles(int numBottles, int numExchange)
    {
      var result = numBottles;

      while (numBottles >= numExchange)
      {
        var full = numBottles / numExchange;
        numBottles = numBottles % numExchange + full;
        result += full;
      }

      return result;
    }
  }
}
