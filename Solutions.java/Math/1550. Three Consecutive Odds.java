/// <summary>
/// 1550. Three Consecutive Odds
/// https://leetcode.com/problems/three-consecutive-odds
/// 
/// Difficulty Easy
/// Acceptance 68.4%
/// 
/// Array
/// </summary>
class Solution
{
  public boolean threeConsecutiveOdds(int[] arr)
  {
    var count = 0;
    for (var a : arr)
    {
      if (a % 2 == 1)
      {
        count++;
        if (count == 3)
        {
          return true;
        }
      }
      else
      {
        count = 0;
      }
    }

    return false;
  }
}
