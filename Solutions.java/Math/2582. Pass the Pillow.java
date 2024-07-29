/// <summary>
/// 2582. Pass the Pillow
/// https://leetcode.com/problems/pass-the-pillow
/// 
/// Difficulty Easy
/// Acceptance 57.0%
/// 
/// Math
/// Simulation
/// </summary>
class Solution
{
  public int passThePillow(int n, int time)
  {
    time = time % (2 * n - 2);
    return time >= n - 1 ? 2 * n - 1 - time : time + 1;
  }
}
