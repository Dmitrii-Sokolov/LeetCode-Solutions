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
